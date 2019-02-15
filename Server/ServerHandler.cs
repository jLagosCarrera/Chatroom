using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    class ServerHandler
    {
        //Static Values
        public static int language;
        public static string[] languages = { "en-UK", "es-ES" };

        //Properties
        readonly object serverLocker = new object();
        public List<ClientHandler> connectedClients = new List<ClientHandler>();
        Thread serverTh;


        public string WelcomeMessage { private set; get; }
        public int Port { private set; get; }
        public int ClientNumber { private set; get; }
        public bool ServerWorking { set; get; }

        //Output and input for server.
        public TextBox OutputTextbox { private set; get; }
        public TextBox InputTextbox { private set; get; }

        IPEndPoint ie;
        Socket s;

        //Way to trick Windows Forms to write in the Output Textbox.
        delegate void anDelegate(string text, TextBox t);
        anDelegate d;
        private void ChangeText(string text, TextBox t)
        {
            t.AppendText(text + Environment.NewLine);
        }

        //Constructor, just initializes values.
        public ServerHandler(bool serverWorking, string welcomeMessage, int port, int clientNumber, TextBox outputTextbox, TextBox inputTextbox)
        {
            ServerWorking = serverWorking;
            WelcomeMessage = welcomeMessage;
            Port = port;
            ClientNumber = clientNumber;

            OutputTextbox = outputTextbox;
            InputTextbox = inputTextbox;

            d = new anDelegate(ChangeText);
            serverTh = new Thread(ServerListening);
            serverTh.IsBackground = true;
        }

        //Server thread function.
        private void ServerListening()
        {
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ie = new IPEndPoint(IPAddress.Any, Port);

            s.Bind(ie);
            s.Listen(ClientNumber);

            OutputTextbox.BeginInvoke(d,
                "|| " + Properties.strings.serverInfo + " >> " + Properties.strings.chatroomTitle
                + " " + Properties.strings.listeningAtPort + " " + Port,
                OutputTextbox);

            while (ServerWorking)
            {
                ClientHandler client = new ClientHandler(s.Accept(), this);
                connectedClients.Add(client);

            }
        }

        //Writes on the output textbox.
        private void WriteOnOutput(string message)
        {
            if (ServerWorking)
                OutputTextbox.BeginInvoke(d, message, OutputTextbox);
        }

        //Writes to all clients.
        public void WriteToAllClients(string message)
        {
            WriteOnOutput(message);


            lock (serverLocker)
            {
                if (ServerWorking)
                {
                    for (int i = connectedClients.Count - 1; i >= 0; i--)
                    {
                        ClientHandler client = connectedClients[i];
                        if (client.IsNameSet)
                        {
                            try
                            {
                                client.Writer.WriteLine(message);
                                client.Writer.Flush();
                            }
                            catch (IOException) { }
                        }
                    }
                }
            }
        }

        public void ConsoleList(ClientHandler c)
        {
            c.Writer.WriteLine(Properties.strings.connectedClients + ":");
            c.Writer.Flush();

            if (connectedClients.Count > 1)
            {
                for (int i = connectedClients.Count - 1; i >= 0; i--)
                {
                    if (connectedClients[i] != c)
                    {
                        c.Writer.WriteLine("#" + connectedClients[i].Name + "@" + connectedClients[i].Iep.Address);
                        c.Writer.Flush();
                    }
                }
            }
            else
            {
                c.Writer.WriteLine(Properties.strings.alone);
                c.Writer.Flush();
            }
        }

        //Handles message sending from server
        public void BtnSend_Click(object sender, EventArgs e)
        {
            WriteToAllClients("|| " + Properties.strings.server + "@" + ie.Address + " >> " + InputTextbox.Text);
            InputTextbox.Clear();
        }

        //Opens server.
        public void OpenServer()
        {
            ServerWorking = true;
            serverTh.Start();
        }

        //Closes server.
        public void CloseServer()
        {
            ServerWorking = false;

            lock (serverLocker)
            {
                for (int i = connectedClients.Count - 1; i >= 0; i--)
                {
                    connectedClients[i].CloseConnection();
                }
            }
        }
    }
}