using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Globalization;
using System.Net.Sockets;

namespace ELogSimulator
{
    /////////////////////////////////
    /////////////////////////////////
    public partial class MainFormELogSimulator : Form
    {
        UdpClient udpClient = null;
        IPEndPoint mIPRCEndPoint = null;
        Point dieraPoint = new Point(0, 0);
        Point lastMousePoint;
        Point prevMeasuredPoint;
        Point actualMeasuredPoint;
        Graphics graphicsImage = null;
        bool isSendData = false;
        Bitmap myFiledImage;
        Bitmap myImage;
        List<Point> measuredCoordinates = new List<Point>();
        public int colorCout;//pocet farieb na cycle
        //public int[] colorArray;
        public Color[] colorArrayARGB;
        /////////////////////////////////
        /////////////////////////////////
        public MainFormELogSimulator()
        {

            InitUdp();
            colorCout = 15;//pocet farieb na cycle, a mam 2 cycle

            //colorArray = new int[5 * colorCout];
            colorArrayARGB = new Color[5 * colorCout];
            CalculateColors();

            InitializeComponent();
            SetGraphics();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void InitUdp()
        {
            string localIPstr = "192.168.1.10";
            IPAddress ipRC = IPAddress.Parse(localIPstr);
            int devicePort = 60001;
            mIPRCEndPoint = new IPEndPoint(ipRC, devicePort);
            udpClient = new UdpClient();

        }
        /////////////////////////////////
        /////////////////////////////////
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isSendData)
            {
                //Byte[] sendBytes = Encoding.ASCII.GetBytes("$GPGGA,142849.000,4852.8664,N,01802.2796,E,1,04,2.5,180.9,M,42.4,M,,0000*59<CR><LF>"+
                //"$PDATA,+11.09, -0.232369*50<CR><LF>");

                Byte[] sendBytes = {0x24, 0x47, 0x50, 0x47, 0x47 ,0x41 ,0x2C, //$GPGGA,  [0]-[6]
                                       0x31 ,0x34, 0x32, 0x38, 0x34, 0x39 ,0x2E, 0x30, 0x30, 0x30 , 0x2C ,//cas  142849.000, [7]-[17]
                                        0x34 , 0x38 ,0x35 , 0x32 , 0x2E , 0x38 , 0x36 , 0x36 , 0x34 , 0x2C , //4852.8664, [18]-[27]
                                        0x4E , 0x2C ,//N, [28]-[29]
                                       0x30 , 0x31 , 0x38 , 0x30 , 0x32,      0x2E , 0x32 , 0x37 , 0x39 , 0x36 , 0x2C , //01802.2796, [30]-[40]
                0x45 , 0x2C , //E, [41]-[42]
                0x31 , 0x2C , //1, [43]-[44]
                0x30 , 0x34 , 0x2C , // 04, [45]-[47]
                0x32 , 0x2E , 0x35 , 0x2C ,// 2.5, [48]-[51] 
                0x31 , 0x38 , 0x30 , 0x2E , 0x39 , 0x2C , // 180.9, [52]-[57]
                0x4D , 0x2C , //M, [58]-[59]
                0x34 , 0x32 , 0x2E , 0x34 , 0x2C , //42.4, [60]-[64]
                0x4D , 0x2C , //M, [65]-[66]
                0x2C , 0x30 , 0x30 , 0x30 , 0x30 , 0x2A , 0x35 , 0x39 , 0x0D , 0x0A , //  [67]-[76]
                0x24 , 0x50 , 0x44 , 0x41 , 0x54 , 0x41 , 0x2C , //$PDATA, [77]-[83]
                0x2B , 0x31 , 0x31 ,  0x2E , 0x30 , 0x39 , 0x2C , //+11.09, [84]-[90]
                0x20 , 0x2D , 0x30 , 0x2E , 0x32 , 0x33 , 0x32 , 0x33 , 0x36 , 0x39 , //" -0.232369" [91]-[100] pozor, zacina medzerou
                0x2A , 0x35 , 0x30 , 0x0D , 0x0A };//*50<CR><LF> [101]-[105]

                DateTime dt = DateTime.Now;
                string dtStr = dt.Hour.ToString("D2") + dt.Minute.ToString("D2") + dt.Second.ToString("D2");
                byte[] arrayTime = Encoding.ASCII.GetBytes(dtStr);

                string latStr = "48" + LinearChangeDouble(0, ClientRectangle.Height, 52.0, 50.0, actualMeasuredPoint.Y).ToString("00.0000", CultureInfo.InvariantCulture);
                byte[] arrayLat = Encoding.ASCII.GetBytes(latStr);

                string lonStr = "018" + LinearChangeDouble(0, ClientRectangle.Width, 0.0, 2.0, actualMeasuredPoint.X).ToString("00.0000", CultureInfo.InvariantCulture);
                byte[] arrayLon = Encoding.ASCII.GetBytes(lonStr);

                string volategeStr = GetVoltage(prevMeasuredPoint, actualMeasuredPoint).ToString("N6", CultureInfo.InvariantCulture);
                byte[] arrayVoltage = Encoding.ASCII.GetBytes(volategeStr);

                byte[] arrayBateryat = Encoding.ASCII.GetBytes("+" + dt.Second.ToString("D2", CultureInfo.InvariantCulture) + "." + dt.Second.ToString("D2", CultureInfo.InvariantCulture));

                arrayTime.CopyTo(sendBytes, 7);
                arrayLat.CopyTo(sendBytes, 18);
                arrayLon.CopyTo(sendBytes, 30);
                arrayBateryat.CopyTo(sendBytes, 84);
                arrayVoltage.CopyTo(sendBytes, 92);

                int iPoslane = udpClient.Send(sendBytes, sendBytes.Length, mIPRCEndPoint);

                string result = System.Text.Encoding.UTF8.GetString(sendBytes);

                Console.WriteLine("Posielam:" + result);
            }
        }
        /////////////////////////////////
        /////////////////////////////////
        private void posielajDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            posielajDataToolStripMenuItem.Visible = false;
            neposielajDataToolStripMenuItem.Visible = true;
            isSendData = true;
            measuredCoordinates.Clear();
            Invalidate();
            lastMousePoint.X = -1; lastMousePoint.Y = -1;
        }
        /////////////////////////////////
        /////////////////////////////////
        private void neposielajDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            posielajDataToolStripMenuItem.Visible = true;
            neposielajDataToolStripMenuItem.Visible = false;
            isSendData = false;
            Invalidate();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void MainFormELogSimulator_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);

            if (isSendData)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (lastMousePoint.X != point.X || lastMousePoint.Y != point.Y)
                    {
                        prevMeasuredPoint = actualMeasuredPoint;
                        measuredCoordinates.Add(point);
                        actualMeasuredPoint = point;
                        Invalidate();
                    }
                }
            }
            lastMousePoint = point;
        }
        /////////////////////////////////
        /////////////////////////////////
        private void MainFormELogSimulator_Paint(object sender, PaintEventArgs e)
        {
            graphicsImage.Clear(BackColor);
            graphicsImage.DrawImage(myFiledImage, 0, 0);
            Pen pen = new Pen(Color.Black);

            for (int i = 0; i < measuredCoordinates.Count - 1; i++)
            {
                graphicsImage.DrawLine(pen, measuredCoordinates[i], measuredCoordinates[i + 1]);
            }

            Graphics g = e.Graphics;
            g.DrawImage(myImage, 0, 0);
        }
        /////////////////////////////////
        /////////////////////////////////
        private void MainFormELogSimulator_SizeChanged(object sender, EventArgs e)
        {
            SetGraphics();
        }
        /////////////////////////////////
        /////////////////////////////////
        double GetFieldValue(int x, int y)
        {
            double dist = ((x - dieraPoint.X) * (x - dieraPoint.X) + (y - dieraPoint.Y) * (y - dieraPoint.Y));
            double value0 = 1.0 / (1.0 + 0.005 * dist);
            double value1 = LinearChangeDouble(0.0, 1.0, 0.0, 1.0, value0);
            return value1;
        }
        /////////////////////////////////
        /////////////////////////////////
        double GetVoltage(Point pointPrev, Point pointActual)
        {
            Point direct = new Point(pointActual.X - pointPrev.X, pointActual.Y - pointPrev.Y);
            int directAbs = (int)Math.Sqrt(direct.X * direct.X + direct.Y * direct.Y);
            if (directAbs == 0) { directAbs = 1; }
            direct.X /= directAbs;
            direct.Y /= directAbs;
            double valueA = GetFieldValue((int)(pointActual.X - 0.5 * direct.X), (int)(pointActual.Y - 0.5 * direct.Y));
            double valueB = GetFieldValue((int)(pointActual.X + 0.5 * direct.X), (int)(pointActual.Y + 0.5 * direct.Y));
            return valueB - valueA;
            /*

                GetFieldValue(int x, int y);


                double dist = ((x - dieraPoint.X) * (x - dieraPoint.X) + (y - dieraPoint.Y) * (y - dieraPoint.Y));
                double value0 = 1.0 / (1.0 + 0.005 * dist);
                double value1 = LinearChangeDouble(0.0, 1.0, 0.0, 1.0, value0);
                return value1;
             */
        }
        /////////////////////////////////
        /////////////////////////////////
        private void SetGraphics()
        {
            myFiledImage = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            for (int row = 0; row < ClientRectangle.Width; row++)
            {
                for (int col = 0; col < ClientRectangle.Height; col++)
                {
                    double fieldValue = GetFieldValue(row, col);
                    int indexColor = (int)LinearChangeDouble(0.0, 1.0, 75, 0, fieldValue);
                    myFiledImage.SetPixel(row, col, colorArrayARGB[indexColor]);
                }
            }

            myImage = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            graphicsImage = Graphics.FromImage(myImage);
        }
        /////////////////////////////////
        /////////////////////////////////
        private void CalculateColors()
        {
            int red, green, blue;
            //colorCout //pocet farieb na cycle
            //je 5 cycles, numCycles
            // 1. + blue <0x7F, 0xFF>
            // 2. + green <0x00, 0xFF>
            // 3. -blue +red <0x00, 0xFF>
            // 4. - green <0x00, 0xFF>
            // 5. - red <0xFF, 0x7F>
            int colorStep;

            int colorId;//pocitadlo
            int indexColor = 0;
            //colorArrayARGB[indexColor] = Color.FromArgb(150, red, green, blue);

            //1. blue+ cycle
            red = 255; green = 53; blue = 58;
            //colorArray[indexColor] = red << 16 | green << 8 | blue;
            colorArrayARGB[indexColor] = Color.FromArgb(150, red, green, blue);
            //indexColor++;
            colorStep = (255 - 58) / colorCout;
            for (colorId = 0; colorId < colorCout; colorId++)
            {
                //colorArray[indexColor] = red << 16 | green << 8 | blue;
                colorArrayARGB[indexColor] = Color.FromArgb(150, red, green, blue);
                blue += colorStep;
                if (blue > 0xFF) { blue = 0xFF; }
                indexColor++;
            }

            //2. green+ cycle
            red = 0x0; green = 0x0; blue = 0xFF;
            //colorArray[indexColor] = red << 16 | green << 8 | blue;
            colorArrayARGB[indexColor] = Color.FromArgb(150, red, green, blue);
            indexColor++;
            colorStep = 0xFF / colorCout;
            for (colorId = 1; colorId < colorCout; colorId++)
            {
                green += colorStep;
                if (green > 0xFF) { green = 0xFF; }
                //colorArray[indexColor] = red << 16 | green << 8 | blue;
                colorArrayARGB[indexColor] = Color.FromArgb(150, red, green, blue);
                indexColor++;
            }

            //3. blue- red+ cycle
            red = 0x0; green = 0xFF; blue = 0xFF;
            //colorArray[indexColor] = red << 16 | green << 8 | blue;
            colorArrayARGB[indexColor] = Color.FromArgb(150, red, green, blue);
            indexColor++;
            colorStep = 0xFF / colorCout;
            for (colorId = 1; colorId < colorCout; colorId++)
            {
                blue -= colorStep;
                red += colorStep;
                if (blue < 0x0) { blue = 0x0; }
                if (red > 0xFF) { red = 0xFF; }
                //colorArray[indexColor] = red << 16 | green << 8 | blue;
                colorArrayARGB[indexColor] = Color.FromArgb(150, red, green, blue);
                indexColor++;
            }

            //4. gree- cycle
            red = 0xff; green = 0xFF; blue = 0x00;
            //colorArray[indexColor] = red << 16 | green << 8 | blue;
            colorArrayARGB[indexColor] = Color.FromArgb(150, red, green, blue);
            indexColor++;
            colorStep = 0xFF / colorCout;
            for (colorId = 1; colorId < colorCout; colorId++)
            {
                green -= colorStep;
                if (green < 0x0) { green = 0x0; }
                //colorArray[indexColor] = red << 16 | green << 8 | blue;
                colorArrayARGB[indexColor] = Color.FromArgb(150, red, green, blue);
                indexColor++;
            }
            //5. red- cycle
            red = 255; green = 53; blue = 255;
            //colorArray[indexColor] = red << 16 | green << 8 | blue;
            colorArrayARGB[indexColor] = Color.FromArgb(150, red, green, blue);
            //indexColor++;
            colorStep = (255 - 58) / colorCout;
            for (colorId = 0; colorId < colorCout; colorId++)
            {
                //colorArray[indexColor] = red << 16 | green << 8 | blue;
                colorArrayARGB[indexColor] = Color.FromArgb(150, red, green, blue);
                red -= colorStep;
                if (red < 0x0) { red = 0x0; }
                indexColor++;
            }
        }
        /////////////////////////////////
        /////////////////////////////////
        static public double LinearChangeDouble(double K00, double K11, double k00, double k11, double valueIn)
        {
            if (valueIn < K00)
            {
                return k00;
            }
            if (valueIn > K11)
            {
                return k11;
            }
            if (K00 == K11)
            {
                return k00;
            }
            //% from interval <K00, K11> into <k00, k11>, valueIn should be in inteval <K00, K11>
            double a = (K11 * k00 - k11 * K00) / (K11 - K00);
            double b = -(-k11 + k00) / (K11 - K00);

            return (a + b * valueIn);
        }
        /////////////////////////////////
        /////////////////////////////////
        private void MainFormELogSimulator_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Right)
            {
                dieraPoint = point;
                SetGraphics();
                Invalidate();
            }
        }
    }
}
