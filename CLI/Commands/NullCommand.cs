using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Commands
{
    class NullCommand : Command
    {
        public void Execute()
        {
            ConsoleWriter.WriteStrings(
                new List<string>()
                    {"Unable to process your request, please try again"});
        }
    }
}
