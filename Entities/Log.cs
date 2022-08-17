using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Log : IEntity
    {
        public int TransactionID { get; }
        public string TypeOfTransaction { get; }
        public int ItemQuantity { get; }
        public Item Item { get; }
        public DateTime DateAdded { get; }

        public Log(int TransactionID, string Type, int ItemQuantity, Item I, DateTime DateAdded)
        {
            this.TransactionID = TransactionID;
            this.TypeOfTransaction = Type;
            this.ItemQuantity = ItemQuantity;
            this.Item = I;
            this.DateAdded = DateAdded;
        }
    }
}
