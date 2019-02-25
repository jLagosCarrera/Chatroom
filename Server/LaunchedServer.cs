using System;
using System.Windows.Forms;

namespace Server
{

    public partial class LaunchedServer : Form
    {
        //Dialog result for closing handling.
        DialogResult startRes;
        ServerHandler server;
                
        public LaunchedServer()
        {
            InitializeComponent();

            //Starts server config modal, if everything is OK then it instantiates the server
            //and sets click event for server message send button.
            ServerLoadForm slf = new ServerLoadForm();
            startRes = slf.ShowDialog();
            if (startRes == DialogResult.OK)
            {
                server = new ServerHandler(false, slf.welcomeTxt.Text,
                    Convert.ToInt32(slf.portNumeric.Value), Convert.ToInt32(slf.clientsNumeric.Value),
                    chatTxt, msgTxt, clientsLView, ipTxt, portTxt, nameTxt, this);
                btnSend.Click += new EventHandler(server.BtnSend_Click);

                slf.Dispose();
                slf = null;
            }

            //Sets ListView properties
            ImageList imgList = new ImageList();
            imgList.Images.Add(Properties.Resources.Client);

            clientsLView.LargeImageList = imgList;
            clientsLView.SmallImageList = imgList;
            clientsLView.StateImageList = imgList;

            //Set events for buttons
            clientsLView.SelectedIndexChanged += new EventHandler(server.ClientsLView_SelectedIndexChanged);
            btnClose.Click += new EventHandler(server.BtnClose_Click);
            btnKickAll.Click += new EventHandler(server.BtnKickAll_Click);
            btnKick.Click += new EventHandler(server.BtnKick_Click);
        }

        private void LaunchedServer_Load(object sender, EventArgs e)
        {
            if (startRes == DialogResult.OK)
            {
                //Sets icon for tray.
                notifyIcon.Icon = Properties.Resources.serverIco;
                notifyIcon.Text = Properties.strings.chatroomTitle + " " + Properties.strings.running;

                //Sets all texts for the selected language.
                this.Icon = Properties.Resources.serverIco;
                this.Text = Properties.strings.chatroomTitle + " " + Properties.strings.hostedAtPort + " " + server.Port;
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

                //Sets server working.
                server.OpenServer();
            }
            else
            {
                this.Close();
            }
        }

        //Hides server form on tray not on taskbar.
        private void LaunchedServer_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        //Double click on hidden icon on tray brings back server form.
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }
        
        //Server form closing.
        private void LaunchedServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (startRes == DialogResult.OK)
            {
                DialogResult res = MessageBox.Show(
                        Properties.strings.closing, Properties.strings.closingTitle,
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel)
                    e.Cancel = true;
                else
                    server.CloseServer();
            }
        }
    }
}
