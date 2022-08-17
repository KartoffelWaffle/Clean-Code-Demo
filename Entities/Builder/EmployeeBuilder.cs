using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Builder
{
    public class EmployeeBuilder
    {
        private int ID;
        private string Name;

        public EmployeeBuilder()
        {
            this.ID = -1;
            this.Name = "";
        }

        public Employee Build()
        {
            return new Employee(ID, Name);
        }

        public EmployeeBuilder WithID(int ID)
        {
            this.ID = ID;
            return this;
        }

        public EmployeeBuilder WithName(string Name)
        {
            this.Name = Name;
            return this;
        }
    }
}
