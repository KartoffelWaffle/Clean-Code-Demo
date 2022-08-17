using CLI.Presenters;
using Controllers;
using DTO;
using DTO.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Commands
{
    class AddQuantityToItemCommand : Command
    {
        public void Execute()
        {
            ItemDTO ItemDTO = new ItemDTO_Builder()
                  .WithDateCreated(DateTime.Now)
                  .WithID(ConsoleReader.ReadInt("\nItem ID: "))
                  .WithName(ConsoleReader.ReadString("\nItem Name: "))
                  .WithQuantity(ConsoleReader.ReadInt("\nQuantity: "))
                  .WithEmployeeName(ConsoleReader.ReadString("\nEmployee Name: "))
                  .Build();

            AddQuantityToItemController controller =
               new AddQuantityToItemController(ItemDTO.Name,
                                            ItemDTO.EmployeeName,
                                            ItemDTO.Quantity,
                                            new MessageSenderPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
