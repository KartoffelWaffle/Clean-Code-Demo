using Server.Commands;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    delegate void RemoveClient(ClientService c);
    delegate void BroadcastMessage(string message);
    delegate void AddJob(Job job);

    class MyServer
    {
        private TcpListener tcpListener;
        private List<ClientService> clientServices;
        private BlockingCollection<Job> jobList;
        int ipdi = 0;
        int ipdo = 0;

        public MyServer()
        {
            IPAddress ipAddress = IPAddress.Loopback;
            tcpListener = new TcpListener(ipAddress, 4444);
            clientServices = new List<ClientService>();
            jobList = new BlockingCollection<Job>();
            Console.WriteLine("Listening....");
        }

        public void Start()
        {
           tcpListener.Start();

            List<string> str = new CommandFactory()
                                 .CreateCommand(IRequestUsecase.INITIALISE_DATABASE, "")
                                 .Execute();

           Console.WriteLine(str[0]);

           Timer t = new Timer(BroadcastTime);
           t.Change(3000, 5000);

            while (true)
            {
                Socket s = tcpListener.AcceptSocket();  //blocks until a connection is made
                ClientService clientService = new ClientService(s, RemoveClient, AddJob);
                clientServices.Add(clientService);
                clientService.NewUserAnounce();
                Task.Run(ExecuteJobs);
                Task.Run(clientService.InteractWithClient);
            }
        }

        public void Stop()
        {
            tcpListener.Stop();
        }

        private void RemoveClient(ClientService c)
        {
            //Console.WriteLine("REMOVING CLIENT");
            clientServices.Remove(c);
        }

        private void BroadcastTime(object state)
        {
            string msg = string.Format(
                        "{0}: The time is {1}",
                        tcpListener.LocalEndpoint.ToString(),
                        DateTime.Now.ToString("HH:mm:ss"));

            Console.WriteLine(msg);
        }

        private void BroadcastMessage(Job job)
        {
            if (clientServices.Count > 0)
            {
                Console.WriteLine("Jobs in: " + ipdi);
                Console.WriteLine("Jobs out: " + ipdo);
                Console.WriteLine();

                job.client.BroadCastMessage(job.msg);
            }
            else
            {
                Console.WriteLine("NOT BROADCASTING BECAUSE NO CLIENTS");
            }
        }

        public void ExecuteJobs()
        {
            while (clientServices.Count > 0)
            {
                Job job;
                if (jobList.TryTake(out job))
                {
                    ipdo++;
                    BroadcastMessage(job);
                }
            }
        }

        public void AddJob(Job job)
        {
            jobList.TryAdd(job);
            ipdi++;
        }
    }
}
