using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Presenters;
using Controllers;
using DTO;
using DTO.Builder;

namespace Server.Commands
{
    class AddItemToStockCommand : Command
    {
        private string[] clientData;

        public AddItemToStockCommand(string data) 
        {
            this.clientData = data.Split(':');
        }

        public List<string> Execute()
        {
           ItemDTO ItemDTO = new ItemDTO_Builder()
                .WithDateCreated(DateTime.Now)
                .WithID(Int32.Parse(clientData[0]))
                .WithName(clientData[1])
                .WithItemPrice(float.Parse(clientData[2]))
                .WithQuantity(Int32.Parse(clientData[3]))
                .WithEmployeeName(clientData[4])
                .Build();

            AddItemToStockController controller =
               new AddItemToStockController(ItemDTO,
                                            new MessageSenderPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            return data.ViewData;
        }
    }
}
