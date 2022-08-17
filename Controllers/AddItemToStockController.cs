using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usecases;
using OracleDatabaseGateway;

namespace Controllers
{
    public class AddItemToStockController : AbstractController
    {

        private ItemDTO ItemDTO;
        public AddItemToStockController(ItemDTO ItemDTO, 
                                        AbstractPresenter presenter) : 
                                  base(new DatabaseGatewayFacade(), presenter)
        {
            this.ItemDTO = ItemDTO;
        }

        public override IDTO ExecuteUseCase() => new AddItemToStock(ItemDTO, GatewayFacade).Execute();
    }
}
