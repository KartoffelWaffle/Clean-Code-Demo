using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    class ConsoleReader
    {
        public static int ReadInt(string prompt)
        {
            try
            {
                Console.Write(prompt + ": > ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static string ReadString(string prompt)
        {
            try
            {
                Console.Write(prompt + ": > ");
                return Convert.ToString(Console.ReadLine());
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static float ReadFloat(string prompt)
        {
            try
            {
                Console.Write(prompt + ": > ");
                return (float) Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
