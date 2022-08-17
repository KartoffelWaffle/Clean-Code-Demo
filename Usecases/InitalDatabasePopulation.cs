using DTO;
using DTO.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usecases
{
    public class InitalDatabasePopulation : AbstractUsecase
    {

        public InitalDatabasePopulation(IDatabaseGatewayFacade GatewayFacade) : base(GatewayFacade)
        {
        }

    public override IDTO Execute()
        {
            if (GatewayFacade.InitialiseDatabase())
            {

                GatewayFacade.InsertEmployee(
                    new EmployeeDTO_Builder()
                    .WithID(1)
                    .WithName("Graham")
                    .Build());

                GatewayFacade.InsertEmployee(
                    new EmployeeDTO_Builder()
                    .WithID(2)
                    .WithName("Phil")
                    .Build());

                GatewayFacade.InsertEmployee(
                    new EmployeeDTO_Builder()
                    .WithID(3)
                    .WithName("Jan")
                    .Build());

                GatewayFacade.InsertItemIntoStock(
                    new ItemDTO_Builder()
                    .WithID(1)
                    .WithName("Pencil")
                    .WithItemPrice(0.25f)
                    .WithQuantity(10)
                    .WithEmployeeName("Graham")
                    .WithDateCreated(DateTime.Now)
                    .Build());

                GatewayFacade.InsertTransactionLog(
                    new LogDTO_Builder()
                    .WithTransactionID(1)
                    .WithItem(new ItemDTO_Builder()
                              .WithID(1)
                              .WithName("Pencil")
                              .WithQuantity(10)
                              .WithEmployeeName("Graham")
                              .WithDateCreated(DateTime.Now)
                              .WithState("Item In Stock")
                              .Build())
                    .WithTypeOfTransaction("Add to Stock")
                    .WithItemQuantity(10)
                    .WithDateAdded(DateTime.Now)
                    .Build());

                GatewayFacade.InsertItemIntoStock(
                    new ItemDTO_Builder()
                    .WithID(2)
                    .WithName("Eraser")
                    .WithItemPrice(0.15f)
                    .WithQuantity(20)
                    .WithEmployeeName("Phil")
                    .WithDateCreated(DateTime.Now)
                    .Build());

                GatewayFacade.InsertTransactionLog(
                    new LogDTO_Builder()
                    .WithTransactionID(2)
                    .WithItem(new ItemDTO_Builder()
                              .WithID(2)
                              .WithName("Eraser")
                              .WithQuantity(20)
                              .WithEmployeeName("Phil")
                              .WithDateCreated(DateTime.Now)
                              .WithState("Item In Stock")
                              .Build())
                    .WithItemQuantity(10)
                    .WithTypeOfTransaction("Add to Stock")
                    .WithDateAdded(DateTime.Now)
                    .Build());

                GatewayFacade.UpdateQuantityFromStock(
                    new ItemDTO_Builder()
                    .WithID(2)
                    .WithName("Eraser")
                    .WithQuantity(16)
                    .WithEmployeeName("Graham")
                    .WithDateCreated(DateTime.Now)
                    .Build());

                GatewayFacade.InsertTransactionLog(
                    new LogDTO_Builder()
                    .WithTransactionID(3)
                    .WithItem(new ItemDTO_Builder()
                              .WithID(2)
                              .WithName("Eraser")
                              .WithQuantity(16)
                              .WithEmployeeName("Graham")
                              .WithDateCreated(DateTime.Now)
                              .WithState("Item In Stock")
                              .Build())
                    .WithTypeOfTransaction("Updated Quantity")
                    .WithItemQuantity(16)
                    .WithDateAdded(DateTime.Now)
                    .Build());

                GatewayFacade.UpdateQuantityFromStock(
                    new ItemDTO_Builder()
                    .WithID(2)
                    .WithName("Eraser")
                    .WithQuantity(18)
                    .WithEmployeeName("Phil")
                    .WithDateCreated(DateTime.Now)
                    .Build());

                GatewayFacade.InsertTransactionLog(
                    new LogDTO_Builder()
                    .WithTransactionID(4)
                    .WithItem(new ItemDTO_Builder()
                              .WithID(2)
                              .WithName("Eraser")
                              .WithQuantity(18)
                              .WithEmployeeName("Phil")
                              .WithDateCreated(DateTime.Now)
                              .WithState("Item In Stock")
                              .Build())
                    .WithTypeOfTransaction("Updated Quantity")
                    .WithItemQuantity(18)
                    .WithDateAdded(DateTime.Now)
                    .Build());

                return new MessageSenderDTO("The database has been populated");
            }
            else
                return new MessageSenderDTO("An error occured and the database has not been populated");
        }
    }
}
