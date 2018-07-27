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
{ //booking function
    public partial class Book : MetroFramework.Forms.MetroForm
    {
        double TotalAmount;
        double Deposit;
        double Discount;
        double HotelCost;
        double TourCost;
        public Book()
        {
            InitializeComponent();
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            cmbStyles();
            // set the  properties of the date picker
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.MinDate = DateTime.Now.AddDays(4);
            dateTimePicker1.Value.ToShortDateString();

            //set the culture info
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("MS");
        }

        void cmbStyles()
        { //style of the defualt combo boxes on the form
            cmbBooking.SelectedIndex = -1;
            cmbHotel.SelectedIndex = -1;
            cmbLocation.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            cmbBooking.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHotel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            txtICPassport.Clear();
            txtICPassport.Focus();
            cmbHotel.Enabled = false;
            cmbRoom.Enabled = false;
            cmbLocation.Enabled = false;
            cmbNight.Enabled = false;
            cmbNight.SelectedIndex = -1;
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbBooking_SelectedIndexChanged(object sender, EventArgs e)
        { //Check the selected type of the booking and set the properties of some combo boxes in the form
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
            else if (cmbBooking.Text== "Hotel")
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            bool fields = checkFields(txtICPassport.Text); //check if the fields are empty or not
            if (fields == true)
            {
                bool found = CustChecking(txtICPassport.Text); //Check if the customer id exists in the customers list
                if (found == true)
                {
                    bool tour = TourChecking(cmbBooking.Text); //check the selected value of the tour combo box
                    if (tour == true)
                    {
                        bool hotelCheck = PackHotChecking(cmbBooking.Text); //check the selected value of the hotel combo boxes
                        if (hotelCheck == true)
                        {
                            // using connection class
                            DBConnect myconn = new DBConnect();
                            // appear details of the selected booking
                            gropbxDetails.Visible = true;
                            lblDetails.Text = $"{myconn.SelectCust(txtICPassport.Text)} Booking Type : \t \t {cmbBooking.Text} \n Tour Package : \t \t \t {cmbLocation.Text} \n Booking Date : \t \t {dateTimePicker1.Value.ToShortDateString()} \n Hotel : \t  {cmbHotel.Text}\n Room:\t {cmbRoom.Text}\n Night : {cmbNight.Text}";
                        }
                    }
                }
            }
        }


        bool checkFields(string ID)
        { //check if fields are empty or not
            bool success = true;
            if (ID.Equals(string.Empty) || cmbBooking.SelectedIndex == -1)
            {
                MessageBox.Show("Please complete all of the fields", "Uncomplete fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            return success;
        }

        bool CustChecking(string ID)
        {// check if the customer ID exist in the customers list
            bool Cust = true;
            DBConnect CusCheck = new DBConnect();
            bool success = CusCheck.CheckCustomer(ID);
            if (success == false)
            {
                Cust = false;
                DialogResult Cont;
                Cont = MessageBox.Show("This customer has not been registered before. Do you want to register a new customer?", "Invalid Customer's ID", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Cont == DialogResult.Yes)
                {
                    RegisterCustomer Register = new RegisterCustomer();
                    Register.Show();
                }
            }
            return Cust;
        }

        bool TourChecking(string Booking)
        { // Check the type of the booking if it is tour
            bool success = true;
            if (Booking == "Tour Package & Hotel" || Booking == "Tour Package")
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
        { // check the type of the booking if it is hotel
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


        private void Booking_Activated(object sender, EventArgs e)
        {//Stop the enabled of the main form when this form is activated
            if (this.Owner != null)
            {
                this.Owner.Enabled = false;
            }
        }

        private void Booking_Deactivate(object sender, EventArgs e)
        { //Allow the enabled of the main form when this form is deactivate
            if (this.Owner != null)
            {
                this.Owner.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        { //Close the form
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        { //reset the combo style
            cmbStyles();
        }

        void Successful(bool success)
        { // appear a message of successful booking and appear the details of booking from database
            if (success == true)
            {
                MessageBox.Show("Booking has record successfully", "Booking record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gropbxDetails.Visible = false;
                gropbxConfirm.Visible = true;
                SelectBooking(cmbBooking.Text);
            }
            else //if the connection is faild display the message
            {
                MessageBox.Show("Unable to record booking", "Booking record Faild", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBooking.Text == "Tour Package & Hotel")
            {
                cmbHotel.Items.Clear();
                HotelLocation(cmbLocation.Text);
            }
        }

        private void gropbxDetails_Enter(object sender, EventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            gropbxDetails.Visible = false;
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        { // Check the type of the booking and add it to the database
            if (cmbBooking.Text == "Tour Package")
            {
                DBConnect book = new DBConnect();
                bool success = book.TourBooking(txtICPassport.Text, dateTimePicker1.Text, cmbBooking.Text, cmbLocation.Text);
                Successful(success);
            }

            else if (cmbBooking.Text == "Tour Package & Hotel")
            {
                DBConnect book = new DBConnect();
                bool success = book.Booking(txtICPassport.Text, dateTimePicker1.Text, cmbBooking.Text, cmbLocation.Text, cmbHotel.Text, cmbRoom.Text, int.Parse(cmbNight.Text));
                Successful(success);
            }
            else if (cmbBooking.Text == "Hotel")
            {
                DBConnect book = new DBConnect();
                bool success = book.HotelBooking(txtICPassport.Text, dateTimePicker1.Text, cmbBooking.Text, cmbHotel.Text, cmbRoom.Text, int.Parse(cmbNight.Text));
                Successful(success);
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        void SelectBooking(string Type)
        { // select the successful booking from the database
            DBConnect conn = new DBConnect();
            SqlConnection myconn = conn.GetSqlConnection();
            SqlCommand cmn;
            SqlDataReader dr;
            string sql = "select b.ID,b.CustomerID,b.Type,b.Date,b.Total,b.Discount,p.Cost,(hr.Price*b.HotelNight),b.Deposit from Booking b, Hotel h, HotelRoom hr,Package p where b.Package=p.Package and b.Hotel=h.HotelName and b.Room=hr.Room and h.HotelName=hr.Hotel and b.id=(select Max(ID) from Booking)";
            if (Type == "Hotel")
            {
                sql = "select b.ID,b.CustomerID,b.Type,b.Date,b.Total,b.Discount,(hr.Price*b.HotelNight) from Booking b, Hotel h, HotelRoom hr where b.Hotel=h.HotelName and b.Room=hr.Room and h.HotelName=hr.Hotel and b.id=(select Max(ID) from Booking)";
            }
            else if (Type == "Tour Package")
            {
                sql = "select b.ID,b.CustomerID,b.Type,b.Date,b.Total,b.Discount,p.Cost,b.Deposit from Booking b, Package p where b.Package=p.Package and b.id=(select Max(ID) from Booking)";
            }
            try
            {
                cmn = new SqlCommand(sql, myconn);
                myconn.Open();
                dr = cmn.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    TotalAmount = double.Parse(dr[4].ToString()) - double.Parse(dr[5].ToString());
                    Discount = double.Parse(dr[5].ToString());
                    lblBooking.Text = dr[0].ToString();
                    lblCustomerID.Text = dr[1].ToString();
                    lblType.Text = dr[2].ToString();
                    DateTime date = DateTime.Parse(dr[3].ToString());
                    lblDate.Text = date.ToShortDateString();
                    lblTotal.Text = TotalAmount.ToString("C2");
                    lblDiscount.Text = Discount.ToString("C2");
                    if(Type== "Tour Package & Hotel")
                    {
                        TourCost = double.Parse(dr[6].ToString());
                        lblTour.Text = TourCost.ToString("C2");
                        HotelCost = double.Parse(dr[7].ToString());
                        lblHotel.Text = HotelCost.ToString("C2");
                        lblDeposit.Visible = true;
                        labelDeposit.Visible = true;
                        Deposit = double.Parse(dr[8].ToString());
                        lblDeposit.Text = Deposit.ToString("C2");
                        lblNote.Visible = true;
                    }
                    else if (Type == "Hotel")
                    {
                        TourCost = 0;
                        lblTour.Text = TourCost.ToString("C2");
                        HotelCost = double.Parse(dr[6].ToString());
                        lblHotel.Text = HotelCost.ToString("C2");
                    }
                    else if (Type== "Tour Package")
                    {
                        TourCost = double.Parse(dr[6].ToString());
                        lblTour.Text = TourCost.ToString("C2");
                        HotelCost = 0;
                        lblHotel.Text = HotelCost.ToString("C2");
                        lblDeposit.Visible = true;
                        labelDeposit.Visible = true;
                        Deposit = double.Parse(dr[7].ToString());
                        lblDeposit.Text = Deposit.ToString("C2");
                        lblNote.Visible = true;
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

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        { 
            DialogResult close;
            close = MessageBox.Show("Do you want to make a payment?", "Payment Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (close == DialogResult.Yes)
            {
                Pay payment = new Pay();
                payment.ShowDialog(this);
            }
            else
            {
                this.Close();
            }

        }

        private void gropbxConfirm_Enter(object sender, EventArgs e)
        {

        }

        private void lblDetails_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void lblDeposit_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
