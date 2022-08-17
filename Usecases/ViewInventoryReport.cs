using DTO;
using DTO.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usecases
{
    public class ViewInventoryReport : AbstractUsecase
    {
        public ViewInventoryReport(IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
        }

        public override IDTO Execute()
        {
            return new ItemDTO_List(GatewayFacade.GetInventoryReport());
        }
    }
}
