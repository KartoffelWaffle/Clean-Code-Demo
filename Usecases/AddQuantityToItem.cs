using DTO;
using DTO.Builder;
using DTO.Converter;
using Entities;
using Entities.Builder;
using System;
using System.Transactions;

namespace Usecases
{
    public class AddQuantityToItem : AbstractUsecase
    {

        private readonly string ItemName;
        private readonly int Quantity;
        private readonly string EmployeeName;

        public AddQuantityToItem(string ItemName,
                                    string EmployeeName,
                                    int Quantity,
                                    IDatabaseGatewayFacade GatewayFacade) : base(GatewayFacade)
        {
            this.ItemName = ItemName;
            this.EmployeeName = EmployeeName;
            this.Quantity = Quantity;
        }
        public override IDTO Execute()
        {
            try
            {
                bool HasExecuted = false;
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    ItemConverter ItemConverter = new ItemConverter();

                    Item Item = ItemConverter.ConvertDTOToEntity(GatewayFacade.GetItem(ItemName));

                    if (Item == null)
                    {
                        return new MessageSenderDTO("Could not find item in stock");
                    }

                    Item UpdatedItem =
                       new ItemBuilder()
                       .WithID(Item.ID)
                       .WithEmployeeName(EmployeeName)
                       .WithDateCreated(Item.DateCreated)
                       .WithName(Item.Name)
                       .WithQuantity(Item.Quantity + Quantity)
                       .Build();


                    ItemDTO ItemDTO = ItemConverter.ConvertEntityToDTO(UpdatedItem);

                    LogDTO LogDTO =
                       new LogDTO_Builder()
                        .WithItem(ItemDTO)
                        .WithTypeOfTransaction("Add to Stock")
                        .WithDateAdded(DateTime.Now)
                        .WithItemQuantity(ItemDTO.Quantity)
                        .Build();

                    HasExecuted = GatewayFacade.UpdateQuantityFromStock(ItemDTO) && GatewayFacade.InsertTransactionLog(LogDTO);
                    scope.Complete();
                    
                }

                if (HasExecuted)
                {
                    return new MessageSenderDTO("quantity added successfully");
                }
                else return new MessageSenderDTO("System failed to add quantity");
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
                return new MessageSenderDTO("System failed to add quantity");
            }
        }
    }
}
