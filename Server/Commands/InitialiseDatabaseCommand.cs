using Server.Presenters;
using Controllers;
using DTO;
using DTO.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using Usecases;

namespace Server.Commands
{
    public class InitialiseDatabaseCommand : Command
    {
        private string data;

        public InitialiseDatabaseCommand(string data)
        {
            this.data = data;
        }

        public List<string> Execute()
        {
            InitialiseDatabaseController controller =
                new InitialiseDatabaseController(
                        new MessageSenderPresenter());

            CommandLineViewData data =
                (CommandLineViewData)controller.Execute();

            return data.ViewData;
        }
    }
}
