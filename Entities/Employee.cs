using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee : IEntity
    {
        public int ID { get; }
        public string Name { get; }

        public Employee(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public override string ToString()
        {
            return ID + ": " + Name;
        }
    }
}
