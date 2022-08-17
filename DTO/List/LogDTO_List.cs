using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.List
{
    [Serializable]
    public class LogDTO_List : IDTO
    {
        public List<LogDTO> List { get; }

        public LogDTO_List(List<LogDTO> List)
        {
            this.List = List;
        }
    }
}
