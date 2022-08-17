using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.State
{
    public interface I_ItemState
    {
        bool InStock();

        bool OutOfStock();

        I_ItemState TakeItem(int ItemQuantity);

    }
}
