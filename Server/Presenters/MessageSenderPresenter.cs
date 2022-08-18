using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usecases;

namespace Server.Presenters
{
    class MessageSenderPresenter : AbstractPresenter
    {
        public override IViewData ViewData
        {
            get
            {
                List<string> lines = new List<string>();
                lines.Add("\n" + ((MessageSenderDTO)DataToPresent).Message);
                return new CommandLineViewData(lines);
            }
        }
    }
}
