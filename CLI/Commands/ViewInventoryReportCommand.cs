using System;
using CLI.Presenters;
using Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Commands
{
    public class ViewInventoryReportCommand : Command
    {
        public void Execute()
        {
            ViewInventoryReportController controller =
                        new ViewInventoryReportController(
                            new InventoryReportPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
