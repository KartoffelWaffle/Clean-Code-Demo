using DTO;
using OracleDatabaseGateway;
using System;
using System.Collections.Generic;
using System.Text;
using Usecases;

namespace Controllers
{
    public class InitialiseDatabaseController : AbstractController
    {
        public InitialiseDatabaseController(
            AbstractPresenter presenter) : base(new DatabaseGatewayFacade(), presenter)
        {
        }

        public override IDTO ExecuteUseCase()
        {
            return new InitalDatabasePopulation(GatewayFacade).Execute();
        }
    }
}
