using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Builder
{
    public class LogDTO_Builder
    {
        private int TransactionID;
        private string TypeOfTransaction;
        private int ItemQuantity;
        private ItemDTO Item;
        private DateTime DateAdded;
        Random rnd = new Random();

        public LogDTO_Builder()
        {
            this.TransactionID = rnd.Next();
            this.TypeOfTransaction = "";
            this.ItemQuantity = -1;
            this.Item = null;
            this.DateAdded = DateTime.Now;

        }

        public LogDTO Build()
        {
            return new LogDTO(TransactionID, TypeOfTransaction, ItemQuantity, Item, DateAdded);
        }

        public LogDTO_Builder WithTransactionID(int TransactionID) 
        {
            this.TransactionID = TransactionID;
            return this;
        }

        public LogDTO_Builder WithTypeOfTransaction(string TypeOfTransaction)
        {
            this.TypeOfTransaction = TypeOfTransaction;
            return this;
        }

        public LogDTO_Builder WithItemQuantity(int ItemQuantity)
        {
            this.ItemQuantity = ItemQuantity;
            return this;
        }

        public LogDTO_Builder WithItem(ItemDTO ItemDTO) 
        {
            this.Item = ItemDTO;
            return this;
        }

        public LogDTO_Builder WithDateAdded(DateTime DateAdded)
        {
            this.DateAdded = DateAdded;
            return this;
        }
    }
}
