using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Menu
{
    class MenuFactory
    {
        public static MenuFactory INSTANCE { get; } = new MenuFactory();

        private Menu menu;

        private MenuFactory()
        {
            menu = CreateMenu();
        }

        public MenuElement Create()
        {
            return menu;
        }

        private Menu CreateMenu()
        {
            Menu menu = new Menu("Menu");

            menu.Add(new MenuItem(IRequestUsecase.ADD_NEW_ITEM,
                                                "Add item to stock"));

            menu.Add(new MenuItem(IRequestUsecase.ADD_TO_STOCK, 
                                                "Add quantity to item"));

            menu.Add(new MenuItem(IRequestUsecase.TAKE_FROM_STOCK, 
                                                "Take quantity from item"));

            menu.Add(new MenuItem(IRequestUsecase.DISPLAY_INVENTORY_REPORT,
                                                "View inventory report"));

            menu.Add(new MenuItem(IRequestUsecase.DISAPLY_FINANCIAL_REPORT, 
                                                "View financial report"));

            menu.Add(new MenuItem(IRequestUsecase.DISPLAY_TRANSACTION_LOG, 
                                                "View transaction log"));

            menu.Add(new MenuItem(IRequestUsecase.DISPLAY_PERSONAL_USAGE_REPORT, 
                                                "View personal usage report"));

            menu.Add(new MenuItem(IRequestUsecase.EXIT, 
                                                "Exit"));

            return menu;
        }
    }
}
