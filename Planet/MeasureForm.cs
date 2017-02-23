using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planet
{
    public partial class MeasureForm : Form
    {
        /////////////////////////////////
        /////////////////////////////////
        public MeasureForm()
        {
            InitializeComponent();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void bStart_Click(object sender, EventArgs e)
        {
            MainForm.myProject.StartMeasuring();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void bStop_Click(object sender, EventArgs e)
        {
            MainForm.myProject.StopMeasuring();
        }
        /////////////////////////////////
        /////////////////////////////////
        public void UpdateIsMeasuringData()
        {
            lActualTime.Text = DateTime.Now.ToShortTimeString();
            TimeSpan ts = MainForm.myProject.GetMeasuringTime();
            lMeasuringTime.Text = ts.ToString(@"hh\:mm\:ss");
        }
        /////////////////////////////////
        /////////////////////////////////
        public void UpdateNotMeasuringData()
        {
            lActualTime.Text = "----"; //DateTime.Now.ToShortTimeString();
            lMeasuringTime.Text = "----";
        }
        /////////////////////////////////
        /////////////////////////////////
        private void MeasureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            Hide();
        }
        /////////////////////////////////
        /////////////////////////////////
    }
}
