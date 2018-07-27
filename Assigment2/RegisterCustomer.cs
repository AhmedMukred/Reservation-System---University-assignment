using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assigment2
{
    public partial class RegisterCustomer : MetroFramework.Forms.MetroForm
    {
        public RegisterCustomer()
        {
            InitializeComponent();
        }


        void ClearAll()
        { // Method to clear all of the text boxes
            txtAddress.Clear();
            txtContactNumber.Clear();
            txtEmail.Clear();
            txtICPassport.Clear();
            txtName.Clear();
            txtICPassport.Focus();
        }

        public bool checkFields()
        { // Method to check if one of more of the text boxes is empty
            if (txtICPassport.Text.Equals(string.Empty) || txtName.Text.Equals(string.Empty)|| txtContactNumber.Text.Equals(string.Empty) || txtAddress.Text.Equals(string.Empty) || txtEmail.Text.Equals(string.Empty))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool EmailCheck(string emailAddress)
        { //Method to check if the entered email is correct
            string pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
            Match emailAddressMatch = Regex.Match(emailAddress, pattern);
            if (emailAddressMatch.Success)
            { return true; }
            else
            { return false; }
        }

        public bool NumberCheck(string ContactNumber)
        { // Method to check if the Contect Number text box only filled with numbers only
            if (int.TryParse(ContactNumber,out int number))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll(); //Clear all of the text boxes
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); //Close the Form
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (checkFields() == false)  // Check if any field is empty
            {
                //display error message
                MessageBox.Show("Please complete all of the fields","Empty Fields",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtICPassport.Focus();
            }
            else if (NumberCheck(txtContactNumber.Text) == false) //Check if ContactNumber text box is filled with only numbers
            {
                //display error message
                MessageBox.Show("Incorrect entered contact number. Please try again", "Invalid Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  txtContactNumber.Focus();
            }
            else if (EmailCheck(txtEmail.Text) == false) //Check if the entered email is correct or not
            {
                //display error message
                MessageBox.Show("Incorrect email entered. Please try again", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            }
            else
            { // Define a new connection to the database
                DBConnect db = new DBConnect(); //calling the data connectin class
                bool found = db.CheckCustomer(txtICPassport.Text); //checking the Customer ID
                if (found == true)
                {// Deisplay an error message if the customer has registerd before
                    MessageBox.Show("This customer had already registered before", "Existing Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtICPassport.Focus();
                }
                else
                { //Register a new customer
                    bool success = db.RegisterCustomer(txtICPassport.Text, txtName.Text, txtAddress.Text, int.Parse(txtContactNumber.Text), txtEmail.Text); // if the customer had not registered before will call the register method

                    if (success == true) //if the connection is happened
                    { //Display a message when the registeration is done successfully
                        DialogResult stay = new DialogResult();
                       stay = MessageBox.Show("Customer has registered sucessfully. Do you want to continue on registration form? ", "Successful Registeration",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                        if (stay == DialogResult.No) //check if the user wants to leave registeration form
                        {
                            this.Close(); //Close the form
                        }
                        else
                        {
                            ClearAll();   //clear all the form's feilds
                        }
                    }

                    else //if the connection is faild display the message
                    {
                        MessageBox.Show("The connection to the database is being faild","Faild Connection",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void RegisterCustomer_Activated(object sender, EventArgs e)
        { //Stop the enabled of the main form when this form is activated
            if (this.Owner != null)
            {
                this.Owner.Enabled = false;
            }
        }

        private void RegisterCustomer_Deactivate(object sender, EventArgs e)
        { //Allow the enabled of the main form when this form is deactivate
            if (this.Owner != null)
            {
                this.Owner.Enabled = true;
            }
        }

        private void RegisterCustomer_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None; //Change the border style of the form
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
