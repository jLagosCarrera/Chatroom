using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        Socket ClientSocket { get; set; }
        string Name { get; set; }

        public Client(Socket s, string name)
        {
            ClientSocket = s;
            Name = name;
        }
    }
}
