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
    public class TakeQuantityFromItemController : AbstractController
    {
        private readonly string ItemName;
        private readonly int Quantity;
        private readonly string EmployeeName;
        public TakeQuantityFromItemController(string ItemName,
                                              string EmployeeName,
                                              int Quantity,
                                              AbstractPresenter presenter) :
                                     base(new DatabaseGatewayFacade(), presenter)
        {
            this.ItemName = ItemName;
            this.EmployeeName = EmployeeName;
            this.Quantity = Quantity * -1;
        }

        public override IDTO ExecuteUseCase() => new TakeQuantityFromItem(ItemName, EmployeeName, Quantity, GatewayFacade).Execute();
    }
}
