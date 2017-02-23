namespace ELogSimulator
{
    partial class MainFormELogSimulator
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.posielajDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neposielajDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.posielajDataToolStripMenuItem,
            this.neposielajDataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(557, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // posielajDataToolStripMenuItem
            // 
            this.posielajDataToolStripMenuItem.Name = "posielajDataToolStripMenuItem";
            this.posielajDataToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.posielajDataToolStripMenuItem.Text = "Posielaj data";
            this.posielajDataToolStripMenuItem.Click += new System.EventHandler(this.posielajDataToolStripMenuItem_Click);
            // 
            // neposielajDataToolStripMenuItem
            // 
            this.neposielajDataToolStripMenuItem.Name = "neposielajDataToolStripMenuItem";
            this.neposielajDataToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.neposielajDataToolStripMenuItem.Text = "Neposielaj data";
            this.neposielajDataToolStripMenuItem.Visible = false;
            this.neposielajDataToolStripMenuItem.Click += new System.EventHandler(this.neposielajDataToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainFormELogSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 450);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFormELogSimulator";
            this.Text = "ELogSimulator";
            this.SizeChanged += new System.EventHandler(this.MainFormELogSimulator_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFormELogSimulator_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainFormELogSimulator_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainFormELogSimulator_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem posielajDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neposielajDataToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}

