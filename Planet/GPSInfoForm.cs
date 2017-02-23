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
    public partial class GPSInfoForm : Form
    {
        /////////////////////////////////
        /////////////////////////////////
        public GPSInfoForm()
        {
            InitializeComponent();
        }
        /////////////////////////////////
        /////////////////////////////////
        public void UpdateIsMeasuringData()
        {
            ShipData shipData = MainForm.myProject.GetShipData();

            //SŠ: 49°57' 45,55''
            lGpsLat.Text = shipData.gpsData.lat.gpsStr;
            /*"SŠ: "
            + shipData.gpsData.lat.gpsDegsStr + "°"
            + shipData.gpsData.lat.gpsMinutesStr + "'"
            + shipData.gpsData.lat.gpsSecondsStr + "''";*/
            //VD: 17°57' 45,55''
            lGpsLon.Text = shipData.gpsData.lon.gpsStr;

            lVoltage.Text = shipData.voltage.ToString() + " mV";//"0.000"

            lBatery.Text = shipData.batery.ToString("0.00") + " V";
            /*"VD: "
                + shipData.gpsData.lon.gpsDegsStr + "°"
                + shipData.gpsData.lon.gpsMinutesStr + "'"
                + shipData.gpsData.lon.gpsSecondsStr + "''";*/
        }
        /////////////////////////////////
        /////////////////////////////////
        public void UpdateNotMeasuringData()
        {


        }
        /////////////////////////////////
        /////////////////////////////////
        private void GPSInfoForm_FormClosing(object sender, FormClosingEventArgs e)
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
