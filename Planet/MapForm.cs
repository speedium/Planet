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
    public partial class MapForm : Form
    {
        Point pointPrev = new Point();
        Point pointActual = new Point();
        Point pointA = new Point();
        Point pointB = new Point();
        double pointDirectionX;
        double pointDirectionY;
        Pen greenSipkaPen = Pens.Green;
        Pen redSipkaPen = Pens.Red;
        /////////////////////////////////
        /////////////////////////////////
        public MapForm()
        {
            InitializeComponent();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void MapForm_Paint(object sender, PaintEventArgs e)
        {
            //"kresli sipky"
            Pen sipkaPen;
            Graphics g = e.Graphics;
            bool doSearch;
            int prevIndex;
            double normalSize2 = 0, normalSize;

            for (int p = 1; p < MainForm.myProject.shipDataArray.Count; p++)
            {
                MainForm.myProject.MapToScreen(p, ClientSize.Width, ClientSize.Height, ref pointActual);
                doSearch = true;
                prevIndex = p - 1;
                while (prevIndex >= 0 && doSearch == true)
                {
                    MainForm.myProject.MapToScreen(prevIndex, ClientSize.Width, ClientSize.Height, ref pointPrev);
                    pointDirectionX = pointActual.X - pointPrev.X;
                    pointDirectionY = pointActual.Y - pointPrev.Y;
                    normalSize2 = (pointDirectionX * pointDirectionX + pointDirectionY * pointDirectionY);
                    if (normalSize2 != 0) { doSearch = false; }
                    prevIndex--;
                }
                if (normalSize2 == 0) { normalSize2 = 1; }
                normalSize = Math.Sqrt(normalSize2);
                pointDirectionX /= (int)normalSize;
                pointDirectionY /= (int)normalSize;
                int sipkaScale = (int)MyProject.LinearChangeDouble(0.0, MainForm.myProject.voltageAbs, 0.0, 10, Math.Abs(MainForm.myProject.shipDataArray[p].voltage));

                //MainForm.myProject.;
                pointA.X = (int)(pointActual.X - sipkaScale * pointDirectionX);
                pointA.Y = (int)(pointActual.Y - sipkaScale * pointDirectionY);

                pointB.X = (int)(pointActual.X + sipkaScale * pointDirectionX);
                pointB.Y = (int)(pointActual.Y + sipkaScale * pointDirectionY);

                sipkaPen = greenSipkaPen;
                if (MainForm.myProject.shipDataArray[p].voltage < 0.0) { sipkaPen = redSipkaPen; }
                g.DrawLine(sipkaPen, pointA, pointB);
            }
        }
        /////////////////////////////////
        /////////////////////////////////
        private void MapForm_FormClosing(object sender, FormClosingEventArgs e)
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
        }
        /////////////////////////////////
        /////////////////////////////////
        public void UpdateNotMeasuringData()
        {


        }
        /////////////////////////////////
        /////////////////////////////////
        private void MapForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            Invalidate();
        }
        /////////////////////////////////
        /////////////////////////////////
    }
}
