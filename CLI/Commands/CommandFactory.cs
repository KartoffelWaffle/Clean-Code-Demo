using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Commands
{
    class CommandFactory
    {
        public Command CreateCommand(int menuChoice)
        {
            switch (menuChoice)
            {
                case IRequestUsecase.INITIALISE_DATABASE:
                    return new InitialiseDatabaseCommand();

                case IRequestUsecase.ADD_NEW_ITEM:
                    return new AddItemToStockCommand();

                case IRequestUsecase.ADD_TO_STOCK:
                    return new AddQuantityToItemCommand();

                case IRequestUsecase.TAKE_FROM_STOCK:
                    return new TakeQuantityFromItemCommand();

                case IRequestUsecase.DISPLAY_INVENTORY_REPORT:
                    return new ViewInventoryReportCommand();

                case IRequestUsecase.DISAPLY_FINANCIAL_REPORT:
                    return new ViewFinancialReportCommand();

                case IRequestUsecase.DISPLAY_TRANSACTION_LOG:
                    return new ViewTransactionLogCommand();

                case IRequestUsecase.DISPLAY_PERSONAL_USAGE_REPORT:
                    return new ViewPersonalUsageReportCommand();

                default:
                    return new NullCommand();
            }
        }
    }
}
