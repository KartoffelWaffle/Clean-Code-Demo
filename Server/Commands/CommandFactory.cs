using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
    class CommandFactory
    {
        public Command CreateCommand(int menuChoice, string data)
        {
            switch (menuChoice)
            {
                case IRequestUsecase.INITIALISE_DATABASE:
                    return new InitialiseDatabaseCommand(data);

                case IRequestUsecase.ADD_NEW_ITEM:
                    return new AddItemToStockCommand(data);

                case IRequestUsecase.ADD_TO_STOCK:
                    return new AddQuantityToItemCommand(data);

                case IRequestUsecase.TAKE_FROM_STOCK:
                    return new TakeQuantityFromItemCommand(data);

                case IRequestUsecase.DISPLAY_INVENTORY_REPORT:
                    return new ViewInventoryReportCommand(data);

                case IRequestUsecase.DISAPLY_FINANCIAL_REPORT:
                    return new ViewFinancialReportCommand(data);

                case IRequestUsecase.DISPLAY_TRANSACTION_LOG:
                    return new ViewTransactionLogCommand(data);

                case IRequestUsecase.DISPLAY_PERSONAL_USAGE_REPORT:
                    return new ViewPersonalUsageReportCommand(data);

                default:
                    return new NullCommand();
            }
        }
    }
}
