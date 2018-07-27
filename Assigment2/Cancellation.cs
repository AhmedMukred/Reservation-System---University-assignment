using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Assigment2
{
    public partial class Cancellation : MetroFramework.Forms.MetroForm
    {
        public Cancellation()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {// Check if the booking No is exists in the booking list in database
            DBConnect Check = new DBConnect();
            bool success = Check.CheckBooking(txtBookingNo.Text);
            if (success == true)
            { // Show the booking details to make sure that it is the correct booking to cancel it
                gropboxDetails.Visible = true;
                FieldsValues(txtBookingNo.Text);
            }
            else
            {
                MessageBox.Show("Booking No not exist in the booking list", "Invalid Booking NO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ClearAll()
        { // Set the dfault values of labels
            txtBookingNo.Clear();
            txtBookingNo.Focus();
            lblBooking.Text = "";
            lblCustomerID.Text = "";
            lblDate.Text = "";
            lblTotal.Text = "";
            lblType.Text = "";
            lblStatus.Text = "";
        }

        void FieldsValues(string BookingID)
        { // method is used to fill up the labels with the booking details
            DBConnect conn = new DBConnect();
            SqlConnection myconn = conn.GetSqlConnection();
            string sql = "Select ID,CustomerID,Date,Type,Total,Status  from Booking  where ID=@ID";
            SqlCommand cmn = new SqlCommand(sql, myconn);
            cmn.Parameters.AddWithValue("@ID", BookingID);
            SqlDataReader dr;
            try
            {
                myconn.Open();
                dr = cmn.ExecuteReader();
                dr.Read();
                lblBooking.Text = dr["ID"].ToString();
                lblCustomerID.Text = dr["CustomerID"].ToString();
                lblType.Text = dr["Type"].ToString();
                lblDate.Text = dr["Date"].ToString();
                lblTotal.Text = dr["Total"].ToString();
                lblStatus.Text = dr["Status"].ToString();
            }
            catch (SqlException ex)
            {//display on the console the exeception message
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
            finally
            {// Close the connection
                myconn.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {// Check if the booking had been cancelled before
            if (lblStatus.Text == "Cancelled")
            {
                MessageBox.Show("The booking had already cancelled before", "Cancellation Booking", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { // Cancel the booking and update the booking's status after checking the policy
                DBConnect Cance = new DBConnect();
                bool success = Cance.CancelBooking(txtBookingNo.Text);
                if (success == true)
                {
                    MessageBox.Show("The booking is being cancelled successfully", "Successful Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FieldsValues(txtBookingNo.Text);
                }
                else
                {
                    MessageBox.Show("Cancellation is faild because it doesn't match the cancellation policy", "Faild Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { // Close the form
            this.Close();
        }

        private void Cancellation_Activated(object sender, EventArgs e)
        { //Stop the enabled of the main form when this form is activated
            if (this.Owner != null)
            {
                this.Owner.Enabled = false;
            }
        }

        private void Cancellation_Deactivate(object sender, EventArgs e)
        { //Allow the enabled of the main form when this form is deactivate
            if (this.Owner != null)
            {
                this.Owner.Enabled = true;
            }
        }

        private void Cancellation_Load(object sender, EventArgs e)
        {

        }
    }
}
