using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Job
    {
        public ClientService client;
        public string msg;
        public Job job;

        public Job(ClientService client, string msg, Job job = null)
        {
            this.client = client;
            this.msg = msg;
            this.job = job;
        }
    }
}
