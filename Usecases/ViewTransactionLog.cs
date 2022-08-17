using DTO;
using DTO.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usecases
{
    public class ViewTransactionLog : AbstractUsecase
    {
        public ViewTransactionLog(IDatabaseGatewayFacade gatewayFacade) : base(gatewayFacade)
        {
        }

        public override IDTO Execute()
        {
            return new LogDTO_List(GatewayFacade.GetTransactionLog());
        }
    }
}
