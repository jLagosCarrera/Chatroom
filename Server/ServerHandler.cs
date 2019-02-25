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
        public List<ClientHandler> connectedClients = new List<ClientHandler>();
        Thread serverThread;

        public string WelcomeMessage { private set; get; }
        public int Port { private set; get; }
        public int ClientNumber { private set; get; }
        public bool ServerWorking { set; get; }
        private ClientHandler SelectedClient { set; get; }

        //Output and input for server.
        public TextBox OutputTextbox { private set; get; }
        public TextBox InputTextbox { private set; get; }
        public ListView ClientsListView { private set; get; }
        public Form ServerForm { private set; get; }

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
        delegate void listAddDelegate(ClientHandler c, int listIndex, int imgIndex, ListView l);
        listAddDelegate lstAddDelegate;
        private void AddList(ClientHandler c, int listIndex, int imgIndex, ListView l)
        {
            lock (serverLocker)
            {
                if (ServerWorking)
                {
                    l.Items.Insert(listIndex, c.Name + "@" + c.ClientIep.Address + ":" + c.ClientIep.Port);
                    l.Items[listIndex].Tag = c;
                    l.Items[listIndex].ImageIndex = imgIndex;
                }
            }
        }

        //Way to trick Windows Forms to delete in the ListView.
        delegate void listDelDelegate(ClientHandler c, ListView l);
        listAddDelegate lstDelDelegate;
        private void DelList(ClientHandler c, ListView l)
        {
            lock (serverLocker)
            {
                if (ServerWorking)
                {
                    for (int i = connectedClients.Count - 1; i >= 0; i--)
                    {
                        if (c == (ClientHandler)l.Items[i].Tag)
                        {
                            l.Items.RemoveAt(i);
                        }
                    }
                }
            }
        }

        //Way to trick Windows Forms to clear the ListView.
        delegate void listClearDelegate(ListView l);
        listClearDelegate lstClearDelegate;
        private void ClearList(ListView l)
        {
            lock (serverLocker)
            {
                if (ServerWorking)
                {
                    l.Clear();
                }
            }
        }

        //Constructor, just initializes values.
        public ServerHandler(bool serverWorking, string welcomeMessage, int port, int clientNumber,
            TextBox outputTextbox, TextBox inputTextbox, ListView clientsListView, Form serverForm)
        {
            ServerWorking = serverWorking;
            WelcomeMessage = welcomeMessage;
            Port = port;
            ClientNumber = clientNumber;

            OutputTextbox = outputTextbox;
            InputTextbox = inputTextbox;
            ClientsListView = clientsListView;
            ServerForm = serverForm;
            SelectedClient = null;

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
                RefreshListView();
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

        //Lists all connected clients in console
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
                            try
                            {
                                client.ClientWriter.WriteLine("\t--" + connectedClients[i].Name + "@" + connectedClients[i].ClientIep.Address);
                                client.ClientWriter.Flush();
                            }
                            catch (IOException) { }
                        }
                    }
                }
                else
                {
                    try
                    {
                        client.ClientWriter.WriteLine(Properties.strings.alone);
                        client.ClientWriter.Flush();
                    }
                    catch (IOException) { }
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
            KickAllClients();
            ServerWorking = false;
        }

        //Refreshes ListView with all conected clients
        public void RefreshListView()
        {
            lock (serverLocker)
            {
                if (ServerWorking)
                {
                    ClientsListView.BeginInvoke(lstClearDelegate, ClientsListView);
                    for (int i = 0; i < connectedClients.Count; i++)
                    {
                        ClientsListView.BeginInvoke(lstAddDelegate, connectedClients[i], i, 0, ClientsListView);
                    }
                }
            }
        }

        private void KickAllClients()
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
        }

        public void ClientsLView_SelectedIndexChanged(object sender, EventArgs e)
        {
            lock (serverLocker)
            {
                if (ServerWorking)
                {
                    ListView list = (ListView)sender;
                    int selectedIndex = 0;
                    foreach (int i in list.SelectedIndices)
                    {
                        selectedIndex = i;
                    }
                    ClientHandler c = (ClientHandler)list.Items[selectedIndex].Tag;
                    SelectedClient = c;
                }
            }
        }

        public void BtnKick_Click(object sender, EventArgs e)
        {
            if (SelectedClient == null)
            {
                MessageBox.Show(Properties.strings.selectAClient, Properties.strings.selectSomething, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ClientsListView.BeginInvoke(lstDelDelegate, SelectedClient, ClientsListView);
                SelectedClient.CloseConnection();
                SelectedClient = null;
            }
        }

        public void BtnKickAll_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show(Properties.strings.uSure, Properties.strings.kickAll, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (res == DialogResult.Yes)
            {
                KickAllClients();
            }
        }

        public void BtnClose_Click(object sender, EventArgs e)
        {
            ServerForm.Close();
        }
    }
}