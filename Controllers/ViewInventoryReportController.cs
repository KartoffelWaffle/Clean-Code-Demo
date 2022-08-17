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
    public class ViewInventoryReportController : AbstractController
    {
        public ViewInventoryReportController(AbstractPresenter presenter) :
                                    base(new DatabaseGatewayFacade(), presenter)
        {
        }

        public override IDTO ExecuteUseCase() => new ViewInventoryReport(GatewayFacade).Execute();
    }
}
