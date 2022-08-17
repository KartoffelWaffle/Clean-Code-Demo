using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.State
{
    class ItemInStock : I_ItemState
    {
        public bool OutOfStock()
        {
            return false;
        }

        public bool InStock()
        {
            return true;
        }

        public I_ItemState TakeItem(int ItemQuantity)
        {
            if (ItemQuantity < 1)
                return new ItemOutOfStock();
            else return this;
        }

        public override string ToString()
        {
            return "Item In Stock";
        }
    }
}
