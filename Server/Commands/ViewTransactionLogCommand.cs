using Server.Presenters;
using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
    class ViewTransactionLogCommand : Command
    {

        public ViewTransactionLogCommand(string data) 
        {

        }

        public List<string> Execute()
        {
            ViewTransactionLogController controller =
                        new ViewTransactionLogController(
                            new TransactionLogPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            return data.ViewData;
        }
    }
}
