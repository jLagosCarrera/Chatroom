﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class ClientHandler
    {
        readonly object clientLocker = new object();

        public ServerHandler ConnectedServer { get; set; }
        public Thread ClientThread { get; set; }
        public Socket ClientSocket { get; set; }
        public IPEndPoint ClientIep { get; set; }

        public NetworkStream ClientStream { get; set; }
        public StreamWriter ClientWriter { get; set; }
        public StreamReader ClientReader { get; set; }

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

        public ClientHandler(Socket clientSocket, ServerHandler connectedServer)
        {
            ConnectedServer = connectedServer;
            ClientThread = new Thread(ClientListening);
            ClientThread.IsBackground = true;

            ClientSocket = clientSocket;
            ClientIep = (IPEndPoint)clientSocket.RemoteEndPoint;

            ClientStream = new NetworkStream(ClientSocket);
            ClientReader = new StreamReader(ClientStream);
            ClientWriter = new StreamWriter(ClientStream);

            ClientConnected = true;

            ClientThread.Start();
        }

        public void CloseConnection()
        {
            lock (clientLocker)
            {
                if (ClientConnected)
                {
                    try
                    {
                        ClientWriter.WriteLine("-- " + Properties.strings.cya);
                        ClientWriter.Flush();

                    }
                    catch (IOException) { }
                    ConnectedServer.WriteToAllClients("-- " + string.Format(Properties.strings.disconnectedClient,
                                    Name + "@" + ClientIep.Address, ClientIep.Port));

                    ClientWriter.Close();
                    ClientReader.Close();
                    ClientStream.Close();
                    ClientSocket.Close();
                    ClientConnected = false;
                    ConnectedServer.connectedClients.Remove(this);
                }
            }
            ConnectedServer.RefreshInfo();
        }

        private void ClientListening()
        {
            string message;

            lock (clientLocker)
            {
                if (ClientConnected)
                {
                    try
                    {
                        ClientWriter.WriteLine("-- " + Properties.strings.motd + ": " + ConnectedServer.WelcomeMessage);
                        ClientWriter.Flush();
                        ClientWriter.Write("-- " + Properties.strings.enterNickname + ": ");
                        ClientWriter.Flush();
                    }
                    catch (IOException) { }
                }
            }
            try
            {
                do
                {
                    string name = ClientReader.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        lock (clientLocker)
                        {
                            if (ClientConnected)
                            {
                                ClientWriter.Write("-- " + Properties.strings.enterNickname + ": ");
                                ClientWriter.Flush();
                            }
                        }
                    }
                    else
                    {
                        Name = name;
                    }

                } while (string.IsNullOrWhiteSpace(name));
            }
            catch (IOException) { }

            ConnectedServer.RefreshInfo();

            ConnectedServer.WriteToAllClients("-- " + string.Format(Properties.strings.connectedWithClient,
                Name + "@" + ClientIep.Address, ClientIep.Port));

            lock (clientLocker)
            {
                if (ClientConnected)
                {
                    try
                    {
                        ClientWriter.WriteLine("-- " + Properties.strings.commands);
                        ClientWriter.Flush();
                    }
                    catch (IOException) { }
                }
            }

            while (ClientConnected)
            {
                try
                {
                    message = ClientReader.ReadLine();
                    if (message != null)
                    {
                        //Handles available commands
                        if (!string.IsNullOrWhiteSpace(message))
                        {
                            if (message[0] == '#')
                            {
                                if (message == Properties.strings.exit)
                                {
                                    lock (clientLocker)
                                        if (ClientConnected)
                                            CloseConnection();
                                }
                                else if (message == Properties.strings.list)
                                {
                                    lock (clientLocker)
                                        if (ClientConnected)
                                            ConnectedServer.List(this);
                                }
                                else if (message == Properties.strings.cmd)
                                {
                                    lock (clientLocker)
                                    {
                                        if (ClientConnected)
                                        {
                                            ClientWriter.WriteLine("-- " + Properties.strings.availableCommands + ": ");
                                            ClientWriter.Flush();
                                            ClientWriter.WriteLine("\t-- " + Properties.strings.cmd + ": " + Properties.strings.cmdInfo);
                                            ClientWriter.Flush();
                                            ClientWriter.WriteLine("\t-- " + Properties.strings.exit + ": " + Properties.strings.exitInfo);
                                            ClientWriter.Flush();
                                            ClientWriter.WriteLine("\t-- " + Properties.strings.list + ": " + Properties.strings.listInfo);
                                            ClientWriter.Flush();
                                        }
                                    }
                                }
                                else
                                {
                                    lock (clientLocker)
                                    {
                                        if (ClientConnected)
                                        {
                                            ClientWriter.WriteLine("-- " + Properties.strings.unknownCmd);
                                            ClientWriter.Flush();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ConnectedServer.WriteToAllClients("|| " + Name + "@" + ClientIep.Address + " >> " + message);
                            }
                        }
                        else
                        {
                            lock (clientLocker)
                            {
                                if (ClientConnected)
                                {
                                    ClientWriter.WriteLine("-- " + Properties.strings.enterMessage);
                                    ClientWriter.Flush();
                                }
                            }
                        }
                    }
                    else
                    {
                        CloseConnection();
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