using DTO;
using DTO.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usecases
{
    public class ViewFinancialReport : AbstractUsecase
    {
        public ViewFinancialReport(IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
        }

        public override IDTO Execute()
        {
            return new LogDTO_List(GatewayFacade.GetFinancialReport());
        }
    }
}
