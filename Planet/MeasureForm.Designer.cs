namespace Planet
{
    partial class MeasureForm
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
            this.bStart = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.lMeasuringTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lActualTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStart.ForeColor = System.Drawing.Color.Black;
            this.bStart.Location = new System.Drawing.Point(12, 66);
            this.bStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(400, 88);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Štart";
            this.bStart.UseVisualStyleBackColor = false;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bStop
            // 
            this.bStop.BackColor = System.Drawing.Color.Red;
            this.bStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStop.Location = new System.Drawing.Point(12, 158);
            this.bStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(400, 93);
            this.bStop.TabIndex = 1;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = false;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // lMeasuringTime
            // 
            this.lMeasuringTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMeasuringTime.ForeColor = System.Drawing.Color.Gray;
            this.lMeasuringTime.Location = new System.Drawing.Point(163, 38);
            this.lMeasuringTime.Name = "lMeasuringTime";
            this.lMeasuringTime.Size = new System.Drawing.Size(204, 23);
            this.lMeasuringTime.TabIndex = 2;
            this.lMeasuringTime.Text = "----";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Čas merania:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Aktuálny čas:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lActualTime
            // 
            this.lActualTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lActualTime.ForeColor = System.Drawing.Color.Gray;
            this.lActualTime.Location = new System.Drawing.Point(163, 9);
            this.lActualTime.Name = "lActualTime";
            this.lActualTime.Size = new System.Drawing.Size(209, 23);
            this.lActualTime.TabIndex = 4;
            this.lActualTime.Text = "----";
            // 
            // MeasureForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(424, 265);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lActualTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lMeasuringTime);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MeasureForm";
            this.Text = "Meranie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MeasureForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Label lMeasuringTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lActualTime;
    }
}