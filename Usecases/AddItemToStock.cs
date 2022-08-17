using DTO;
using DTO.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Usecases
{
    public class AddItemToStock : AbstractUsecase
    {
        private readonly ItemDTO ItemDTO;

        public AddItemToStock(ItemDTO ItemDTO, 
                                IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
            this.ItemDTO = ItemDTO;
        }

        public override IDTO Execute()
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    LogDTO LogDTO =
                        new LogDTO_Builder()
                        .WithItem(ItemDTO)
                        .WithTypeOfTransaction("Add to Stock")
                        .WithDateAdded(DateTime.Now)
                        .Build();

                    bool hasExecuted = GatewayFacade.InsertItemIntoStock(ItemDTO) && GatewayFacade.InsertTransactionLog(LogDTO);

                    if (hasExecuted)
                    {
                        return new MessageSenderDTO("Item added successfully");
                    }
                    else return new MessageSenderDTO("System failed to add item");
                    scope.Complete();
                }

            }
            catch (TransactionAbortedException e)
            {
                return new MessageSenderDTO(
                    "\n\t(Aborted) Transaction.Current: " +
                    Transaction.Current +
                    "\tTransaction has been aborted: " +
                    e.Message);
            }
            catch (Exception e)
            {
                return new MessageSenderDTO("System failed to add item");
            }
        }
    }
}
