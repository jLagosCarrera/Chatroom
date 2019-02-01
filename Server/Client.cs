using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        public Socket ClientSocket { get; set; }
        public StreamWriter ClientWriter { get; set; }
        public IPEndPoint IeClient { get; set; }
        public string Name { get; set; }

        public Client(Socket s)
        {
            ClientSocket = s;
        }
    }
}
