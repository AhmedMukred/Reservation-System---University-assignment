using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assigment2
{
    public partial class Report : MetroFramework.Forms.MetroForm
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet3.Booking' table. You can move, or remove it, as needed.

            DateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.BookingTableAdapter.Fill(this.DataSet3.Booking, DateTimePicker.Value.ToShortDateString());
            this.reportViewer1.RefreshReport();
        }

        private void Report_Activated(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Enabled = false;
            }
        }

        private void Report_Deactivate(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
