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
    public partial class MapRefForm : Form
    {
        private Point pointA = new Point();
        private Point pointB = new Point();
        private Point pointC = new Point();
        private Point pointD = new Point();
        /////////////////////////////////
        /////////////////////////////////
        public MapRefForm()
        {
            InitializeComponent();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            //"kresli body referencnej GPS"
            Graphics g = e.Graphics;
            pointA.X = splitContainer1.Panel2.Width / 2 - 2;
            pointA.Y = splitContainer1.Panel2.Height / 2 - 2;
            pointB.X = splitContainer1.Panel2.Width / 2 + 2;
            pointB.Y = splitContainer1.Panel2.Height / 2 + 2;
            pointC.X = pointB.X;
            pointC.Y = pointA.Y;
            pointD.X = pointA.X;
            pointD.Y = pointB.Y;
            g.DrawLine(Pens.Black, pointA, pointB);
            g.DrawLine(Pens.Black, pointC, pointD);

        }
        /////////////////////////////////
        /////////////////////////////////
        private void MapRefForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            Hide();
        }
        /////////////////////////////////
        /////////////////////////////////
        public void UpdateIsMeasuringData()
        {
            GpsData gpsData = MainForm.myProject.GetGpsRefData();

            //SŠ: 49°57' 45,55''
            lGpsLat.Text = gpsData.lat.gpsStr;
            /*"SŠ: "
            + gpsData.lat.gpsDegsStr + "°"
            + gpsData.lat.gpsMinutesStr + "'"
            + gpsData.lat.gpsSecondsStr + "''";*/
            //VD: 17°57' 45,55''
            lGpsLon.Text = gpsData.lon.gpsStr;
            /*"VD: "
                + gpsData.lon.gpsDegsStr + "°"
                + gpsData.lon.gpsMinutesStr + "'"
                + gpsData.lon.gpsSecondsStr + "''";*/
        }
        /////////////////////////////////
        /////////////////////////////////
        public void UpdateNotMeasuringData()
        {


        }
        /////////////////////////////////
        /////////////////////////////////
    }
}
