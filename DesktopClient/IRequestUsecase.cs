using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient
{
    public interface IRequestUsecase
    {
        public const int ADD_NEW_ITEM = 1;
        public const int ADD_TO_STOCK = 2;
        public const int TAKE_FROM_STOCK = 3;
        public const int DISPLAY_INVENTORY_REPORT = 4;
        public const int DISAPLY_FINANCIAL_REPORT = 5;
        public const int DISPLAY_TRANSACTION_LOG = 6;
        public const int DISPLAY_PERSONAL_USAGE_REPORT = 7;
        public const int EXIT = 8;
        public const int INITIALISE_DATABASE = 0;
    }
}
