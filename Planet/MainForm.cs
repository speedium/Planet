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
using System.Net.Sockets;
using System.IO;
namespace Planet
{
    public partial class MainForm : Form
    {
        public static MyProject myProject = new MyProject();
        /////////////////////////////////
        /////////////////////////////////

        private GPSInfoForm gpsInfoForm;
        private MeasureForm measureForm;
        private MapForm mapForm;
        private MapRefForm mapRefForm;
        private TableForm tableForm;
        private CommunicationsForm communicationsForm;

        /////////////////////////////////
        /////////////////////////////////
        public MainForm()
        {
            InitializeComponent();
            //InitUdp();
            gpsInfoForm = new GPSInfoForm();
            gpsInfoForm.MdiParent = this;


            mapForm = new MapForm();
            mapForm.MdiParent = this;


            mapRefForm = new MapRefForm();
            mapRefForm.MdiParent = this;


            tableForm = new TableForm();
            tableForm.MdiParent = this;


            communicationsForm = new CommunicationsForm();
            communicationsForm.MdiParent = this;


            measureForm = new MeasureForm();
            measureForm.MdiParent = this;


            ShowAllWindows();
            CascadeWindows();
        }
        /////////////////////////////////
        /////////////////////////////////
        public void ShowAllWindows()
        {
            gpsInfoForm.Show();
            mapForm.Show();
            mapRefForm.Show();
            tableForm.Show();
            communicationsForm.Show();
            measureForm.Show();
        }
        /////////////////////////////////
        /////////////////////////////////
        public void HideAllWindows()
        {
            gpsInfoForm.Hide();
            mapForm.Hide();
            mapRefForm.Hide();
            tableForm.Hide();
            communicationsForm.Hide();
            measureForm.Hide();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myProject.NewProject();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            mapRefForm.UpdateIsMeasuringData();
            gpsInfoForm.UpdateIsMeasuringData();
            if (myProject.IsMeasuring())
            {
                mapForm.UpdateIsMeasuringData();
                tableForm.UpdateIsMeasuringData();
                communicationsForm.UpdateIsMeasuringData();
                measureForm.UpdateIsMeasuringData();
                mapForm.Invalidate();
            }
            else
            {
                gpsInfoForm.UpdateNotMeasuringData();
                mapForm.UpdateNotMeasuringData(); ;
                mapRefForm.UpdateNotMeasuringData();
                tableForm.UpdateNotMeasuringData();
                communicationsForm.UpdateNotMeasuringData();
                measureForm.UpdateNotMeasuringData();
            }
            communicationsForm.ConnectionStatus();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void spustiSimulátorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "\\ELogSimulator.exe");
        }
        /////////////////////////////////
        /////////////////////////////////
        private void konzolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.InitConsole();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void CloseAllWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllWindows();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void OpenAllWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAllWindows();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CascadeWindows();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void CascadeWindows()
        {
            gpsInfoForm.Location = new Point(0, 0);
            mapRefForm.Location = new Point(0, gpsInfoForm.Height);

            communicationsForm.Location = new Point(Width - communicationsForm.Width, 0);
            measureForm.Location = new Point(Width - measureForm.Width, communicationsForm.Height);

            mapForm.Location = new Point(gpsInfoForm.Width, 0);
            mapForm.Size = new System.Drawing.Size(ClientRectangle.Width - gpsInfoForm.Width - communicationsForm.Width,
                mapForm.Size.Height);
            tableForm.Location = new Point(mapRefForm.Width, mapForm.Height);
            tableForm.Size = new System.Drawing.Size(ClientRectangle.Width - mapRefForm.Width - measureForm.Width,
                tableForm.Size.Height);
        }
        /////////////////////////////////
        /////////////////////////////////
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream fs = null;
            BinaryWriter bw = null;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(All Files)|*.*";
            sfd.InitialDirectory = Application.StartupPath;

            if (sfd.ShowDialog() != DialogResult.OK)
                return;



            fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
            bw = new BinaryWriter(fs);

            int measuredPoints = myProject.shipDataArray.Count;
            bw.Write(measuredPoints);

            for (int ii = 0; ii < measuredPoints; ii++)
            {
                myProject.shipDataArray[ii].Write(bw);
            }

            bw.Close();
            fs.Close();
            mapForm.Invalidate();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream fs = null;
            BinaryReader br = null;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(All Files)|*.*";
            ofd.InitialDirectory = Application.StartupPath;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            myProject.NewProject();
            fs = new FileStream(ofd.FileName, FileMode.Open);
            br = new BinaryReader(fs);

            int measuredPoints = br.ReadInt32();
            for (int ii = 0; ii < measuredPoints; ii++)
            {
                ShipData shipDataNew = new ShipData();
                shipDataNew.Read(br);
                myProject.AddMeasure(ref shipDataNew);
            }

            br.Close();
            fs.Close();
            mapForm.Invalidate();
        }
        /////////////////////////////////
        /////////////////////////////////
        private void konfiguráciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(CFG Files)|*.cfg";
            ofd.InitialDirectory = Application.StartupPath;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            myProject.LoadConfig(ofd.FileName);
        }
        /////////////////////////////////
        /////////////////////////////////
    }
}
