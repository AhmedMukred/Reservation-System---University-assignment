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
using System.Threading;

namespace Assigment2
{
    public partial class Pay : MetroFramework.Forms.MetroForm
    {
        double discount, charge, deposit, bookingAmount, Total;
        DateTime date;
        public Pay()
        {
            InitializeComponent();
        }

        private void Pay_Load(object sender, EventArgs e)
        {
            //default style of the controls in the form
            cmbPaymentOption.SelectedIndex = -1;
            cmbPaymentMethods.SelectedIndex = -1;
            cmbPaymentMethods.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentOption.DropDownStyle = ComboBoxStyle.DropDownList;
            gropboxPaymentOption.Enabled = false;
            txtBookingNo.Focus();

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("MS");
            this.reportViewer1.Visible = false;
            this.reportViewer1.Enabled = false;
        }

        void checkBookingStatus(string BookingNo)
        { //Method is used to check if the booking no is cancelled or already had been paid the whole amount
            DBConnect conn = new DBConnect();
            SqlConnection myconn = conn.GetSqlConnection();
            string sql = "Select * from Booking where ID=@BookingNO";
            SqlCommand cmd = new SqlCommand(sql, myconn);
            SqlDataReader dr;
            cmd.Parameters.AddWithValue("@BookingNO", BookingNo);
            myconn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                if (dr["Status"].ToString() == "Cancelled")
                {
                    MessageBox.Show("The entered booking No had been cancelled before", "Booking Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBookingNo.Focus();
                }
                else if (dr["Status"].ToString() == "Successful")
                {
                    MessageBox.Show("The entered booking No had been paid the whole amount already", "Invalid Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBookingNo.Focus();
                }
                else
                {
                    gropboxPaymentOption.Enabled = true;
                    txtBookingNo.Enabled = false;
                    cmbPaymentOption.Focus();
                }
            }
            else
            {
                MessageBox.Show("The entered booking No does not exist.", "Invalid Booking NO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myconn.Close();
        }

        void checkDepositStatus(string BookingNo)
        {// Method is used to check the deposit status
            DBConnect conn = new DBConnect();
            SqlConnection myconn = conn.GetSqlConnection();
            string sql = "Select * from Booking where ID=@BookingNO";
            SqlCommand cmd = new SqlCommand(sql, myconn);
            SqlDataReader dr;
            cmd.Parameters.AddWithValue("@BookingNO", BookingNo);
            myconn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                if (dr["Status"].ToString() == "Confirmed")
                {
                    MessageBox.Show("The deposit had been paid before for the entered Booking No.", "Payment Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dr["Status"].ToString() == "Not Confirmed" && dr["Type"].ToString() == "Hotel")
                {
                    MessageBox.Show("The entered booking No is a hotel reservation, no need to pay a deposit", "Invalid Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SelectDeposit(txtBookingNo.Text);
                    gropboxPayment.Visible = true;
                }
            }
            myconn.Close();
        }

        void clearAll()
        {// set the values of combo boxes
            cmbPaymentMethods.SelectedIndex = -1;
            cmbPaymentOption.SelectedIndex = -1;
            txtBookingNo.Enabled = true;
            txtBookingNo.Text = "";
            txtBookingNo.Focus();
        }


        void SelectDeposit(string BookingNo)
        {
            DBConnect conn = new DBConnect();
            SqlConnection myconn = conn.GetSqlConnection();
            SqlCommand cmn;
            SqlDataReader dr;
            string sql = "select * from booking where id=@ID";
            cmn = new SqlCommand(sql, myconn);
            cmn.Parameters.AddWithValue("@ID", BookingNo);
            try
            {
                myconn.Open();
                dr = cmn.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    lblTotalAmount.Visible = false;
                    labelTotalAmount.Visible = false;
                    labelStatus.Visible = false;
                    lblStatus.Visible = false;
                    labelStatus.Visible = false;
                    lblStatus.Visible = false;
                    labelBookingAmount.Visible = false;
                    lblBookingAmount.Visible = false;
                    labelDepositPaid.Visible = true;
                    lblDepositPaid.Visible = true;
                    lblBookingNo.Text = dr["ID"].ToString();
                    lblType.Text = dr["Type"].ToString();
                    date = DateTime.Parse(dr["Date"].ToString());
                    lblDate.Text = date.ToShortDateString();
                    lblCustomerID.Text = dr["CustomerID"].ToString();
                    labelDeposit.Text = "Deposit";
                    deposit = double.Parse(dr["Deposit"].ToString());
                    lblDeposit.Text = deposit.ToString("C3");
                    labelCharge.Text = "Total Amount";
                    bookingAmount =  double.Parse(dr["Total"].ToString()) - double.Parse(dr["Discount"].ToString());
                    lblCharge.Text = bookingAmount.ToString("C3");
                    labelDepositPaid.Text = "Remaining Amount";
                    Total = double.Parse(dr["Total"].ToString()) - double.Parse(dr["Deposit"].ToString()) - double.Parse(dr["Discount"].ToString());
                    lblDepositPaid.Text = Total.ToString("C3");

                }
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



        void SelectBooking(string BookingNo)
        {
            DBConnect conn = new DBConnect();
            SqlConnection myconn = conn.GetSqlConnection();
            SqlCommand cmn;
            SqlDataReader dr;
            string sql = "select * from booking where id=@ID";
            cmn = new SqlCommand(sql, myconn);
            cmn.Parameters.AddWithValue("@ID", BookingNo);
            try
            {
                myconn.Open();
                dr = cmn.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr["Status"].ToString() == "Not Confirmed" && (dr["Type"].ToString()== "Tour Package & Hotel" || dr["Type"].ToString() == "Tour Package"))
                    {
                        MessageBox.Show("You have to pay the deposit firstly to confirm the booking", "Unconfirmed Booking", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        labelStatus.Visible = true;
                        lblStatus.Visible = true;
                        labelTotalAmount.Visible = true;
                        lblTotalAmount.Visible = true;
                        lblBookingAmount.Visible = true;
                        labelBookingAmount.Visible = true;
                        labelCharge.Visible = true;
                        lblCharge.Visible = true;
                        labelDeposit.Visible = true;
                        lblDeposit.Visible = true;
                        labelDepositPaid.Visible = true;
                        lblDepositPaid.Visible = true;
                        labelDepositPaid.Text = "Deposit Paid";
                        labelDeposit.Text = "Discount";
                        labelCharge.Text = "Charge";
                        lblBookingNo.Text = dr["ID"].ToString();
                        lblCustomerID.Text = dr["CustomerID"].ToString();
                        lblType.Text = dr["Type"].ToString();
                        date = DateTime.Parse(dr["Date"].ToString());
                        lblDate.Text = date.ToShortDateString();
                        charge = double.Parse(dr["Charge"].ToString());
                        lblCharge.Text = charge.ToString("C3");
                        discount = double.Parse(dr["Discount"].ToString());
                        lblDeposit.Text = discount.ToString("C3");
                        deposit = 0;
                        lblDepositPaid.Text = deposit.ToString("C3");
                        bookingAmount = double.Parse(dr["Total"].ToString());
                        lblBookingAmount.Text = bookingAmount.ToString("C3");
                        Total = double.Parse(dr["Total"].ToString()) + double.Parse(dr["Charge"].ToString()) - double.Parse(dr["Discount"].ToString());
                        lblTotalAmount.Text = Total.ToString("C3");
                        if (dr["DepositStatus"].ToString() == string.Empty)
                        {
                            lblStatus.Text = "Null";
                        }
                        else
                        {
                            lblStatus.Text = dr["DepositStatus"].ToString();
                        }

                        if (dr["Status"].ToString() == "Confirmed" && dr["DepositStatus"].ToString() == string.Empty)
                        {
                            deposit = double.Parse(dr["Deposit"].ToString());
                            lblDepositPaid.Text = deposit.ToString("C3");
                            Total = double.Parse(dr["Total"].ToString()) + double.Parse(dr["Charge"].ToString()) - double.Parse(dr["Discount"].ToString()) - double.Parse(dr["deposit"].ToString());
                            lblTotalAmount.Text = Total.ToString("C3");
                        }
                        else if (dr["DepositStatus"].ToString() == "forfeited")
                        {
                            deposit = double.Parse(dr["Deposit"].ToString());
                            lblDepositPaid.Text = deposit.ToString("C3");
                            Total = double.Parse(dr["Total"].ToString()) + double.Parse(dr["Charge"].ToString()) - double.Parse(dr["Discount"].ToString());
                            lblTotalAmount.Text = Total.ToString("C3");
                        }
                        gropboxPayment.Visible = true;
                    }
                }
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

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtBookingNo.Text.Equals(string.Empty))
            {
                MessageBox.Show("Please enter the booking number", "Empty Entery", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBookingNo.Focus();
            }
            else
            {
                checkBookingStatus(txtBookingNo.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cmbPaymentMethods.SelectedIndex == -1 || cmbPaymentOption.SelectedIndex == -1)
            {
                MessageBox.Show("Make sure that you have selected the payment option and method", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cmbPaymentOption.SelectedItem.ToString() == "Deposit")
                {
                    checkDepositStatus(txtBookingNo.Text);
                }
                else
                {
                    DBConnect pay = new DBConnect();
                    bool success = pay.updateChargeTotal(txtBookingNo.Text);
                    if (success == true)
                    {
                        SelectBooking(txtBookingNo.Text);
                    }
                    else
                    {
                        MessageBox.Show("Connection is faild try again please", "Invalid Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gropboxPaymentOption.Enabled = false;
            clearAll();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DBConnect pay = new DBConnect();
            bool success = false; ;
            if (cmbPaymentOption.SelectedItem.ToString() == "Deposit")
            {
                success = pay.MakePayment(int.Parse(txtBookingNo.Text), cmbPaymentOption.Text, double.Parse(lblDeposit.Text, System.Globalization.NumberStyles.Currency), cmbPaymentMethods.Text,DateTime.Now);
            }
            else if (cmbPaymentOption.SelectedItem.ToString() == "Total")
            {
                success = pay.MakePayment(int.Parse(txtBookingNo.Text), cmbPaymentOption.Text, double.Parse(lblTotalAmount.Text, System.Globalization.NumberStyles.Currency), cmbPaymentMethods.Text,DateTime.Now);
            }
            if (success == true)
            {
                MessageBox.Show("The payment process has been made successfully", "Successful Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.reportViewer1.Visible = true;
                this.reportViewer1.Enabled = true;
                // TODO: This line of code loads data into the 'DataSet3.DataTable1' table. You can move, or remove it, as needed.
                this.DataTable1TableAdapter.Fill(this.DataSet3.DataTable1);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Making payment process is faild", "Faild Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            gropboxPayment.Visible = false;
            labelDeposit.Text = "";
            labelCharge.Text = "";

        }

        private void Pay_Activated(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Enabled = false;
            }
        }

        private void Pay_Deactivate(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Enabled = true;
            }
        }
    }
}
