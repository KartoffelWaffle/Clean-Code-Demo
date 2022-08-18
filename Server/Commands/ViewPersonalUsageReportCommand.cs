using System;
using Server.Presenters;
using Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
    public class ViewPersonalUsageReportCommand : Command
    {

        private string[] clientData;
        public ViewPersonalUsageReportCommand(string data) 
        {
            this.clientData = data.Split(':');
        }

        public List<string> Execute()
        {
            string EmployeeName = clientData[0];

            ViewPersonalUsageReportController controller =
                        new ViewPersonalUsageReportController(
                            EmployeeName,
                            new UsageReportPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            return data.ViewData;
        }
    }
}
