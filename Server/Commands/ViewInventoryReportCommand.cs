using System;
using Server.Presenters;
using Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
    public class ViewInventoryReportCommand : Command
    {

        public ViewInventoryReportCommand(string data) 
        {
        }

        public List<string> Execute()
        {
            ViewInventoryReportController controller =
                        new ViewInventoryReportController(
                            new InventoryReportPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            return data.ViewData;
        }
    }
}
