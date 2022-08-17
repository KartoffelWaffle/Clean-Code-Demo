using System;
using CLI.Presenters;
using Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Commands
{
    public class ViewPersonalUsageReportCommand : Command
    {
        public void Execute()
        {
            string EmployeeName = ConsoleReader.ReadString("\nEmployee Name: ");

            ViewPersonalUsageReportController controller =
                        new ViewPersonalUsageReportController(
                            EmployeeName,
                            new UsageReportPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
