using System;
using CLI.Presenters;
using Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Commands
{
    class ViewFinancialReportCommand : Command
    {
        public void Execute()
        {
            ViewFinancialReportController controller =
                        new ViewFinancialReportController(
                            new FinancialReportPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
