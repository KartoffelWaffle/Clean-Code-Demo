using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usecases;

namespace CLI.Presenters
{
    class CommandLineViewData : IViewData
    {
        public List<string> ViewData { get; }

        public CommandLineViewData(List<string> viewData)
        {
            ViewData = viewData;
        }
    }
}
