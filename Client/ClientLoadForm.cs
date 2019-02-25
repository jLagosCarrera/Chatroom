using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientLoadForm : Form
    {
        public ClientLoadForm()
        {
            InitializeComponent();
            ServerConnection.serverLanguage = 0;
        }

        private void ClientLoadForm_Load(object sender, EventArgs e)
        {
            RefreshStrings();
            this.Icon = Properties.Resources.clientIco;
        }

        //Refreshes all strings in the form when its loaded and when language is changed.
        private void RefreshStrings()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(ServerConnection.languages[ServerConnection.serverLanguage]);
            languageCb.Items.Clear();
            languageCb.Items.Add(Properties.strings.english);
            languageCb.Items.Add(Properties.strings.spanish);
            languageCb.SelectedIndex = ServerConnection.serverLanguage;

            this.Text = Properties.strings.serverClient;
            this.nameLbl.Text = Properties.strings.name + ":";
            this.ipportLbl.Text = Properties.strings.ipport + ":";
            this.ipTxt.Text = "127.0.0.1";
            this.infoTxt.Text = Properties.strings.info;
            this.btnConnect.Text = Properties.strings.connect;
        }

        private void LanguageCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if (cb.SelectedIndex != ServerConnection.serverLanguage)
            {
                ServerConnection.serverLanguage = cb.SelectedIndex;
                RefreshStrings();
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            bool allOk = true;

            if (string.IsNullOrWhiteSpace(this.nameTxt.Text))
            {
                MessageBox.Show(Properties.strings.enterName, Properties.strings.error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                allOk = false;
            }

            if (!IsValidIp(ipTxt.Text))
            {
                MessageBox.Show(Properties.strings.invalidIp, Properties.strings.error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                allOk = false;
            }

            if (allOk)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool IsValidIp(string ip)
        {
            IPAddress address;
            if (IPAddress.TryParse(ip, out address))
            {
                switch (address.AddressFamily)
                {
                    case System.Net.Sockets.AddressFamily.InterNetwork:
                        return true;
                    default:
                        return false;
                }
            }
            return false;
        }

        //Kinda weirdo but it works, handles closing only when pressing X.
        private void ClientLoadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                DialogResult res = MessageBox.Show(
                        Properties.strings.closing, Properties.strings.closingTitle,
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
    }
}