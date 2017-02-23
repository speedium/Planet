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
    public partial class TableForm : Form
    {
        /////////////////////////////////
        /////////////////////////////////
        public TableForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = MainForm.myProject.dataTable;
        }
        /////////////////////////////////
        /////////////////////////////////
        private void TableForm_FormClosing(object sender, FormClosingEventArgs e)
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
        private void TableForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                    WindowState = FormWindowState.Normal;
            }
        }
        /////////////////////////////////
        /////////////////////////////////
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }
        /////////////////////////////////
        /////////////////////////////////
    }
}
