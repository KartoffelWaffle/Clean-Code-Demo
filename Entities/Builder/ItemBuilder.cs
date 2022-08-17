using Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Builder
{
    public class ItemBuilder
    {

        private int ID;
        private string Name;
        public float ItemPrice;
        private int Quantity;
        private string EmployeeName;
        private I_ItemState State;
        private DateTime DateCreated;

        public ItemBuilder()
        {
            this.ID = -1;
            this.Name = "";
            this.Quantity = -1;
            this.EmployeeName = "";
            this.DateCreated = DateTime.Now;
            this.State = ItemStateFactory.Create("Item Out Of Stock");
        }

        public Item Build()
        {
            return new Item(ID, Name, ItemPrice, Quantity, EmployeeName, DateCreated, State);
        }

        public ItemBuilder WithID(int ID)
        {
            this.ID = ID;
            return this;
        }

        public ItemBuilder WithName(string Name)
        {
            this.Name = Name;
            return this;
        }

        public ItemBuilder WithItemPrice(float ItemPrice)
        {
            this.ItemPrice = ItemPrice;
            return this;
        }

        public ItemBuilder WithQuantity(int Quantity)
        {
            this.Quantity = Quantity;
            return this;
        }

        public ItemBuilder WithEmployeeName(string EmployeeName) 
        {
            this.EmployeeName = EmployeeName;
            return this;
        }

        public ItemBuilder WithDateCreated(DateTime DateCreated)
        {
            this.DateCreated = DateCreated;
            return this;
        }

        public ItemBuilder WithState(I_ItemState State) 
        {
            this.State = State;
            return this;
        }
    }
}
