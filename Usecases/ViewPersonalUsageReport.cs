using DTO;
using DTO.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usecases
{
    public class ViewPersonalUsageReport : AbstractUsecase
    {
        private readonly string EmployeeName;

        public ViewPersonalUsageReport(string EmployeeName, IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
            this.EmployeeName = EmployeeName;
        }

        public override IDTO Execute()
        {
            return new LogDTO_List(GatewayFacade.GetUsageReport(EmployeeName));
        }
    }
}
