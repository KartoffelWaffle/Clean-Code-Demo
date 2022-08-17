using System;
using Entities.State;

namespace Entities
{
    public class Item : IEntity
    {
        public int ID { get; }
        public string Name { get; }
        public float ItemPrice { get; }
        public int Quantity { get; set; }
        public string EmployeeName { get; }
        private I_ItemState state;
        public string State { get { return state.ToString(); } }
        public DateTime DateCreated { get; }

        public Item(int ID, string Name, float ItemPrice, int Quantity, string EmployeeName, DateTime DateCreated, I_ItemState state)
        {
            this.ID = ID;
            this.Name = Name;
            this.ItemPrice = ItemPrice;
            this.Quantity = Quantity;
            this.EmployeeName = EmployeeName;
            this.DateCreated = DateCreated;
            this.state = state;
        }

        public bool CanTake() 
        {
            bool canTake = state.InStock();
            state = state.TakeItem(this.Quantity);
            return canTake;
        }
    }
}
