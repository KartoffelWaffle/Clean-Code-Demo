using DTO;
using OracleDatabaseGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usecases;

namespace Controllers
{
    public  class AddQuantityToItemController : AbstractController
    {
        private string ItemName;
        private int Quantity;
        private string EmployeeName;
        public AddQuantityToItemController(string ItemName,
                                           string EmployeeName,
                                           int Quantity,
                                           AbstractPresenter presenter) :
                                     base(new DatabaseGatewayFacade(), presenter)
        {
            this.ItemName = ItemName;
            this.EmployeeName = EmployeeName;
            this.Quantity = Quantity;
        }

        public override IDTO ExecuteUseCase() => new AddQuantityToItem(ItemName, EmployeeName, Quantity, GatewayFacade).Execute();
    }
}
