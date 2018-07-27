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
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblShowname.Text = Form1.userName;
            if (Form1.userrRole != "admin")
            {
                settingsToolStripMenuItem.Enabled = false;
            }
            cmbStyles(); //Call the style method
            lblTime.Text = DateTime.Now.ToLongTimeString(); //sign the time to label
            lblDate.Text = DateTime.Now.ToLongDateString(); // sign the date to label
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Close;
            Close = MessageBox.Show("Are you sure you want to close this application?", "Close Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Close == DialogResult.Yes)
            {
                Application.Exit(); //Close the application
            }  
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
             
        }

        void cmbStyles()
        { // Set the default combo boxes styles
            cmbLocation.SelectedIndex = -1;
            cmbSearch.SelectedIndex = -1;
            cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            dataGVResult.Visible = false;
            dataGVHotel.Visible = false;
            lblHotel.Visible = false;
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        { //Define new register form
            RegisterCustomer Register = new RegisterCustomer();
            Register.ShowDialog(this);
        }

        private void newBookingToolStripMenuItem_Click(object sender, EventArgs e)
        { // Define new booking form
            Book book = new Book();
            book.ShowDialog(this);
        }

        private void editBookingToolStripMenuItem1_Click(object sender, EventArgs e)
        {// Define new update form
            Modify edit = new Modify();
            edit.ShowDialog(this);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        { //Message box to confirm loging out
            DialogResult Close;
            Close = MessageBox.Show("Are you sure you want to sign out?", "Sign Out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Close == DialogResult.Yes)
            {
                Application.Restart();//don't forget change first form is login form
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {// Sign the current time to label and start the timer
            lblTime.Text = DateTime.Now.ToLongTimeString(); 
            timer1.Start();
        }


        private void cancelBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {// Define new cancellation form
            Cancellation cancel = new Cancellation();
            cancel.ShowDialog(this);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {//Define new payment form
            Pay payment = new Pay();
            payment.ShowDialog(this);
        }

        private void btnEnter_Click_1(object sender, EventArgs e)
        {
            DBConnect Srch = new DBConnect(); //connect to database

            if (cmbSearch.Text == "Tour Package" && cmbLocation.SelectedIndex != -1)
            {
                dataGVResult.DataSource = Srch.Package(cmbLocation.Text); // result of Package
                dataGVHotel.DataSource = Srch.Hotel(cmbLocation.Text); // result of available hotels
                dataGVResult.Visible = true;
                lblHotel.Visible = true;
                dataGVHotel.Visible = true;
            }
            else if (cmbSearch.Text == "Hotel" && cmbLocation.SelectedIndex != -1)
            {
                dataGVResult.DataSource = Srch.HotelRoom(cmbLocation.Text); // result of available hotels
                dataGVResult.Visible = true;
                lblHotel.Visible = false;
                dataGVHotel.Visible = false;
            }
            else if (cmbSearch.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose the type of search", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            cmbStyles();
            dataGVResult.DataSource = null;
            dataGVHotel.DataSource = null;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report rep = new Report();
            rep.ShowDialog(this);
        }

        private void lblHotel_Click(object sender, EventArgs e)
        {

        }
    }
}
