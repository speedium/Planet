namespace Planet
{
    partial class MapRefForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lGpsLon = new System.Windows.Forms.Label();
            this.lGpsLat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.splitContainer1.Panel1.Controls.Add(this.lGpsLon);
            this.splitContainer1.Panel1.Controls.Add(this.lGpsLat);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(473, 405);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // lGpsLon
            // 
            this.lGpsLon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lGpsLon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lGpsLon.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lGpsLon.Location = new System.Drawing.Point(16, 96);
            this.lGpsLon.Name = "lGpsLon";
            this.lGpsLon.Size = new System.Drawing.Size(445, 82);
            this.lGpsLon.TabIndex = 2;
            this.lGpsLon.Text = "VD: XX°XX\' XX.XX\'\'";
            this.lGpsLon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lGpsLat
            // 
            this.lGpsLat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lGpsLat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lGpsLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lGpsLat.Location = new System.Drawing.Point(16, 9);
            this.lGpsLat.Name = "lGpsLat";
            this.lGpsLat.Size = new System.Drawing.Size(445, 82);
            this.lGpsLat.TabIndex = 3;
            this.lGpsLat.Text = "SŠ: XX°XX\' XX.XX\'\'";
            this.lGpsLat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MapRefForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(473, 405);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapRefForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Map GPS Ref";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapRefForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lGpsLon;
        private System.Windows.Forms.Label lGpsLat;
    }
}