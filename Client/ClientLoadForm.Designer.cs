namespace Client
{
    partial class ClientLoadForm
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.portNumeric = new System.Windows.Forms.NumericUpDown();
            this.languageCb = new System.Windows.Forms.ComboBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.ipportLbl = new System.Windows.Forms.Label();
            this.ipTxt = new System.Windows.Forms.TextBox();
            this.infoTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConnect.Location = new System.Drawing.Point(0, 132);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(377, 60);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "btnConnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(12, 29);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(353, 22);
            this.nameTxt.TabIndex = 1;
            // 
            // portNumeric
            // 
            this.portNumeric.Location = new System.Drawing.Point(240, 74);
            this.portNumeric.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNumeric.Name = "portNumeric";
            this.portNumeric.Size = new System.Drawing.Size(125, 22);
            this.portNumeric.TabIndex = 4;
            this.portNumeric.Value = new decimal(new int[] {
            11235,
            0,
            0,
            0});
            // 
            // languageCb
            // 
            this.languageCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageCb.FormattingEnabled = true;
            this.languageCb.Location = new System.Drawing.Point(240, 102);
            this.languageCb.Name = "languageCb";
            this.languageCb.Size = new System.Drawing.Size(125, 24);
            this.languageCb.TabIndex = 6;
            this.languageCb.SelectedIndexChanged += new System.EventHandler(this.LanguageCb_SelectedIndexChanged);
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(9, 9);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(62, 17);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "nameLbl";
            // 
            // ipportLbl
            // 
            this.ipportLbl.AutoSize = true;
            this.ipportLbl.Location = new System.Drawing.Point(9, 54);
            this.ipportLbl.Name = "ipportLbl";
            this.ipportLbl.Size = new System.Drawing.Size(63, 17);
            this.ipportLbl.TabIndex = 2;
            this.ipportLbl.Text = "ipportLbl";
            // 
            // ipTxt
            // 
            this.ipTxt.Location = new System.Drawing.Point(12, 74);
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.Size = new System.Drawing.Size(222, 22);
            this.ipTxt.TabIndex = 3;
            // 
            // infoTxt
            // 
            this.infoTxt.Enabled = false;
            this.infoTxt.Location = new System.Drawing.Point(12, 102);
            this.infoTxt.Name = "infoTxt";
            this.infoTxt.Size = new System.Drawing.Size(222, 22);
            this.infoTxt.TabIndex = 5;
            // 
            // ClientLoadForm
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 192);
            this.Controls.Add(this.infoTxt);
            this.Controls.Add(this.ipTxt);
            this.Controls.Add(this.ipportLbl);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.languageCb);
            this.Controls.Add(this.portNumeric);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ClientLoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientLoadForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientLoadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.NumericUpDown portNumeric;
        private System.Windows.Forms.ComboBox languageCb;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label ipportLbl;
        private System.Windows.Forms.TextBox ipTxt;
        private System.Windows.Forms.TextBox infoTxt;
    }
}

