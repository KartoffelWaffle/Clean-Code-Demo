using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Builder
{
    public class EmployeeDTO_Builder
    {
        private int ID;
        private string Name;

        public EmployeeDTO_Builder()
        {
            this.ID = -1;
            this.Name = "";
        }

        public EmployeeDTO Build()
        {
            return new EmployeeDTO(ID, Name);
        }

        public EmployeeDTO_Builder WithID(int ID)
        {
            this.ID = ID;
            return this;
        }

        public EmployeeDTO_Builder WithName(string Name)
        {
            this.Name = Name;
            return this;
        }
    }
}
