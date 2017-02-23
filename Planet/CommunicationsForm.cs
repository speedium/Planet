using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Planet
{
    public partial class CommunicationsForm : Form
    {
        /////////////////////////////////
        /////////////////////////////////
        public CommunicationsForm()
        {
            InitializeComponent();
            RefreshPorts();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void RefreshPorts()
        {
            string[] ports = SerialPort.GetPortNames();

            cbAvalPorts.Items.Clear();
            foreach (string port in ports)
            {
                cbAvalPorts.Items.Add(port);
            }
            cbAvalPorts.SelectedIndex = 0;

        }
        /////////////////////////////////
        /////////////////////////////////
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        /////////////////////////////////
        /////////////////////////////////
        private void bRefresh_Click(object sender, EventArgs e)
        {
            RefreshPorts();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void CommunicationsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            Hide();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {

            MainForm.myProject.ConnectSerialPort(cbAvalPorts.SelectedItem.ToString());
        }
        /////////////////////////////////
        /////////////////////////////////
        private void button2_Click(object sender, EventArgs e)
        {
            MainForm.myProject.ConnectUdp(tbIP.Text, tbPort.Text);
        }
        /////////////////////////////////
        /////////////////////////////////
        public void UpdateIsMeasuringData()
        {
        }
        /////////////////////////////////
        /////////////////////////////////
        public void UpdateNotMeasuringData()
        {


        }
        /////////////////////////////////
        /////////////////////////////////
        public void ConnectionStatus()
        {
            TimeSpan tsUSB = DateTime.Now - MainForm.myProject.lastUSBMsgTime;
            TimeSpan tsUDP = DateTime.Now - MainForm.myProject.lastUDPMsgTime;

            if (tsUDP.TotalSeconds < 0.5) { lUDPStatus.BackColor = Color.Green; }
            if (tsUDP.TotalSeconds > 0.5) { lUDPStatus.BackColor = Color.Yellow; }
            if (tsUDP.TotalSeconds > 5.0) { lUDPStatus.BackColor = Color.Red; }

            if (tsUSB.TotalSeconds < 0.5) { lUSBStatus.BackColor = Color.Green; }
            if (tsUSB.TotalSeconds > 0.5) { lUSBStatus.BackColor = Color.Yellow; }
            if (tsUSB.TotalSeconds > 5.0) { lUSBStatus.BackColor = Color.Red; }
        }
        /////////////////////////////////
        /////////////////////////////////
    }
}
