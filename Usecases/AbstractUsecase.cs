using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usecases
{
    public abstract class AbstractUsecase
    {
        protected readonly IDatabaseGatewayFacade GatewayFacade;

        protected AbstractUsecase(IDatabaseGatewayFacade GatewayFacade)
        {
            this.GatewayFacade = GatewayFacade;
        }

        public abstract IDTO Execute();
    }
}
