namespace Planet
{
    partial class MainForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.projektToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oknáToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zatvoriťVšetkyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otvoriťVšetkyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlaždiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nástrojeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spustiSimulátorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.konzolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.konfiguráciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projektToolStripMenuItem,
            this.oknáToolStripMenuItem,
            this.nástrojeToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.mainMenuStrip.Size = new System.Drawing.Size(791, 28);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // projektToolStripMenuItem
            // 
            this.projektToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.konfiguráciaToolStripMenuItem});
            this.projektToolStripMenuItem.Name = "projektToolStripMenuItem";
            this.projektToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.projektToolStripMenuItem.Text = "Projekt";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newToolStripMenuItem.Text = "Nový";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openProjectToolStripMenuItem.Text = "Otvoriť";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "Uložiť";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // oknáToolStripMenuItem
            // 
            this.oknáToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zatvoriťVšetkyToolStripMenuItem,
            this.otvoriťVšetkyToolStripMenuItem,
            this.dlaždiceToolStripMenuItem});
            this.oknáToolStripMenuItem.Name = "oknáToolStripMenuItem";
            this.oknáToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.oknáToolStripMenuItem.Text = "Okná";
            // 
            // zatvoriťVšetkyToolStripMenuItem
            // 
            this.zatvoriťVšetkyToolStripMenuItem.Name = "zatvoriťVšetkyToolStripMenuItem";
            this.zatvoriťVšetkyToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.zatvoriťVšetkyToolStripMenuItem.Text = "Zatvoriť všetky";
            this.zatvoriťVšetkyToolStripMenuItem.Click += new System.EventHandler(this.CloseAllWindowsToolStripMenuItem_Click);
            // 
            // otvoriťVšetkyToolStripMenuItem
            // 
            this.otvoriťVšetkyToolStripMenuItem.Name = "otvoriťVšetkyToolStripMenuItem";
            this.otvoriťVšetkyToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.otvoriťVšetkyToolStripMenuItem.Text = "Otvoriť všetky";
            this.otvoriťVšetkyToolStripMenuItem.Click += new System.EventHandler(this.OpenAllWindowsToolStripMenuItem_Click);
            // 
            // dlaždiceToolStripMenuItem
            // 
            this.dlaždiceToolStripMenuItem.Name = "dlaždiceToolStripMenuItem";
            this.dlaždiceToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.dlaždiceToolStripMenuItem.Text = "Dlaždice";
            this.dlaždiceToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // nástrojeToolStripMenuItem
            // 
            this.nástrojeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spustiSimulátorToolStripMenuItem1,
            this.konzolaToolStripMenuItem});
            this.nástrojeToolStripMenuItem.Name = "nástrojeToolStripMenuItem";
            this.nástrojeToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.nástrojeToolStripMenuItem.Text = "Nástroje";
            // 
            // spustiSimulátorToolStripMenuItem1
            // 
            this.spustiSimulátorToolStripMenuItem1.Name = "spustiSimulátorToolStripMenuItem1";
            this.spustiSimulátorToolStripMenuItem1.Size = new System.Drawing.Size(148, 26);
            this.spustiSimulátorToolStripMenuItem1.Text = "Simulátor";
            this.spustiSimulátorToolStripMenuItem1.Click += new System.EventHandler(this.spustiSimulátorToolStripMenuItem1_Click);
            // 
            // konzolaToolStripMenuItem
            // 
            this.konzolaToolStripMenuItem.Name = "konzolaToolStripMenuItem";
            this.konzolaToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.konzolaToolStripMenuItem.Text = "Konzola";
            this.konzolaToolStripMenuItem.Click += new System.EventHandler(this.konzolaToolStripMenuItem_Click);
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainToolStrip.Location = new System.Drawing.Point(0, 579);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(791, 25);
            this.mainToolStrip.TabIndex = 2;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 500;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // konfiguráciaToolStripMenuItem
            // 
            this.konfiguráciaToolStripMenuItem.Name = "konfiguráciaToolStripMenuItem";
            this.konfiguráciaToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.konfiguráciaToolStripMenuItem.Text = "Konfigurácia";
            this.konfiguráciaToolStripMenuItem.Click += new System.EventHandler(this.konfiguráciaToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(791, 604);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Planet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem projektToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.ToolStripMenuItem oknáToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zatvoriťVšetkyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otvoriťVšetkyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nástrojeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spustiSimulátorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem konzolaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dlaždiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konfiguráciaToolStripMenuItem;
    }
}

