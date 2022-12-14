using Server.Presenters;
using Controllers;
using DTO;
using DTO.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
    class TakeQuantityFromItemCommand : Command
    {
        private string[] clientData;
        public TakeQuantityFromItemCommand(string data) 
        {
            this.clientData = data.Split(':');
        }

        public List<string> Execute()
        {
            ItemDTO ItemDTO = new ItemDTO_Builder()
                 .WithDateCreated(DateTime.Now)
                 .WithID(Int32.Parse(clientData[0]))
                 .WithName(clientData[1])
                 .WithQuantity(Int32.Parse(clientData[2]))
                 .WithEmployeeName(clientData[3])
                 .Build();

            TakeQuantityFromItemController controller =
               new TakeQuantityFromItemController(ItemDTO.Name,
                                            ItemDTO.EmployeeName,
                                            ItemDTO.Quantity,
                                            new MessageSenderPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            return data.ViewData;
        }
    }
}
