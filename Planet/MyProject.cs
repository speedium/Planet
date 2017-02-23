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
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using System.IO;

namespace Planet
{
    /////////////////////////////////
    /////////////////////////////////
    public class GPSCoords
    {
        public enum ECoordType
        {
            Undefined,
            Latitude,
            Longitude
        }
        public double gpsValue=0.0;
          public string gpsStr="";
        ECoordType coordType = ECoordType.Undefined;
        public double gpsValueCorr=0.0;
        bool addNewValueGPSCoords=true;//!!
        public GPSCoords(ECoordType coordTypeIn) { coordType = coordTypeIn; }
        /////////////////////////////////
        public GPSCoords(GPSCoords gpsCoordsIn)
        {
            coordType = gpsCoordsIn.coordType;
            gpsValue = gpsCoordsIn.gpsValue;
            gpsStr = gpsCoordsIn.gpsStr;
            gpsValueCorr = 0.0;
        }
        /////////////////////////////////
        private GPSCoords() { }
        public void Write(BinaryWriter bw)
        {
            bw.Write(gpsValue);
               bw.Write(gpsStr);
            bw.Write((Int32)(coordType));
            bw.Write(gpsValueCorr);
            bw.Write(addNewValueGPSCoords);
        }
        public void Read(BinaryReader br)
        {
            gpsValue = br.ReadDouble();
            gpsStr = br.ReadString();
            coordType = (ECoordType)br.ReadInt32();
            gpsValueCorr = br.ReadDouble();
            addNewValueGPSCoords = br.ReadBoolean();
        }
        /////////////////////////////////
        public void GetValuesFromDeviceData(string gpsDegsStrIn, string gpsMinutesDecimalIn)
        {
            try
            {
                string[] gpsMinutesDecimalParts = gpsMinutesDecimalIn.Split('.');

                double gpsMinutesDecimal = Convert.ToDouble(gpsMinutesDecimalIn, CultureInfo.InvariantCulture);
                double celeMinuty = Convert.ToInt16(gpsMinutesDecimalParts[0]);
                double zvysok = gpsMinutesDecimal - celeMinuty;
                double seconds = zvysok * 60;

                int gpsDegs = Convert.ToInt16(gpsDegsStrIn);

                gpsValue = Convert.ToDouble(gpsDegsStrIn, CultureInfo.InvariantCulture);

                gpsValue += gpsMinutesDecimal / 60.0;

                string gpsDegsStr = gpsDegsStrIn;
                string gpsMinutesStr = gpsMinutesDecimalParts[0];
                string gpsSecondsStr = seconds.ToString("N2", CultureInfo.InvariantCulture);

                if (coordType == ECoordType.Latitude)
                {
                    gpsStr = "SŠ: "
                    + gpsDegsStr + "°"
                    + gpsMinutesStr + "'"
                    + gpsSecondsStr + "''";
                }
                if (coordType == ECoordType.Longitude)
                {
                    gpsStr = "VD: "
                    + gpsDegsStr + "°"
                    + gpsMinutesStr + "'"
                    + gpsSecondsStr + "''";
                }
            }
            catch { }
        }
    }
    /////////////////////////////////
    /////////////////////////////////
    public class GpsData
    {
        public GPSCoords lat;
        public GPSCoords lon;
        public int signalQuality=0;
        public string timeStr="";
        public bool addNewValueToLoadAndSAveFunctions=true;//!!
        /////////////////////////////////
        public GpsData()
        {
            Init();
        }
        /////////////////////////////////
        public GpsData(GpsData gpsDataIn)
        {
            Init();
            lat = new GPSCoords(gpsDataIn.lat);
            lon = new GPSCoords(gpsDataIn.lon);
            signalQuality = gpsDataIn.signalQuality;
            timeStr = gpsDataIn.timeStr;
        }
        /////////////////////////////////
        public void Init()
        {
            lat = new GPSCoords(GPSCoords.ECoordType.Latitude);
            lon = new GPSCoords(GPSCoords.ECoordType.Longitude);
        }
        /////////////////////////////////
        public void Write(BinaryWriter bw)
        {
            lat.Write(bw);
            lon.Write(bw);
            bw.Write(signalQuality);
            bw.Write(timeStr);
            bw.Write(addNewValueToLoadAndSAveFunctions);
        }
        /////////////////////////////////
        public void Read(BinaryReader br)
        {
            lat.Read(br);
            lon.Read(br);
            signalQuality = br.ReadInt32();
            timeStr = br.ReadString();
            addNewValueToLoadAndSAveFunctions = br.ReadBoolean();
        }
        /////////////////////////////////
    }
    /////////////////////////////////
    /////////////////////////////////
    public class ShipData
    {
        public GpsData gpsData;
        public GpsData gpsRefData;
        public double batery;
        public double voltage;
        public bool addNewValueToLoadAndSAveFunctions;//!!
        /////////////////////////////////
        public ShipData()
        {
            gpsData = new GpsData();
            gpsRefData = new GpsData();
        }
        /////////////////////////////////
        public ShipData(ShipData shipDataIn)
        {
            gpsData = new GpsData(shipDataIn.gpsData);
            gpsRefData = new GpsData(shipDataIn.gpsRefData);

            batery = shipDataIn.batery;
            voltage = shipDataIn.voltage;
        }
        /////////////////////////////////
        public void Write(BinaryWriter bw)
        {
            gpsData.Write(bw);
            gpsRefData.Write(bw);
            bw.Write(batery);
            bw.Write(voltage);
            bw.Write(addNewValueToLoadAndSAveFunctions);
        }
        /////////////////////////////////
        public void Read(BinaryReader br)
        {
            gpsData.Read(br);
            gpsRefData.Read(br);
            batery = br.ReadDouble();
            voltage = br.ReadDouble();
            addNewValueToLoadAndSAveFunctions = br.ReadBoolean();
        }
    }
    /////////////////////////////////
    /////////////////////////////////
    public class MyProject
    {
        /////////////////////////////////
        /////////////////////////////////
        private UdpClient udpClient = null;
        private IPEndPoint mIPRCEndPoint = null;
        private IPEndPoint senderIEP = new IPEndPoint(IPAddress.Any, 0);
        //private GpsData gpsRefData = new GpsData();
        private ShipData shipDataActual = new ShipData();
        // private ShipData shipDataNew= new ShipData();
        private List<string> strRefGpsArray = new List<string>();
        private List<string> strShipDataArray = new List<string>();
        public List<ShipData> shipDataArray = new List<ShipData>();
        private string strBuff;
        private DateTime dateTimeStart;
        private bool isMeasuring = false;
        private System.IO.Ports.SerialPort serialPort;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private bool isUdpConnected = false;
        public DataTable dataTable = new DataTable();
        private double lonMin;
        private double lonMax;
        private double latMin;
        private double latMax;
        public double voltageAbs;
        private double voltageMin;
        private double voltageMax;
        public DateTime lastUSBMsgTime = DateTime.MinValue;
        public DateTime lastUDPMsgTime = DateTime.MinValue;
        public double latOrigin = 0.0;
        public double lonOrigin = 0.0;
        /////////////////////////////////
        /////////////////////////////////
        public MyProject()
        {
            //LoadConfig("Planet.cfg");
            dataTable.Columns.Add("Time", typeof(string));
            dataTable.Columns.Add("GPS ref", typeof(string));
            dataTable.Columns.Add("GPS", typeof(string));
            dataTable.Columns.Add("Voltage", typeof(string));
            dataTable.Columns.Add("Batery", typeof(string));

            serialPort = new System.IO.Ports.SerialPort();
            serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerAsync();
        }
        /////////////////////////////////
        /////////////////////////////////
        public void LoadConfig(string cfgFilePath)
        {
            FileStream fs = null;
            StreamReader sr = null;
            fs = new FileStream(cfgFilePath, FileMode.Open);
            sr = new StreamReader(fs);
            string[] latStr = sr.ReadLine().Split(':');
            string[] lonStr = sr.ReadLine().Split(':');

            latOrigin = Convert.ToDouble(latStr[1], CultureInfo.InvariantCulture);
            lonOrigin = Convert.ToDouble(lonStr[1], CultureInfo.InvariantCulture);

            sr.Close();
            fs.Close();
        }
        /////////////////////////////////
        public void NewProject()
        {
            shipDataArray.Clear();
            dataTable.Clear();
        }
        /////////////////////////////////
        public void MapToScreen(int indexPoint, int width, int height, ref Point point)
        {
            point.X = (int)MyProject.LinearChangeDouble(lonMin, lonMax, 0.0, width, shipDataArray[indexPoint].gpsData.lon.gpsValue);
            point.Y = (int)MyProject.LinearChangeDouble(latMin, latMax, height, 0.0, shipDataArray[indexPoint].gpsData.lat.gpsValue);
        }
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
        //Methods
        /////////////////////////////////
        public void StartMeasuring()
        {
            if (IsMeasuring()) { return; }
            isMeasuring = true;
            dateTimeStart = DateTime.Now;

            //ConnectSerialPort("COM7");

            strBuff = "";
            strRefGpsArray.Clear();
            strShipDataArray.Clear();

        }
        /////////////////////////////////
        public void ConnectUdp(string localIPstr, string portStr)
        {
            try
            {
                isUdpConnected = false;
                if (udpClient != null) { udpClient.Close(); }
                //string localIPstr = "192.168.1.40";
                IPAddress ipRC = IPAddress.Parse(localIPstr);
                int devicePort = Convert.ToInt32(portStr);
                mIPRCEndPoint = new IPEndPoint(ipRC, devicePort);
                udpClient = new UdpClient(mIPRCEndPoint);
                if (udpClient != null)
                {
                    isUdpConnected = true;
                }
            }
            catch { }
        }
        /////////////////////////////////
        /////////////////////////////////
        public void ConnectSerialPort(string portNameIn)
        {
            if (serialPort.IsOpen) { serialPort.Close(); }
            serialPort.BaudRate = 4800;

            SerialPort.GetPortNames();

            serialPort.PortName = portNameIn;

            //serialPort.PortName = "COM7";


            serialPort.Open();
        }
        /////////////////////////////////
        /////////////////////////////////
        public void StopMeasuring()
        {
            isMeasuring = false;
            serialPort.Close();
        }
        /////////////////////////////////
        /////////////////////////////////
        public bool IsMeasuring()
        {
            return isMeasuring;
        }
        /////////////////////////////////
        /////////////////////////////////
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Byte[] receiveBytes;
            while (true)
            {
                if (isUdpConnected)
                {
                    receiveBytes = udpClient.Receive(ref senderIEP);
                    string receiveStr = System.Text.Encoding.UTF8.GetString(receiveBytes);
                    strShipDataArray.Add(receiveStr);
                    lastUDPMsgTime = DateTime.Now;
                    Program.Console_WriteLine(receiveStr);
                    if (Program.isDevelopment)
                    {
                        strBuff = receiveStr;
                        ParseSerialPortData();
                    }
                }
            }
        }

        /////////////////////////////////
        /////////////////////////////////
        public TimeSpan GetMeasuringTime()
        {
            return DateTime.Now - dateTimeStart;
        }
        /////////////////////////////////
        /////////////////////////////////
        public ShipData GetShipData()
        {
            while (strShipDataArray.Count > 0)
            {
                //Byte[] receiveBytes = Encoding.ASCII.GetBytes("$GPGGA,142849.000,4852.8664,N,01802.2796,E,1,04,2.5,180.9,M,42.4,M,,0000*59<CR><LF>"+
                //"$PDATA,+11.09, -0.232369*50<CR><LF>");

                int indexPdata = strShipDataArray[0].IndexOf("$PDATA");
                string gpsMsg = strShipDataArray[0].Substring(0, indexPdata);
                string pdataMsg = strShipDataArray[0].Substring(indexPdata, strShipDataArray[0].Length - indexPdata);

                /*if (isMeasuring)
                {
                    shipDataNew = new ShipData();
                }*/
                ParseGPGGAMsg(ref gpsMsg, ref shipDataActual.gpsData);
                ParsePDataMsg(ref pdataMsg, ref shipDataActual);
                if (isMeasuring)
                {
                    ShipData shipDataNew = new ShipData(shipDataActual);

                    AddMeasure(ref shipDataNew);
                }
                strShipDataArray.RemoveAt(0);
            }
            return shipDataActual;
        }
        /////////////////////////////////
        /////////////////////////////////
        public void AddMeasure(ref ShipData shipData)
        {
            shipDataArray.Add(shipData);
            DataRow dr = dataTable.NewRow();
            dr[0] = shipData.gpsData.timeStr;// DateTime.Now.ToString(@"HH\:mm\:ss");
            dr[1] = shipData.gpsRefData.lat.gpsStr + "|" + shipData.gpsRefData.lon.gpsStr;
            dr[2] = shipData.gpsData.lat.gpsStr + "|" + shipData.gpsData.lon.gpsStr;
            dr[3] = shipData.voltage;
            dr[4] = shipData.batery;
            dataTable.Rows.Add(dr);
            if (shipDataArray.Count == 1)
            {
                latMin = shipData.gpsData.lat.gpsValue; latMax = latMin;
                lonMin = shipData.gpsData.lon.gpsValue; lonMax = lonMin;
                voltageMin = shipData.voltage; voltageMax = voltageMin;
            }
            else
            {
                if (latMin > shipData.gpsData.lat.gpsValue) { latMin = shipData.gpsData.lat.gpsValue; }
                if (latMax < shipData.gpsData.lat.gpsValue) { latMax = shipData.gpsData.lat.gpsValue; }

                if (lonMin > shipData.gpsData.lon.gpsValue) { lonMin = shipData.gpsData.lon.gpsValue; }
                if (lonMax < shipData.gpsData.lon.gpsValue) { lonMax = shipData.gpsData.lon.gpsValue; }

                if (voltageMin > shipData.voltage) { voltageMin = shipData.voltage; }
                if (voltageMax < shipData.voltage) { voltageMax = shipData.voltage; }
            }
            voltageAbs = Math.Max(Math.Abs(voltageMin), Math.Abs(voltageMax));
        }
        /////////////////////////////////
        /////////////////////////////////
        public GpsData GetGpsRefData()
        {
            while (strRefGpsArray.Count > 0)
            {
                string gpggaMsg = strRefGpsArray[0];
                ParseGPGGAMsg(ref gpggaMsg, ref shipDataActual.gpsRefData);
                strRefGpsArray.RemoveAt(0);
            }
            return shipDataActual.gpsRefData;
        }
        /////////////////////////////////
        /////////////////////////////////
        private void ParsePDataMsg(ref string pdataMsg, ref ShipData shipData)
        {
            //"$PDATA,+11.09, -0.232369*50<CR><LF>");
            string[] dataStr = pdataMsg.Split(',');
            shipData.batery = Convert.ToDouble(dataStr[1], CultureInfo.InvariantCulture);
            shipData.voltage = Convert.ToDouble(dataStr[2].Split('*')[0], CultureInfo.InvariantCulture);
        }
        /////////////////////////////////
        /////////////////////////////////
        private void ParseGPGGAMsg(ref string gpggaMsg, ref GpsData gpsData)
        {
            //Byte[] receiveBytes = Encoding.ASCII.GetBytes("$GPGGA,142849.000,4852.8664,N,01802.2796,E,1,04,2.5,180.9,M,42.4,M,,0000*59<CR><LF>"+

            string[] dataStr = gpggaMsg.Split(',');

            //=dataStr[0];//"$GPGGA"
            //=dataStr[1];//Time
            if (dataStr[1].Length > 0)
            {
                gpsData.timeStr = dataStr[1].Substring(0, 2) + ":" + dataStr[1].Substring(2, 2) + ":" + dataStr[1].Substring(4, dataStr[1].Length - 4);
            }
            if (dataStr[2].Length > 0)
            {
                 gpsData.lat.GetValuesFromDeviceData(dataStr[2].Substring(0, 2), dataStr[2].Substring(2, 7));//lat
            }
            //=dataStr[3];//N/S
            if (dataStr[4].Length > 0)
            {
                gpsData.lon.GetValuesFromDeviceData(dataStr[4].Substring(0, 3), dataStr[4].Substring(3, 7));//lat
            }
            //=dataStr[5];//E/W
            if (dataStr[6].Length > 0)
            {
                gpsData.signalQuality = Convert.ToInt16(dataStr[6]);//quality
            }
            //=dataStr[7];//Satelites Count
            //=dataStr[8];//HDOP
            //=dataStr[9];//vyska anteny
            //=dataStr[10];//geoidal separation
            //=dataStr[11];//units
        }
        /////////////////////////////////
        /////////////////////////////////
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            strBuff += serialPort.ReadExisting();
            ParseSerialPortData();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void ParseSerialPortData()
        {
            if (strBuff.Contains("$GPGGA"))
            {
                int iGPGGA = strBuff.IndexOf("$GPGGA", 0);
                strBuff = strBuff.Substring(iGPGGA);
                if (strBuff.Contains("*"))
                {
                    int iFirstStar = strBuff.IndexOf("*", 0);
                    {
                        strBuff = strBuff.Substring(0, iFirstStar + 1);
                    }
                    strRefGpsArray.Add(strBuff);
                    lastUSBMsgTime = DateTime.Now;
                    Program.Console_WriteLine(strBuff);
                    strBuff = "";
                }
            }
        }
        /////////////////////////////////
        /////////////////////////////////
    }

}
