using Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Builder
{
    public class ItemDTO_Builder
    {
        private int ID;
        private string Name;
        private int Quantity;
        private float ItemPrice;
        private string EmployeeName;
        private DateTime DateCreated;
        private string State;

        public ItemDTO_Builder()
        {
            this.ID = -1;
            this.Name = "";
            this.ItemPrice = -1;
            this.Quantity = -1;
            this.EmployeeName = "";
            this.DateCreated = DateTime.Now;
            this.State = ItemStateFactory.Create(0).ToString();
        }

        public ItemDTO Build()
        {
            return new ItemDTO(ID, Name, ItemPrice, Quantity, EmployeeName, DateCreated, State);
        }

        public ItemDTO_Builder WithID(int ID)
        {
            this.ID = ID;
            return this;
        }

        public ItemDTO_Builder WithName(string Name)
        {
            this.Name = Name;
            return this;
        }

        public ItemDTO_Builder WithItemPrice(float ItemPrice)
        {
            this.ItemPrice = ItemPrice;
            return this;
        }

        public ItemDTO_Builder WithQuantity(int Quantity)
        {
            this.Quantity = Quantity;
            return this;
        }

        public ItemDTO_Builder WithEmployeeName(string EmployeeName)
        {
            this.EmployeeName = EmployeeName;
            return this;
        }

        public ItemDTO_Builder WithDateCreated(DateTime DateCreated)
        {
            this.DateCreated = DateCreated;
            return this;
        }

        public ItemDTO_Builder WithState(String State)
        {
            this.State = State;
            return this;
        }

        public ItemDTO_Builder WithState(int ItemQuantity)
        {
            this.State = ItemStateFactory.Create(ItemQuantity).ToString();
            return this;
        }
    }
}
