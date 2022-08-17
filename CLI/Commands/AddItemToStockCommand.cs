using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLI.Presenters;
using Controllers;
using DTO;
using DTO.Builder;

namespace CLI.Commands
{
    class AddItemToStockCommand : Command
    {
        public void Execute()
        {
           ItemDTO ItemDTO = new ItemDTO_Builder()
                .WithDateCreated(DateTime.Now)
                .WithID(ConsoleReader.ReadInt("\nItem ID: "))
                .WithItemPrice(ConsoleReader.ReadFloat("\nItem Price: "))
                .WithName(ConsoleReader.ReadString("\nItem Name: "))
                .WithQuantity(ConsoleReader.ReadInt("\nQuantity: "))
                .WithEmployeeName("Employee Name: ")
                .Build();
           float ItemPrice = ConsoleReader.ReadFloat("\nPrice: ");

            AddItemToStockController controller =
               new AddItemToStockController(ItemDTO,
                                            new MessageSenderPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
