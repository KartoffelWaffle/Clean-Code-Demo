using Server.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;

namespace Server
{
    class ClientService
    {

        private Socket socket;
        private NetworkStream stream;
        public StreamReader reader { get; private set; }
        public StreamWriter writer { get; private set; }

        private RemoveClient removeMe;

        private AddJob AddJob;

        public ClientService(Socket socket, RemoveClient rc, AddJob AddJob)
        {
            this.socket = socket;
            removeMe = rc;
            this.AddJob = AddJob;
            stream = new NetworkStream(socket);
            reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            writer = new StreamWriter(stream, System.Text.Encoding.UTF8);
        }

        public void NewUserAnounce()
        {
            Console.WriteLine(string.Format(
                                "{0}: {1}",
                                socket.RemoteEndPoint.ToString(), "New user Connected\n"));
        }
        public void InteractWithClient()
        {
            try
            {
                string clientMessage = reader.ReadLine();
                while (clientMessage != null)
                {
                    int clientCode = Int32.Parse(clientMessage);
                    if (clientCode == 1 || clientCode == 2 || clientCode == 3 || clientCode == 7)
                    {
                        Console.WriteLine("Code" + clientCode);
                        clientMessage = reader.ReadLine();

                    }
                    else
                    {

                        Console.WriteLine("Code" + clientCode);

                        clientMessage = "";
                    }

                    string response =
                            JsonSerializer.Serialize(
                                new CommandFactory()
                                    .CreateCommand(clientCode, clientMessage)
                                    .Execute()
                                    );

                    Job job = new Job(this, response);
                    AddJob(job);

                    clientMessage = reader.ReadLine();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            Console.WriteLine("Goodbye from " + socket.RemoteEndPoint.ToString());
            Close();
        }

        public void Close()
        {
            try
            {
                removeMe(this);
                socket.Shutdown(SocketShutdown.Both);
            }
            finally
            {
                socket.Close();
            }
        }

        public void BroadCastMessage(string message)
        {
            lock (writer)
            {
                writer.WriteLine(message);
                writer.Flush();
            }
        }
    }
}
