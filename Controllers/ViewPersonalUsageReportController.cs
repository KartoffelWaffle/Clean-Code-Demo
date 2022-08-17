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
    public class ViewPersonalUsageReportController : AbstractController
    {
        private readonly string EmployeeName;

        public ViewPersonalUsageReportController(string EmployeeName,
                                                 AbstractPresenter presenter) :
                                        base(new DatabaseGatewayFacade(), presenter)
        {
            this.EmployeeName = EmployeeName;
        }

        public override IDTO ExecuteUseCase() => new ViewPersonalUsageReport(EmployeeName, GatewayFacade).Execute();
    }
}
