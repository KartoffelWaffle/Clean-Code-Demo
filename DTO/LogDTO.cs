using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace DTO
{
    [Serializable]
    public class LogDTO : IDTO
    {
        public int TransactionID { get; }
        public string TypeOfTransaction { get; }
        public ItemDTO Item { get; }
        public DateTime DateAdded { get; }
        public int ItemQuantity { get; }

        public LogDTO(int TransactionID, string Type, int ItemQuantity, ItemDTO I, DateTime DateAdded)
        {
            this.TransactionID = TransactionID;
            this.TypeOfTransaction = Type;
            this.Item = I;
            this.DateAdded = DateAdded;
            this.ItemQuantity = ItemQuantity;
        }
    }
}
