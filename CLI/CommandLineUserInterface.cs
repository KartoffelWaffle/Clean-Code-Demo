using CLI.Commands;
using CLI.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI
{
    public class CommandLineUserInterface
    {
        public CommandLineUserInterface()
        {
        }

        public void Start()
        {
            CommandFactory factory = new CommandFactory();
            try
            {
                factory
                    .CreateCommand(IRequestUsecase.INITIALISE_DATABASE)
                    .Execute();

                MenuFactory.INSTANCE.Create().Print("");
                int choice = GetMenuChoice();

                while (choice != IRequestUsecase.EXIT)
                {
                    factory
                        .CreateCommand(choice)
                        .Execute();

                    MenuFactory.INSTANCE.Create().Print("");
                    choice = GetMenuChoice();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nERROR: " + e.Message);
            }
        }

        private int GetMenuChoice()
        {
            int option = ConsoleReader.ReadInt("\nOption");
            while (option < 1 || option > 8)
            {
                Console.WriteLine("\nChoice not recognised. Please try again");
                option = ConsoleReader.ReadInt("\nOption");
            }
            return option;
        }
    }
}
