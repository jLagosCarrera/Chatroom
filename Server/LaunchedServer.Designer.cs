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
            this.clientsLView = new System.Windows.Forms.ListView();
            this.clientsGbox = new System.Windows.Forms.GroupBox();
            this.clientGbox = new System.Windows.Forms.GroupBox();
            this.optionsGbox = new System.Windows.Forms.GroupBox();
            this.languageCb = new System.Windows.Forms.ComboBox();
            this.clientsGbox.SuspendLayout();
            this.optionsGbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientsLView
            // 
            this.clientsLView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientsLView.Location = new System.Drawing.Point(3, 18);
            this.clientsLView.Name = "clientsLView";
            this.clientsLView.Size = new System.Drawing.Size(442, 525);
            this.clientsLView.TabIndex = 0;
            this.clientsLView.UseCompatibleStateImageBehavior = false;
            // 
            // clientsGbox
            // 
            this.clientsGbox.Controls.Add(this.clientsLView);
            this.clientsGbox.Location = new System.Drawing.Point(12, 12);
            this.clientsGbox.Name = "clientsGbox";
            this.clientsGbox.Size = new System.Drawing.Size(448, 546);
            this.clientsGbox.TabIndex = 1;
            this.clientsGbox.TabStop = false;
            this.clientsGbox.Text = "groupBox1";
            // 
            // clientGbox
            // 
            this.clientGbox.Location = new System.Drawing.Point(466, 12);
            this.clientGbox.Name = "clientGbox";
            this.clientGbox.Size = new System.Drawing.Size(416, 269);
            this.clientGbox.TabIndex = 2;
            this.clientGbox.TabStop = false;
            this.clientGbox.Text = "groupBox2";
            // 
            // optionsGbox
            // 
            this.optionsGbox.Controls.Add(this.languageCb);
            this.optionsGbox.Location = new System.Drawing.Point(466, 287);
            this.optionsGbox.Name = "optionsGbox";
            this.optionsGbox.Size = new System.Drawing.Size(416, 271);
            this.optionsGbox.TabIndex = 3;
            this.optionsGbox.TabStop = false;
            this.optionsGbox.Text = "groupBox3";
            // 
            // languageCb
            // 
            this.languageCb.FormattingEnabled = true;
            this.languageCb.Location = new System.Drawing.Point(199, 89);
            this.languageCb.Name = "languageCb";
            this.languageCb.Size = new System.Drawing.Size(121, 24);
            this.languageCb.TabIndex = 0;
            // 
            // LaunchedServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 564);
            this.Controls.Add(this.optionsGbox);
            this.Controls.Add(this.clientGbox);
            this.Controls.Add(this.clientsGbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LaunchedServer";
            this.Text = "LaunchedServer";
            this.Load += new System.EventHandler(this.LaunchedServer_Load);
            this.clientsGbox.ResumeLayout(false);
            this.optionsGbox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView clientsLView;
        private System.Windows.Forms.GroupBox clientsGbox;
        private System.Windows.Forms.GroupBox clientGbox;
        private System.Windows.Forms.GroupBox optionsGbox;
        private System.Windows.Forms.ComboBox languageCb;
    }
}