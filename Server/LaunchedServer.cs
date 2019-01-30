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
        public LaunchedServer(string welcomeMessage, int port)
        {
            InitializeComponent();

        }
        private void LaunchedServer_Load(object sender, EventArgs e)
        {
            RefreshStrings();
            this.Icon = Properties.Resources.serverIco;
        }

        //Refreshes all strings in the form when its loaded and when language is changed
        private void RefreshStrings()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Server.languages[Server.language]);
            languageCb.Items.Clear();
            languageCb.Items.Add(Properties.strings.english);
            languageCb.Items.Add(Properties.strings.spanish);
            languageCb.SelectedIndex = Server.language;

            this.Text = Properties.strings.chatroomTitle;
        }
    }
}
