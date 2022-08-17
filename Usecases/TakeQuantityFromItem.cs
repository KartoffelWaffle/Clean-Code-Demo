using DTO;
using DTO.Builder;
using DTO.Converter;
using Entities;
using Entities.Builder;
using System;
using System.Transactions;

namespace Usecases
{
    public class TakeQuantityFromItem : AbstractUsecase
    {

        private readonly string ItemName;
        private readonly int Quantity;
        private readonly string EmployeeName;

        public TakeQuantityFromItem(string ItemName,
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
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    ItemConverter ItemConverter = new ItemConverter();
                    bool HasExecuted = false;

                    Item Item = ItemConverter.ConvertDTOToEntity(GatewayFacade.GetItem(ItemName));

                    if (Item == null)
                    {
                        return new MessageSenderDTO("Could not find item in stock");
                    }

                    if (Item.CanTake())
                    {
                        if (Quantity < Item.Quantity)
                        {

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
                                .WithTypeOfTransaction("Remove from Stock")
                                .WithDateAdded(DateTime.Now)
                                .WithItemQuantity(ItemDTO.Quantity)
                                .Build();

                            HasExecuted = GatewayFacade.UpdateQuantityFromStock(ItemDTO) && GatewayFacade.InsertTransactionLog(LogDTO);
                            scope.Complete();
                        }
                        else return new MessageSenderDTO("Not enough quantity to remove, please choose less items");
                    }

                    if (HasExecuted)
                    {
                        return new MessageSenderDTO("quantity removed successfully");
                    }
                    else return new MessageSenderDTO("System failed to remove quantity");
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
                return new MessageSenderDTO("System failed to remove quantity");
            }
        }
    }
}
