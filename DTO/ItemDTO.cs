using Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Serializable]
    public class ItemDTO : IDTO
    {
        public int ID { get; }
        public string Name { get; }
        public int Quantity { get; }
        public string EmployeeName { get; }
        public float ItemPrice { get; }
        public String State { get; }
        public DateTime DateCreated { get; }

        public ItemDTO(int ID, string Name, float ItemPrice, int Quantity, string EmployeeName, DateTime DateCreated, String State)
        {
            this.ID = ID;
            this.Name = Name;
            this.ItemPrice = ItemPrice;
            this.Quantity = Quantity;
            this.EmployeeName = EmployeeName;
            this.DateCreated = DateCreated;
            this.State = State;
        }
    }
}
