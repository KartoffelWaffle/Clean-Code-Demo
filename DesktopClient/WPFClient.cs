using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesktopClient
{
    class WPFClient
    {
        public int currentView;

        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private bool clientRunning;

        private ConcurrentQueue<List<string>> messages;
        private BlockingCollection<int> commands;

        private DisplayBroadcastMessage DisplayBroadcastMessage;
        private GetMessageToBroadcast GetMessageToBroadcast;
        private ShowMessage ShowMessage;
        public WPFClient(DisplayBroadcastMessage DisplayBroadcastMessage, GetMessageToBroadcast GetMessageToBroadcast, ShowMessage ShowMessage)
        {
            tcpClient = new TcpClient();
            messages = new ConcurrentQueue<List<string>>();
            commands = new BlockingCollection<int>();
            this.DisplayBroadcastMessage = DisplayBroadcastMessage;
            this.GetMessageToBroadcast = GetMessageToBroadcast;
            this.ShowMessage = ShowMessage;
        }

        public void Run()
        {
            clientRunning = true;

            if (Connect("localhost", 4444))
            {
                Task.Run(ReadFromServer);
                Task.Run(DisplayMessages);

                while (clientRunning)
                {
                    int userInput = commands.Take();

                    string msgToBroadcast = GetMessageToBroadcast();
    
                    WriteToServer(userInput, msgToBroadcast);
                }
            }
            else
            {
                ShowMessage("ERROR: Connection to server not successful");
            }
            tcpClient.Close();
        }

        private bool Connect(string url, int portNumber)
        {
            try
            {
                tcpClient.Connect(url, portNumber);
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
            }
            catch (Exception e)
            {
                ShowMessage("Exception: " + e.Message);
                return false;
            }
            return true;
        }

        private void WriteToServer(int userChoice, string broadcastMessage)
        {
            if (userChoice == -1)
            {
                clientRunning = false;
            }
            else if ((userChoice == 7 || userChoice == 1 || userChoice == 2 || userChoice == 3) && broadcastMessage.Length > 0)
            {
                writer.WriteLine("" + userChoice);
                writer.WriteLine(broadcastMessage);
                writer.Flush();
            }
            else if (userChoice != 10)
            {
                writer.WriteLine("" + userChoice);
                writer.Flush();
            }
        }

        private void ReadFromServer()
        {
            while (clientRunning)
            {
                string[] serverResponse = reader.ReadLine().Split('|');

                List<string> msg = JsonSerializer.Deserialize<List<string>>(serverResponse[0]);
                messages.Enqueue(msg);
            }
        }

        private void DisplayMessages()
        {
            while (clientRunning)
            {
                List<string> msgList;
                if (messages.TryDequeue(out msgList))
                {
                    DisplayBroadcastMessage(msgList);
                }
            }
        }

        public void AddCommand(int command)
        {
            commands.Add(command);
            this.currentView = command;
        }

        public void RapidRequests()
        {
            for (int i = 0; i < 101; i++)
            {
                WriteToServer(2, "1:Pencil:1:Jan");
                WriteToServer(4, "");
                WriteToServer(3, "1:Pencil:1:Jan");
                WriteToServer(5, "");
                Task.Yield();
            }
        }
    }
}
