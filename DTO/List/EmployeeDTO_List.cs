using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.List
{
    [Serializable]
    class EmployeeDTO_List : IDTO
    {
        public List<EmployeeDTO> List { get; }

        public EmployeeDTO_List(List<EmployeeDTO> List)
        {
            this.List = List;
        }
    }
}
