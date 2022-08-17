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
    public class ViewFinancialReportController : AbstractController
    {
        public ViewFinancialReportController(AbstractPresenter presenter) :
                                    base(new DatabaseGatewayFacade(), presenter)
        {
        }

        public override IDTO ExecuteUseCase() => new ViewFinancialReport(GatewayFacade).Execute();
    }
}
