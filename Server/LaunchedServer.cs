using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class LaunchedServer : Form
    {
        string WelcomeMessage { set; get; }
        int Port { set; get; }

        public LaunchedServer(string welcomeMessage, int port)
        {
            WelcomeMessage = welcomeMessage;
            Port = port;
            InitializeComponent();

        }
        private void LaunchedServer_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.serverIco;
            this.Text = Properties.strings.chatroomTitle + " " + Properties.strings.hostedAtPort + " " + Port;
        }
    }
}
