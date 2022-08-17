using CLI.Presenters;
using Controllers;
using DTO;
using DTO.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using Usecases;

namespace CLI.Commands
{
    public class InitialiseDatabaseCommand : Command
    {
        public InitialiseDatabaseCommand()
        {
            
        }

        public void Execute()
        {
            InitialiseDatabaseController controller =
                new InitialiseDatabaseController(
                        new MessageSenderPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            ConsoleWriter.WriteStrings(data.ViewData);
        }
    }
}
