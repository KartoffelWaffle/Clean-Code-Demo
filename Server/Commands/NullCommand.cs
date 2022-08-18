using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
    class NullCommand : Command
    {
        public List<string> Execute()
        {
            return new List<string>() {"Unable to process your request, please try again"};
        }
    }
}
