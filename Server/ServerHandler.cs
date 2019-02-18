using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static int serverLanguage;
        public static string[] languages = { "en-UK", "es-ES" };

        //Properties
        readonly object serverLocker = new object();
        public ObservableCollection<ClientHandler> connectedClients = new ObservableCollection<ClientHandler>();
        Thread serverThread;

        public string WelcomeMessage { private set; get; }
        public int Port { private set; get; }
        public int ClientNumber { private set; get; }
        public bool ServerWorking { set; get; }

        //Output and input for server.
        public TextBox OutputTextbox { private set; get; }
        public TextBox InputTextbox { private set; get; }
        public ListView ClientsListView { private set; get; }

        IPEndPoint serverIep;
        Socket serverSocket;

        //Way to trick Windows Forms to write in the Output Textbox.
        delegate void TextDelegate(string text, TextBox t);
        TextDelegate txtDelegate;
        private void ChangeText(string text, TextBox t)
        {
            t.AppendText(text + Environment.NewLine);
        }
        
        //Way to trick Windows Forms to add in the ListView.
        delegate void listAddDelegate(string text, int listIndex, int imgIndex, ListView l);
        listAddDelegate lstAddDelegate;
        private void AddList(string text, int listIndex, int imgIndex, ListView l)
        {
            l.Items.Add(text);
            l.Items[listIndex].ImageIndex = imgIndex;
        }

        //Way to trick Windows Forms to clear the ListView.
        delegate void listClearDelegate(ListView l);
        listClearDelegate lstClearDelegate;
        private void ClearList(ListView l)
        {
            l.Clear();
        }

        //Constructor, just initializes values.
        public ServerHandler(bool serverWorking, string welcomeMessage, int port, int clientNumber,
            TextBox outputTextbox, TextBox inputTextbox, ListView clientsListView)
        {
            ServerWorking = serverWorking;
            WelcomeMessage = welcomeMessage;
            Port = port;
            ClientNumber = clientNumber;

            connectedClients.CollectionChanged += ConnectedClient_CollectionChanged;

            OutputTextbox = outputTextbox;
            InputTextbox = inputTextbox;
            ClientsListView = clientsListView;
            
            txtDelegate = new TextDelegate(ChangeText);
            lstAddDelegate = new listAddDelegate(AddList);
            lstClearDelegate = new listClearDelegate(ClearList);
            serverThread = new Thread(ServerListening);
            serverThread.IsBackground = true;
        }

        //Server thread function.
        private void ServerListening()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverIep = new IPEndPoint(IPAddress.Any, Port);

            serverSocket.Bind(serverIep);
            serverSocket.Listen(ClientNumber);

            OutputTextbox.BeginInvoke(txtDelegate,
                "-- " + Properties.strings.chatroomTitle
                + " " + Properties.strings.listeningAtPort + " " + Port,
                OutputTextbox);

            while (ServerWorking)
            {
                ClientHandler client = new ClientHandler(serverSocket.Accept(), this);
                lock (serverLocker)
                    if (ServerWorking)
                        connectedClients.Add(client);

            }
        }

        //Writes on the output textbox.
        private void WriteOnOutput(string message)
        {
            if (ServerWorking)
                OutputTextbox.BeginInvoke(txtDelegate, message, OutputTextbox);
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
                                client.ClientWriter.WriteLine(message);
                                client.ClientWriter.Flush();
                            }
                            catch (IOException) { }
                        }
                    }
                }
            }
        }

        public void List(ClientHandler client)
        {
            client.ClientWriter.WriteLine("-- " + Properties.strings.connectedClients + ":");
            client.ClientWriter.Flush();

            lock (serverLocker)
            {
                if (ServerWorking)
                {
                    if (connectedClients.Count > 0)
                    {
                        for (int i = connectedClients.Count - 1; i >= 0; i--)
                        {
                            client.ClientWriter.WriteLine("\t--" + connectedClients[i].Name + "@" + connectedClients[i].ClientIep.Address);
                            client.ClientWriter.Flush();
                        }
                    }
                }
                else
                {
                    client.ClientWriter.WriteLine(Properties.strings.alone);
                    client.ClientWriter.Flush();
                }
            }
        }

        //Handles message sending from server
        public void BtnSend_Click(object sender, EventArgs e)
        {
            WriteToAllClients("|| " + Properties.strings.server + "@" + serverIep.Address + " >> " + InputTextbox.Text);
            InputTextbox.Clear();
        }

        //Opens server.
        public void OpenServer()
        {
            ServerWorking = true;
            serverThread.Start();
        }

        //Closes server.
        public void CloseServer()
        {
            lock (serverLocker)
            {
                if (ServerWorking)
                {
                    for (int i = connectedClients.Count - 1; i >= 0; i--)
                    {
                        connectedClients[i].CloseConnection();
                    }
                }
            }

            ServerWorking = false;
        }

        //Observable Collection changed method
        private void ConnectedClient_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            lock (serverLocker)
            {
                if (ServerWorking)
                {
                    ClientsListView.BeginInvoke(lstClearDelegate, ClientsListView);
                    for (int i = 0; i < connectedClients.Count; i++)
                    {
                        ClientsListView.BeginInvoke(lstAddDelegate, connectedClients[i].Name + "@" + connectedClients[i].ClientIep.Address, i, 0, ClientsListView);
                    }
                }
            }
        }
    }
}