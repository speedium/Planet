namespace Planet
{
    partial class GPSInfoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lVoltage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lGpsLat = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lGpsLon = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lBatery = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(445, 82);
            this.label1.TabIndex = 0;
            this.label1.Text = "XXXX.XXX mV";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lVoltage);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 86);
            this.panel1.TabIndex = 1;
            // 
            // lVoltage
            // 
            this.lVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lVoltage.Location = new System.Drawing.Point(0, 0);
            this.lVoltage.Name = "lVoltage";
            this.lVoltage.Size = new System.Drawing.Size(445, 82);
            this.lVoltage.TabIndex = 1;
            this.lVoltage.Text = "XXXX.XXX mV";
            this.lVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lGpsLat);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(11, 105);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(449, 86);
            this.panel2.TabIndex = 2;
            // 
            // lGpsLat
            // 
            this.lGpsLat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lGpsLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lGpsLat.Location = new System.Drawing.Point(0, 0);
            this.lGpsLat.Name = "lGpsLat";
            this.lGpsLat.Size = new System.Drawing.Size(445, 82);
            this.lGpsLat.TabIndex = 1;
            this.lGpsLat.Text = "SŠ: XX°XX\' XX.XX\'\'";
            this.lGpsLat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(445, 82);
            this.label4.TabIndex = 0;
            this.label4.Text = "XXXX.XXX mV";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lGpsLon);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(11, 192);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(449, 86);
            this.panel3.TabIndex = 2;
            // 
            // lGpsLon
            // 
            this.lGpsLon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lGpsLon.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lGpsLon.Location = new System.Drawing.Point(0, 0);
            this.lGpsLon.Name = "lGpsLon";
            this.lGpsLon.Size = new System.Drawing.Size(445, 82);
            this.lGpsLon.TabIndex = 1;
            this.lGpsLon.Text = "VD: XX°XX\' XX.XX\'\'";
            this.lGpsLon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(445, 82);
            this.label6.TabIndex = 0;
            this.label6.Text = "XXXX.XXX mV";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lBatery);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(9, 284);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(449, 86);
            this.panel4.TabIndex = 2;
            // 
            // lBatery
            // 
            this.lBatery.BackColor = System.Drawing.Color.Plum;
            this.lBatery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBatery.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lBatery.Location = new System.Drawing.Point(0, 0);
            this.lBatery.Name = "lBatery";
            this.lBatery.Size = new System.Drawing.Size(445, 82);
            this.lBatery.TabIndex = 1;
            this.lBatery.Text = "XXXX.XXX V";
            this.lBatery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(445, 82);
            this.label3.TabIndex = 0;
            this.label3.Text = "XXXX.XXX mV";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GPSInfoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(473, 382);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GPSInfoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GPS Info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GPSInfoForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lVoltage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lGpsLat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lGpsLon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lBatery;
        private System.Windows.Forms.Label label3;
    }
}