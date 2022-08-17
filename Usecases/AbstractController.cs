using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usecases
{
    public abstract class AbstractController
    {
        protected readonly IDatabaseGatewayFacade GatewayFacade;
        protected AbstractPresenter Presenter;

        public AbstractController(IDatabaseGatewayFacade DBGatewayFacade, AbstractPresenter Presenter)
        {
            this.GatewayFacade = DBGatewayFacade;
            this.Presenter = Presenter;
        }

        public IViewData Execute()
        {
            Presenter.DataToPresent = ExecuteUseCase();
            return Presenter.ViewData;
        }

        public abstract IDTO ExecuteUseCase();
    }
}
