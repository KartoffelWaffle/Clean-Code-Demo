﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Menu
{
    class MenuItem : MenuElement
    {
        public MenuItem(int id, string text) : base(id, text)
        {

        }

        public override void Print(string indent)
        {
            Console.WriteLine("{0}{1}. {2}", indent, Id, Text);
        }
    }
}
