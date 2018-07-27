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
    public partial class Modify :MetroFramework.Forms.MetroForm
    {
        public Modify()
        {
            InitializeComponent();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            ClearAll(); //Clear all of the fields and combo boxes
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.MinDate = DateTime.Now;
        }

        void ClearAll()
        { //Setting the defualt value of the fields and combo boxes
            cmbBooking.SelectedIndex = -1;
            cmbHotel.SelectedIndex = -1;
            cmbLocation.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            cmbBooking.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHotel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNight.DropDownStyle = ComboBoxStyle.DropDownList;
            txtICPassport.Clear();
            cmbHotel.Enabled = false;
            cmbRoom.Enabled = false;
            cmbLocation.Enabled = false;
            gBoxDetails.Visible = false;
            txtBookingNo.Focus();
            cmbNight.Enabled = false;
            cmbNight.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearAll();
            if (txtBookingNo.Text.Equals(string.Empty))
            { //Check if the text box is empty or not
                MessageBox.Show("Please enter the booking NO", "Invalid Booking No", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Check if the booking No is exists in the booking list
                DBConnect Check = new DBConnect();
                bool success = Check.CheckBooking(txtBookingNo.Text);
                if (success == true)
                { //Set the booking values on the fields and comboboxes

                    string status = FieldsValues(txtBookingNo.Text);
                    if (status == "Cancelled") //checking if the booking has cancelled before or not
                    {
                        MessageBox.Show("The entered booking No had been cancelled before", "Invalid Booking No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (status == "Successful")
                    {
                        MessageBox.Show("The entered booking No was already paid the whole amount", "Invalid Booking No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        gBoxDetails.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Booking No not exist in the booking list", "Invalid Booking NO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        { //Checking the fields and comboboxes and the selected values during updating process
            bool fields = checkFields(txtICPassport.Text);
            if (fields == true)
            {
                bool found = CustChecking(txtICPassport.Text);
                if (found == true)
                {
                    bool tour = TourChecking(cmbBooking.Text);
                    if (tour == true)
                    {
                        bool hotelCheck = PackHotChecking(cmbBooking.Text);
                        if (hotelCheck == true)
                        {
                            DialogResult confirm;
                            confirm = MessageBox.Show($"Please, Confirm modification with the following details \n\n IC/Passport ID : {txtICPassport.Text} \n Booking Type : {cmbBooking.Text} \n Location : {cmbLocation.Text} \n Booking Date : {dateTimePicker1.Text} \n Hotel : {cmbHotel.Text} \n Room Type : {cmbRoom.Text}", "Confirm Booking", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (confirm == DialogResult.OK)
                            { // update booking based on the type
                                if (cmbBooking.Text == "Tour Package")
                                {
                                    DBConnect Update = new DBConnect();
                                    bool success = Update.UpdateTourBooking(txtBookingNo.Text,txtICPassport.Text, dateTimePicker1.Text, cmbBooking.Text, cmbLocation.Text);
                                    successful(success);
                                }

                                else if (cmbBooking.Text == "Tour Package & Hotel")
                                {
                                    DBConnect update = new DBConnect();
                                    bool success = update.UpdateBooking(txtBookingNo.Text,txtICPassport.Text, dateTimePicker1.Text, cmbBooking.Text, cmbLocation.Text, cmbHotel.Text, cmbRoom.Text,int.Parse(cmbNight.Text));
                                    successful(success);
                                }
                                else if (cmbBooking.Text == "Hotel")
                                {
                                    DBConnect update = new DBConnect();
                                    bool success = update.UpdateHotelBooking(txtBookingNo.Text,txtICPassport.Text, dateTimePicker1.Text, cmbBooking.Text, cmbHotel.Text, cmbRoom.Text, int.Parse(cmbNight.Text));
                                    successful(success);
                                }
                            }
                        }
                    }
                }
            }
        }
        bool checkFields(string ID)
        { //Check if feilds is empty or not
            bool success = true;
            if (ID.Equals(string.Empty) || cmbBooking.SelectedIndex == -1)
            {
                MessageBox.Show("Please complete all of the fields", "Uncomplete fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            return success;
        }

        bool CustChecking(string ID)
        { //Check if the customer ID is exist in customers list
            bool Cust = true;
            DBConnect CusCheck = new DBConnect();
            bool success = CusCheck.CheckCustomer(ID);
            if (success == false)
            {
                Cust = false;
                DialogResult Cont;
                Cont = MessageBox.Show("This customer has not registered before. Do you Want to continue on this window", "Invalid Customer's ID", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Cont == DialogResult.No)
                {
                    this.Close();
                }
            }
            return Cust;
        }

        bool TourChecking(string Location)
        { //Check the fields based on tour booking
            bool success = true;
            if (Location == "Tour Package & Hotel" || Location == "Tour Package")
            {
                if (cmbLocation.SelectedIndex == -1)
                {
                    MessageBox.Show("Please choose the location of the tour tour package", "Uncomplete fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
            }
            return success;

        }

        bool PackHotChecking(string Booking)
        { //check combo boxes when the booking is hotel
            bool success = true;
            if (Booking == "Tour Package & Hotel" || Booking == "Hotel")
            {
                if (cmbHotel.SelectedIndex == -1 || cmbRoom.SelectedIndex == -1)
                {
                    MessageBox.Show("Please complete all of the fields", "Uncomplete fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
            }
            return success;
        }

        void successful(bool success)
        {
            if (success == true)
            {
                MessageBox.Show("Booking update successful", "Booking Updated",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else //if the connection is faild display the message
            {
                MessageBox.Show("Unable to update booking", "Booking update Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbBooking_SelectedIndexChanged(object sender, EventArgs e)
        {// Set the value of combo boxes based on the selected type of booking
            if (cmbBooking.Text == "Tour Package & Hotel")
            {
                cmbLocation.Enabled = true;
                cmbHotel.Enabled = true;
                cmbRoom.Enabled = true;
                cmbNight.SelectedIndex = 0;
                cmbLocation.SelectedIndex = -1;
                cmbNight.Enabled = true;
            }
            else if (cmbBooking.Text == "Tour Package")
            {
                cmbLocation.Enabled = true;
                cmbHotel.Enabled = false;
                cmbRoom.Enabled = false;
                cmbHotel.SelectedIndex = -1;
                cmbRoom.SelectedIndex = -1;
                cmbNight.Enabled = false;
                cmbNight.SelectedIndex = -1;

            }
            else if (cmbBooking.Text == "Hotel")
            {
                cmbHotel.Items.Clear();
                cmbHotel.Enabled = true;
                cmbRoom.Enabled = true;
                cmbLocation.Enabled = false;
                cmbNight.Enabled = true;
                cmbNight.SelectedIndex = 0;
                cmbLocation.SelectedIndex = -1;
                HotelList();
            }
            else
            {
                cmbHotel.SelectedIndex = -1;
                cmbRoom.SelectedIndex = -1;
                cmbLocation.SelectedIndex = -1;
                cmbHotel.Enabled = false;
                cmbRoom.Enabled = false;
                cmbLocation.Enabled = false;
                cmbNight.Enabled = false;
                cmbNight.SelectedIndex = -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { // Closr the form
            this.Close();
        }

        private void Update_Activated(object sender, EventArgs e)
        { //Stop the enabled of the main form when this form is activated
            if (this.Owner != null)
            {
                this.Owner.Enabled = false;
            }
        }

        private void Update_Deactivate(object sender, EventArgs e)
        { //Allow the enabled of the main form when this form is deactivate
            if (this.Owner != null)
            {
                this.Owner.Enabled = true;
            }
        }

        string FieldsValues(string BookingID)
        { //Fill up the combo boxes based on old booking details
            string status = "Not confirmed";
            DBConnect conn = new DBConnect();
            SqlConnection myconn = conn.GetSqlConnection();
            string sql = "Select CustomerID,Date,Type,Package,Hotel,Room,HotelNight,Status  from Booking  where ID=@ID";
            SqlCommand cmn = new SqlCommand(sql, myconn);
            cmn.Parameters.AddWithValue("@ID", BookingID);
            SqlDataReader dr;

            try
            {
                myconn.Open();
                dr = cmn.ExecuteReader();
                dr.Read();
                if (dr["Status"].ToString()== "Cancelled")
                {
                    status = "Cancelled";
                }
                else if (dr["Status"].ToString() == "Successful")
                {
                    status = "Successful";
                }
                else
                {
                    txtICPassport.Text = dr["CustomerID"].ToString();
                    cmbBooking.SelectedItem = dr["Type"].ToString();
                    cmbLocation.SelectedItem = dr["Package"].ToString();
                    dateTimePicker1.Value = DateTime.Parse(dr["Date"].ToString());
                    cmbHotel.SelectedItem = dr["Hotel"].ToString();
                    cmbRoom.SelectedItem = dr["Room"].ToString();
                    cmbNight.SelectedItem = dr["HotelNight"].ToString();
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
            return status;
        }

        private void button1_Click(object sender, EventArgs e)
        { // Reset the default values
            txtICPassport.Clear();
            cmbBooking.SelectedIndex=-1;
            txtICPassport.Focus();
        }

        private void gBoxDetails_Enter(object sender, EventArgs e)
        {

        }

        void HotelList()
        { // appear the whole hotels list
            DBConnect conn = new DBConnect();
            SqlConnection myconn = conn.GetSqlConnection();
            string sql = "Select HotelName from Hotel";
            SqlCommand cmn = new SqlCommand(sql, myconn);
            SqlDataReader dr;
            try
            {
                myconn.Open();
                dr = cmn.ExecuteReader();
                while (dr.Read())
                {
                    cmbHotel.Items.Add(dr["HotelName"].ToString());
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

        void HotelLocation(string location)
        { // appear list of hotels on combo box based on the location
            DBConnect conn = new DBConnect();
            SqlConnection myconn = conn.GetSqlConnection();
            string sql = "Select HotelName from Hotel where Location=@location";
            SqlCommand cmn = new SqlCommand(sql, myconn);
            cmn.Parameters.AddWithValue("@location", location);
            SqlDataReader dr;
            try
            {
                myconn.Open();
                dr = cmn.ExecuteReader();
                while (dr.Read())
                {
                    cmbHotel.Items.Add(dr["HotelName"].ToString());
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

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBooking.Text == "Tour Package & Hotel")
            {
                cmbHotel.Items.Clear();
                HotelLocation(cmbLocation.Text);
            }
        }
    }
}
