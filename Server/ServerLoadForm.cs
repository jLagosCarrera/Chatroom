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
    public partial class ServerLoadForm : Form
    {
        int language;
        string[] languages = { "en-UK", "es-ES" };

        public ServerLoadForm()
        {
            InitializeComponent();
            language = 0;
        }

        private void ServerLoadForm_Load(object sender, EventArgs e)
        {
            RefreshStrings();
            this.Icon = Properties.Resources.serverIco;
        }

        //Refreshes all strings in the form when its loaded and when language is changed
        private void RefreshStrings()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(languages[language]);
            languageCb.Items.Clear();
            languageCb.Items.Add(Properties.strings.english);
            languageCb.Items.Add(Properties.strings.spanish);

            this.Text = Properties.strings.chatroomTitle;
            this.welcomeLbl.Text = Properties.strings.welcome + ":";
            this.portLbl.Text = Properties.strings.port + ":";
            this.languageLbl.Text = Properties.strings.language + ":";
            this.startBtn.Text = Properties.strings.start;
            this.infoTxt.Text = Properties.strings.info;
        }

        private void LanguageCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if (cb.SelectedIndex != language)
            {
                language = cb.SelectedIndex;
                RefreshStrings();
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
