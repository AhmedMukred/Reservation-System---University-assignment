using System;
using System.Windows.Forms;

namespace Assigment2
{
    public partial class Form1 : Form
    {
        public static string userName;
        public static string userrRole;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click_1(object sender, EventArgs e)
        { //check the method sign
            if (SignIn() == true)
            { //Start the timer & appear the progress bar
                this.timer1.Start(); 
                this.progressBar1.Visible = true;
                userName = txtUserName.Text;
            }
            else
            { //Appear the message if the username or password incorrect
                MessageBox.Show("Incorrect username or password. Please try again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Close the application
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {// Appear the password as characters
            if (chkView.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else // Appear the password as passowrd style
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        // Check if the username and password match with the list of users in the database
        public bool SignIn ()
        {
            bool flag = false;
            DBConnect dbc = new DBConnect(); //Define a new connection to database
            string role = dbc.VerifyUser(txtUserName.Text, txtPassword.Text); //sign the parameters to the method
            if (role == "Not found")
            {
                flag = false;
            }
            else
            {
                flag = true;
                userrRole = role;
            }
            return flag; //return the bool result
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100; //sign the maximum number of the progress bar
            progressBar1.Minimum = 0;
            this.progressBar1.Increment(3);

            if (progressBar1.Value==100)
            {
                timer1.Enabled = false;
                this.Visible = false;
                MainForm main = new MainForm(); //open the main form
                main.ShowDialog();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
