using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.State
{
    class ItemOutOfStock : I_ItemState
    {
        public bool OutOfStock()
        {
            return true;
        }

        public bool InStock()
        {
            return false;
        }

        public I_ItemState TakeItem(int ItemQuantity)
        {
            if (ItemQuantity < 0)
                return this;
            else
                return new ItemInStock();
        }

        public override string ToString() 
        {
            return "Item Out of Stock";
        }
    }
}
