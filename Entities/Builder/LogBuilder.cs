using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Builder
{
    public class LogBuilder
    {
        private int TransactionID;
        private string TypeOfTransaction;
        private Item Item;
        private DateTime DateAdded;
        private int ItemQuantity;

        public LogBuilder()
        {
            this.TransactionID = -1;
            this.TypeOfTransaction = "";
            this.ItemQuantity = -1;
            this.Item = null;
            this.DateAdded = DateTime.MinValue;

        }

        public Log Build()
        {
            return new Log(TransactionID, TypeOfTransaction, ItemQuantity, Item, DateAdded);
        }

        public LogBuilder WithTransactionID(int TransactionID) 
        {
            this.TransactionID = TransactionID;
            return this;
        }

        public LogBuilder WithTypeOfTransaction(string TypeOfTransaction)
        {
            this.TypeOfTransaction = TypeOfTransaction;
            return this;
        }

        public LogBuilder WithItem(Item Item)
        {
            this.Item = Item;
            return this;
        }

        public LogBuilder WithItemQuantity(int ItemQuantity)
        {
            this.ItemQuantity = ItemQuantity;
            return this;
        }

        public LogBuilder WithDateAdded(DateTime DateAdded)
        {
            this.DateAdded = DateAdded;
            return this;
        }
    }
}
