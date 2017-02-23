namespace Planet
{
    partial class CommunicationsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bUSBConnect = new System.Windows.Forms.Button();
            this.bRefresh = new System.Windows.Forms.Button();
            this.lUSBStatus = new System.Windows.Forms.Label();
            this.cbAvalPorts = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bUDPConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lUDPStatus = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bUSBConnect);
            this.groupBox1.Controls.Add(this.bRefresh);
            this.groupBox1.Controls.Add(this.lUSBStatus);
            this.groupBox1.Controls.Add(this.cbAvalPorts);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(397, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "USB - GPS Ref";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            // 
            // bUSBConnect
            // 
            this.bUSBConnect.Location = new System.Drawing.Point(87, 86);
            this.bUSBConnect.Margin = new System.Windows.Forms.Padding(4);
            this.bUSBConnect.Name = "bUSBConnect";
            this.bUSBConnect.Size = new System.Drawing.Size(297, 34);
            this.bUSBConnect.TabIndex = 5;
            this.bUSBConnect.Text = "Spojiť";
            this.bUSBConnect.UseVisualStyleBackColor = true;
            this.bUSBConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // bRefresh
            // 
            this.bRefresh.Location = new System.Drawing.Point(280, 30);
            this.bRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(104, 34);
            this.bRefresh.TabIndex = 2;
            this.bRefresh.Text = "Obnoviť";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // lUSBStatus
            // 
            this.lUSBStatus.BackColor = System.Drawing.Color.Red;
            this.lUSBStatus.Location = new System.Drawing.Point(33, 91);
            this.lUSBStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lUSBStatus.Name = "lUSBStatus";
            this.lUSBStatus.Size = new System.Drawing.Size(23, 25);
            this.lUSBStatus.TabIndex = 3;
            this.lUSBStatus.Text = "  ";
            // 
            // cbAvalPorts
            // 
            this.cbAvalPorts.FormattingEnabled = true;
            this.cbAvalPorts.Location = new System.Drawing.Point(87, 30);
            this.cbAvalPorts.Margin = new System.Windows.Forms.Padding(4);
            this.cbAvalPorts.Name = "cbAvalPorts";
            this.cbAvalPorts.Size = new System.Drawing.Size(184, 33);
            this.cbAvalPorts.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPort);
            this.groupBox2.Controls.Add(this.tbIP);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.bUDPConnect);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lUDPStatus);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(12, 148);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(397, 185);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ethernet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Port:";
            // 
            // bUDPConnect
            // 
            this.bUDPConnect.Location = new System.Drawing.Point(87, 113);
            this.bUDPConnect.Margin = new System.Windows.Forms.Padding(4);
            this.bUDPConnect.Name = "bUDPConnect";
            this.bUDPConnect.Size = new System.Drawing.Size(297, 34);
            this.bUDPConnect.TabIndex = 6;
            this.bUDPConnect.Text = "Spojiť";
            this.bUDPConnect.UseVisualStyleBackColor = true;
            this.bUDPConnect.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "IP:";
            // 
            // lUDPStatus
            // 
            this.lUDPStatus.BackColor = System.Drawing.Color.Red;
            this.lUDPStatus.Location = new System.Drawing.Point(33, 118);
            this.lUDPStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lUDPStatus.Name = "lUDPStatus";
            this.lUDPStatus.Size = new System.Drawing.Size(23, 25);
            this.lUDPStatus.TabIndex = 4;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(87, 43);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(297, 30);
            this.tbIP.TabIndex = 9;
            this.tbIP.Text = "192.168.1.10";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(87, 77);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(297, 30);
            this.tbPort.TabIndex = 10;
            this.tbPort.Text = "60001";
            // 
            // CommunicationsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(416, 338);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommunicationsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Komunikácia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommunicationsForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.ComboBox cbAvalPorts;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label lUSBStatus;
        private System.Windows.Forms.Label lUDPStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bUSBConnect;
        private System.Windows.Forms.Button bUDPConnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIP;
    }
}