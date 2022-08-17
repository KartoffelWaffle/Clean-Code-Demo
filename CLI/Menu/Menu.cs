using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Menu
{
    class Menu : MenuElement
    {
        private List<MenuElement> children;

        public Menu(string text) : base(-1, text)
        {
            children = new List<MenuElement>();
        }

        public void Add(MenuElement menuElement)
        {
            children.Add(menuElement);
        }

        public override void Print(string indent)
        {
            Console.WriteLine("\n{0}{1}", indent, Text);
            Console.WriteLine("{0}{1}", indent, "".PadLeft(Text.Length, '='));

            foreach (MenuElement item in children)
            {
                item.Print(indent + "    ");
            }
        }
    }
}
