using CLI.Presenters;
using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Commands
{
    class ViewTransactionLogCommand : Command
    {
        public void Execute()
        {
            ViewTransactionLogController controller =
                        new ViewTransactionLogController(
                            new TransactionLogPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
