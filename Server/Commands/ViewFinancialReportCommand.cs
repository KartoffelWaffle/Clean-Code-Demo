using System;
using Server.Presenters;
using Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
    class ViewFinancialReportCommand : Command
    {
        private string clientData;

        public ViewFinancialReportCommand(string data) 
        {
            this.clientData = data;
        }

        public List<string> Execute()
        {
            ViewFinancialReportController controller =
                        new ViewFinancialReportController(
                            new FinancialReportPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            return data.ViewData;
        }
    }
}
