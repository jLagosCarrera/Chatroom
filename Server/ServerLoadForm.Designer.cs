﻿namespace Server
{
    partial class ServerLoadForm
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
            this.startBtn = new System.Windows.Forms.Button();
            this.welcomeLbl = new System.Windows.Forms.Label();
            this.portLbl = new System.Windows.Forms.Label();
            this.portNumeric = new System.Windows.Forms.NumericUpDown();
            this.welcomeTxt = new System.Windows.Forms.TextBox();
            this.languageLbl = new System.Windows.Forms.Label();
            this.languageCb = new System.Windows.Forms.ComboBox();
            this.infoTxt = new System.Windows.Forms.TextBox();
            this.clientsNumeric = new System.Windows.Forms.NumericUpDown();
            this.clientsLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.startBtn.Location = new System.Drawing.Point(0, 158);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(453, 68);
            this.startBtn.TabIndex = 9;
            this.startBtn.Text = "Start Server";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // welcomeLbl
            // 
            this.welcomeLbl.AutoSize = true;
            this.welcomeLbl.Location = new System.Drawing.Point(9, 9);
            this.welcomeLbl.Name = "welcomeLbl";
            this.welcomeLbl.Size = new System.Drawing.Size(131, 17);
            this.welcomeLbl.TabIndex = 0;
            this.welcomeLbl.Text = "Welcome message:";
            // 
            // portLbl
            // 
            this.portLbl.AutoSize = true;
            this.portLbl.Location = new System.Drawing.Point(9, 82);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(34, 17);
            this.portLbl.TabIndex = 2;
            this.portLbl.Text = "Port";
            // 
            // portNumeric
            // 
            this.portNumeric.Location = new System.Drawing.Point(12, 102);
            this.portNumeric.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNumeric.Name = "portNumeric";
            this.portNumeric.Size = new System.Drawing.Size(128, 22);
            this.portNumeric.TabIndex = 3;
            this.portNumeric.Value = new decimal(new int[] {
            11235,
            0,
            0,
            0});
            // 
            // welcomeTxt
            // 
            this.welcomeTxt.Location = new System.Drawing.Point(12, 29);
            this.welcomeTxt.Multiline = true;
            this.welcomeTxt.Name = "welcomeTxt";
            this.welcomeTxt.Size = new System.Drawing.Size(429, 50);
            this.welcomeTxt.TabIndex = 1;
            // 
            // languageLbl
            // 
            this.languageLbl.AutoSize = true;
            this.languageLbl.Location = new System.Drawing.Point(306, 82);
            this.languageLbl.Name = "languageLbl";
            this.languageLbl.Size = new System.Drawing.Size(72, 17);
            this.languageLbl.TabIndex = 6;
            this.languageLbl.Text = "Language";
            // 
            // languageCb
            // 
            this.languageCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageCb.FormattingEnabled = true;
            this.languageCb.Location = new System.Drawing.Point(309, 101);
            this.languageCb.Name = "languageCb";
            this.languageCb.Size = new System.Drawing.Size(132, 24);
            this.languageCb.TabIndex = 7;
            this.languageCb.SelectedIndexChanged += new System.EventHandler(this.LanguageCb_SelectedIndexChanged);
            // 
            // infoTxt
            // 
            this.infoTxt.Enabled = false;
            this.infoTxt.Location = new System.Drawing.Point(12, 131);
            this.infoTxt.Name = "infoTxt";
            this.infoTxt.Size = new System.Drawing.Size(429, 22);
            this.infoTxt.TabIndex = 8;
            // 
            // clientsNumeric
            // 
            this.clientsNumeric.Location = new System.Drawing.Point(146, 102);
            this.clientsNumeric.Name = "clientsNumeric";
            this.clientsNumeric.Size = new System.Drawing.Size(157, 22);
            this.clientsNumeric.TabIndex = 5;
            this.clientsNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // clientsLbl
            // 
            this.clientsLbl.AutoSize = true;
            this.clientsLbl.Location = new System.Drawing.Point(143, 82);
            this.clientsLbl.Name = "clientsLbl";
            this.clientsLbl.Size = new System.Drawing.Size(118, 17);
            this.clientsLbl.TabIndex = 4;
            this.clientsLbl.Text = "Number of clients";
            // 
            // ServerLoadForm
            // 
            this.AcceptButton = this.startBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 226);
            this.Controls.Add(this.clientsNumeric);
            this.Controls.Add(this.clientsLbl);
            this.Controls.Add(this.infoTxt);
            this.Controls.Add(this.languageCb);
            this.Controls.Add(this.languageLbl);
            this.Controls.Add(this.welcomeTxt);
            this.Controls.Add(this.portNumeric);
            this.Controls.Add(this.portLbl);
            this.Controls.Add(this.welcomeLbl);
            this.Controls.Add(this.startBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ServerLoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerLoadForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerLoadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label welcomeLbl;
        private System.Windows.Forms.Label portLbl;
        private System.Windows.Forms.Label languageLbl;
        private System.Windows.Forms.ComboBox languageCb;
        private System.Windows.Forms.TextBox infoTxt;
        internal System.Windows.Forms.TextBox welcomeTxt;
        internal System.Windows.Forms.NumericUpDown portNumeric;
        internal System.Windows.Forms.NumericUpDown clientsNumeric;
        private System.Windows.Forms.Label clientsLbl;
    }
}

