using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.State
{
    public class ItemStateFactory
    {
        public static I_ItemState Create(int ItemQuantity)
        {
            if (ItemQuantity > 0)
            {
                return new ItemInStock();
            }
            else
            {
                return new ItemOutOfStock();
            }
        }

        public static I_ItemState Create(string State)
        {
            if (State == "Item In Stock")
            {
                return new ItemInStock();
            }
            else
            {
                return new ItemOutOfStock();
            }
        }
    }
}
