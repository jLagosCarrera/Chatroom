using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{

    public partial class LaunchedServer : Form
    {
        //Tricking WinForms for using Controls from another thread.
        delegate void anDelegate(string text, TextBox t);
        private void ChangeText(string text, TextBox t)
        {
            t.AppendText(text + Environment.NewLine);
        }

        //Dialog result for handling closing with X in this form.
        DialogResult startRes;

        //Server properties
        IPEndPoint ie;
        Socket s;
        List<Client> clients;
        bool ServerWorking { set; get; }
        string WelcomeMessage { set; get; }
        int Port { set; get; }
        int ClientNumber { set; get; }

        public LaunchedServer()
        {
            InitializeComponent();

            //Starts modal for configuring server
            ServerLoadForm slf = new ServerLoadForm();
            startRes = slf.ShowDialog();

            if (startRes == DialogResult.OK)
            {
                WelcomeMessage = slf.welcomeTxt.Text;
                Port = Convert.ToInt32(slf.portNumeric.Value);
                ClientNumber = Convert.ToInt32(slf.clientsNumeric.Value);
                ServerWorking = true;
                clients = new List<Client>();

                slf.Dispose();
                slf = null;
            }
        }

        private void LaunchedServer_Load(object sender, EventArgs e)
        {
            if (startRes == DialogResult.OK)
            {
                notifyIcon.Icon = Properties.Resources.serverIco;
                notifyIcon.Text = Properties.strings.chatroomTitle + " " + Properties.strings.running;

                this.Icon = Properties.Resources.serverIco;
                this.Text = Properties.strings.chatroomTitle + " " + Properties.strings.hostedAtPort + " " + Port;
                this.chatGb.Text = Properties.strings.chat;
                this.btnSend.Text = Properties.strings.send;
                this.clientsGb.Text = Properties.strings.clients;
                this.optionsGb.Text = Properties.strings.options;
                this.ipLbl.Text = Properties.strings.ip;
                this.portLbl.Text = Properties.strings.assignedPort;
                this.nameLbl.Text = Properties.strings.name;
                this.btnKick.Text = Properties.strings.kick;
                this.btnKickAll.Text = Properties.strings.kickAll;
                this.btnClose.Text = Properties.strings.close;

                Thread serverTh = new Thread(ServerListening);
                serverTh.Start();
            }
            else
            {
                this.Close();
            }
        }

        private void LaunchedServer_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void LaunchedServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (startRes == DialogResult.OK)
            {
                DialogResult res = MessageBox.Show(
                        Properties.strings.closing, Properties.strings.closingTitle,
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void ServerListening()
        {
            anDelegate d = new anDelegate(ChangeText);

            ie = new IPEndPoint(IPAddress.Any, Port);
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(ie);
            s.Listen(ClientNumber);

            this.Invoke(d, Properties.strings.chatroomTitle + " " + Properties.strings.listeningAtPort + " " + Port, chatTxt);
            while (ServerWorking)
            {
                Client client = new Client(s.Accept());
                clients.Add(client);
                Thread clientTh = new Thread(ClientHandler);
                clientTh.Start(client);
            }
        }

        private void ClientHandler(object client)
        {

            string message;
            Client castedClient = (Client)client;
            IPEndPoint ieClient = (IPEndPoint)castedClient.ClientSocket.RemoteEndPoint;

            NetworkStream ns = new NetworkStream(castedClient.ClientSocket);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            castedClient.ClientWriter = sw;
            sw.WriteLine(WelcomeMessage);
            sw.Flush();
            sw.Write(Properties.strings.enterNickname + ": ");
            sw.Flush();
            castedClient.Name = sr.ReadLine();
            
            WriteToAll(string.Format(Properties.strings.connectedWithClient, castedClient.Name + "@" + ieClient.Address, ieClient.Port));

            while (ServerWorking)
            {
                try
                {
                    message = sr.ReadLine();

                    if (message != null)
                    {
                        WriteToAll(castedClient.Name + "@" + ieClient.Address + " >> " + message);
                    }
                }
                catch (IOException)
                {
                    break;
                }
            }

            sw.Close();
            sr.Close();
            ns.Close();
            castedClient.ClientSocket.Close();
            clients.Remove(castedClient);

            WriteToAll(string.Format(Properties.strings.disconnectedClient, castedClient.Name + "@" + ieClient.Address, ieClient.Port));
        }

        private void WriteToAll(string message)
        {
            anDelegate d = new anDelegate(ChangeText);
            this.Invoke(d, message, chatTxt);

            foreach (Client c in clients)
            {
                c.ClientWriter.WriteLine(message);
                c.ClientWriter.Flush();
            }
        }
    }
}
