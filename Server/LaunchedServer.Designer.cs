namespace Server
{
    partial class LaunchedServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chatGb = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.msgTxt = new System.Windows.Forms.TextBox();
            this.chatTxt = new System.Windows.Forms.TextBox();
            this.clientsGb = new System.Windows.Forms.GroupBox();
            this.clientsLView = new System.Windows.Forms.ListView();
            this.optionsGb = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnKickAll = new System.Windows.Forms.Button();
            this.btnKick = new System.Windows.Forms.Button();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.portTxt = new System.Windows.Forms.TextBox();
            this.portLbl = new System.Windows.Forms.Label();
            this.ipTxt = new System.Windows.Forms.TextBox();
            this.ipLbl = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.chatGb.SuspendLayout();
            this.clientsGb.SuspendLayout();
            this.optionsGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatGb
            // 
            this.chatGb.Controls.Add(this.btnSend);
            this.chatGb.Controls.Add(this.msgTxt);
            this.chatGb.Controls.Add(this.chatTxt);
            this.chatGb.Location = new System.Drawing.Point(13, 12);
            this.chatGb.Name = "chatGb";
            this.chatGb.Size = new System.Drawing.Size(1044, 399);
            this.chatGb.TabIndex = 0;
            this.chatGb.TabStop = false;
            this.chatGb.Text = "chatGb";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(908, 371);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(133, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // msgTxt
            // 
            this.msgTxt.Location = new System.Drawing.Point(6, 371);
            this.msgTxt.Name = "msgTxt";
            this.msgTxt.Size = new System.Drawing.Size(896, 22);
            this.msgTxt.TabIndex = 1;
            // 
            // chatTxt
            // 
            this.chatTxt.Dock = System.Windows.Forms.DockStyle.Top;
            this.chatTxt.Location = new System.Drawing.Point(3, 18);
            this.chatTxt.Multiline = true;
            this.chatTxt.Name = "chatTxt";
            this.chatTxt.ReadOnly = true;
            this.chatTxt.Size = new System.Drawing.Size(1038, 347);
            this.chatTxt.TabIndex = 0;
            this.chatTxt.TabStop = false;
            // 
            // clientsGb
            // 
            this.clientsGb.Controls.Add(this.clientsLView);
            this.clientsGb.Location = new System.Drawing.Point(13, 418);
            this.clientsGb.Name = "clientsGb";
            this.clientsGb.Size = new System.Drawing.Size(511, 289);
            this.clientsGb.TabIndex = 1;
            this.clientsGb.TabStop = false;
            this.clientsGb.Text = "clientsGb";
            // 
            // clientsLView
            // 
            this.clientsLView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientsLView.Location = new System.Drawing.Point(3, 18);
            this.clientsLView.MultiSelect = false;
            this.clientsLView.Name = "clientsLView";
            this.clientsLView.Size = new System.Drawing.Size(505, 268);
            this.clientsLView.TabIndex = 0;
            this.clientsLView.UseCompatibleStateImageBehavior = false;
            this.clientsLView.View = System.Windows.Forms.View.Tile;
            // 
            // optionsGb
            // 
            this.optionsGb.Controls.Add(this.btnClose);
            this.optionsGb.Controls.Add(this.btnKickAll);
            this.optionsGb.Controls.Add(this.btnKick);
            this.optionsGb.Controls.Add(this.nameTxt);
            this.optionsGb.Controls.Add(this.nameLbl);
            this.optionsGb.Controls.Add(this.portTxt);
            this.optionsGb.Controls.Add(this.portLbl);
            this.optionsGb.Controls.Add(this.ipTxt);
            this.optionsGb.Controls.Add(this.ipLbl);
            this.optionsGb.Location = new System.Drawing.Point(530, 418);
            this.optionsGb.Name = "optionsGb";
            this.optionsGb.Size = new System.Drawing.Size(527, 289);
            this.optionsGb.TabIndex = 2;
            this.optionsGb.TabStop = false;
            this.optionsGb.Text = "optionsGb";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(6, 216);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(515, 67);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close Server";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnKickAll
            // 
            this.btnKickAll.Location = new System.Drawing.Point(6, 143);
            this.btnKickAll.Name = "btnKickAll";
            this.btnKickAll.Size = new System.Drawing.Size(515, 67);
            this.btnKickAll.TabIndex = 7;
            this.btnKickAll.Text = "Kick All Clients";
            this.btnKickAll.UseVisualStyleBackColor = true;
            // 
            // btnKick
            // 
            this.btnKick.Location = new System.Drawing.Point(6, 70);
            this.btnKick.Name = "btnKick";
            this.btnKick.Size = new System.Drawing.Size(515, 67);
            this.btnKick.TabIndex = 6;
            this.btnKick.Text = "Kick This Client";
            this.btnKick.UseVisualStyleBackColor = true;
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(256, 42);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.ReadOnly = true;
            this.nameTxt.Size = new System.Drawing.Size(265, 22);
            this.nameTxt.TabIndex = 5;
            this.nameTxt.Text = "-";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(253, 22);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(84, 17);
            this.nameLbl.TabIndex = 4;
            this.nameLbl.Text = "Client Name";
            // 
            // portTxt
            // 
            this.portTxt.Location = new System.Drawing.Point(144, 42);
            this.portTxt.Name = "portTxt";
            this.portTxt.ReadOnly = true;
            this.portTxt.Size = new System.Drawing.Size(106, 22);
            this.portTxt.TabIndex = 3;
            this.portTxt.Text = "-";
            // 
            // portLbl
            // 
            this.portLbl.AutoSize = true;
            this.portLbl.Location = new System.Drawing.Point(141, 22);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(96, 17);
            this.portLbl.TabIndex = 2;
            this.portLbl.Text = "Assigned Port";
            // 
            // ipTxt
            // 
            this.ipTxt.Location = new System.Drawing.Point(6, 42);
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.ReadOnly = true;
            this.ipTxt.Size = new System.Drawing.Size(132, 22);
            this.ipTxt.TabIndex = 1;
            this.ipTxt.Text = "-";
            // 
            // ipLbl
            // 
            this.ipLbl.AutoSize = true;
            this.ipLbl.Location = new System.Drawing.Point(3, 22);
            this.ipLbl.Name = "ipLbl";
            this.ipLbl.Size = new System.Drawing.Size(59, 17);
            this.ipLbl.TabIndex = 0;
            this.ipLbl.Text = "Client IP";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // LaunchedServer
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 719);
            this.Controls.Add(this.optionsGb);
            this.Controls.Add(this.clientsGb);
            this.Controls.Add(this.chatGb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LaunchedServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LaunchedServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LaunchedServer_FormClosing);
            this.Load += new System.EventHandler(this.LaunchedServer_Load);
            this.Resize += new System.EventHandler(this.LaunchedServer_Resize);
            this.chatGb.ResumeLayout(false);
            this.chatGb.PerformLayout();
            this.clientsGb.ResumeLayout(false);
            this.optionsGb.ResumeLayout(false);
            this.optionsGb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox chatGb;
        private System.Windows.Forms.TextBox chatTxt;
        private System.Windows.Forms.GroupBox clientsGb;
        private System.Windows.Forms.ListView clientsLView;
        private System.Windows.Forms.GroupBox optionsGb;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnKickAll;
        private System.Windows.Forms.Button btnKick;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox portTxt;
        private System.Windows.Forms.Label portLbl;
        private System.Windows.Forms.TextBox ipTxt;
        private System.Windows.Forms.Label ipLbl;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox msgTxt;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}