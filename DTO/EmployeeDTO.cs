using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Serializable]
    public class EmployeeDTO : IDTO
    {
        public int ID { get; }
        public string Name { get; }

        public EmployeeDTO(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

    }
}
