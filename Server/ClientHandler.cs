using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class ClientHandler
    {
        public ServerHandler AsociatedServer { get; set; }
        public Thread ClientTh { get; set; }
        public Socket Socket { get; set; }
        public IPEndPoint Iep { get; set; }

        public NetworkStream Stream { get; set; }
        public StreamWriter Writer { get; set; }
        public StreamReader Reader { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                IsNameSet = true;
            }
        }
        public bool IsNameSet { get; set; }
        public bool ClientConnected { set; get; }

        public ClientHandler(Socket s, ServerHandler asociatedServer)
        {
            AsociatedServer = asociatedServer;
            ClientTh = new Thread(ClientListening);
            ClientTh.IsBackground = true;

            Socket = s;
            Iep = (IPEndPoint)s.RemoteEndPoint;

            Stream = new NetworkStream(Socket);
            Reader = new StreamReader(Stream);
            Writer = new StreamWriter(Stream);

            ClientConnected = true;

            ClientTh.Start();
        }

        public void CloseConnection()
        {
            Writer.Close();
            Reader.Close();
            Stream.Close();
            Socket.Close();
            ClientConnected = false;
            AsociatedServer.connectedClients.Remove(this);

        }

        private void ClientListening()
        {
            string message;

            Writer.WriteLine(AsociatedServer.WelcomeMessage);
            Writer.Flush();
            Writer.Write(Properties.strings.enterNickname + ": ");
            Writer.Flush();
            try
            {
                Name = Reader.ReadLine();
            }
            catch (IOException)
            {
            }

            AsociatedServer.WriteToAllClients(string.Format(Properties.strings.connectedWithClient,
                Name + "@" + Iep.Address, Iep.Port));

            while (ClientConnected)
            {
                try
                {
                    message = Reader.ReadLine();
                    System.Console.WriteLine(message);

                    if (message != null)
                        //Handle same things that you can do in GUI client for console telnet.
                        if (message == Properties.strings.exit)
                        {
                            ClientConnected = false;
                        }
                        else if (message == Properties.strings.list)
                        {
                            AsociatedServer.ConsoleList(this);
                        } else
                        {
                            AsociatedServer.WriteToAllClients("|| " + Name + "@" + Iep.Address + " >> " + message);
                        }
                    else
                    {
                        AsociatedServer.WriteToAllClients(string.Format(Properties.strings.disconnectedClient,
                            Name + "@" + Iep.Address, Iep.Port));
                    }
                }
                catch (IOException)
                {
                    break;
                }

            }

            CloseConnection();
        }
    }
}
