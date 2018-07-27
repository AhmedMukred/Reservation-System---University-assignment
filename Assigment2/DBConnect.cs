using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Assigment2
{
    class DBConnect
    {
        public SqlConnection GetSqlConnection()
        {

            string conn;
            conn = @"Server=tcp:tp043087.database.windows.net,1433;Database=Booking;User ID=AhmedKhalil;Password=tP.043087;Encrypt=True;TrustServerCertificate=False;";
            return new SqlConnection(conn);
        }

        public string VerifyUser(string UserName, string Password)  // Verify & check if the username and password match the list of users during login process
        {
            string role = "Not found";
            SqlConnection myconn = GetSqlConnection();  //connect to SQL server
            string sql = "Select * From Users Where Username=@username and Password=@Pwd"; //select the list of users from the database
            SqlCommand cmn = new SqlCommand(sql, myconn);
            cmn.Parameters.AddWithValue("@username", UserName); //add parameters to the command
            cmn.Parameters.AddWithValue("@pwd", Password);

            try
            {
                myconn.Open(); //open the conection
                SqlDataReader dr = cmn.ExecuteReader();

                if (dr.HasRows) // check if the entered user has values in the database
                {
                    dr.Read();
                    role = dr["Role"].ToString();//sign the value of user role
                }
                else
                {
                    role = "Not found";
                }
            }
            catch (SqlException ex)
            {   //display on the console the exeception message
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
            finally
            {
                myconn.Close(); //close the connection
            }
            return role;//return the user role
        }

        public bool CheckCustomer(string ID)
        { //Check if the customer is already in the customer list based on IC/Passport Number
            SqlConnection myconn = GetSqlConnection();
            bool found = false;
            string sql = "Select * from customer where ID=@IDNumber";
            SqlCommand cmd = new SqlCommand(sql, myconn);

            //defines the parameters for the select query
            cmd.Parameters.AddWithValue("@IDNumber", ID);

            try
            {
                myconn.Open(); //opens the connection
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    found = true;
                }
                else
                {
                    found = false;
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
            return found;
        }

        public bool RegisterCustomer(string IDNumber, string Name, string Address, int ContactNumber, string Email)
        { //register a new customer
            int add;
            bool flag = false;
            SqlConnection myconn = GetSqlConnection();

            //using customer class
            Customer cust = new Customer(IDNumber, Name, Address, ContactNumber, Email);

            string sql = "Insert into Customer values(@IDNumber,@Name,@Address,@Number,@Email)";
            SqlCommand cmd = new SqlCommand(sql, myconn);

            //defines the parameters for the query
            cmd.Parameters.AddWithValue("@IDNumber", cust.GetIcPassport);
            cmd.Parameters.AddWithValue("@Name", cust.GetName);
            cmd.Parameters.AddWithValue("@Address", cust.GetAddress);
            cmd.Parameters.AddWithValue("@Number", cust.GetContactNumber);
            cmd.Parameters.AddWithValue("@Email", cust.GetEmail);

            try
            {
                myconn.Open(); //opens the connection
                add = cmd.ExecuteNonQuery();//executes the sql command
                if (add >= 1)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
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

            return flag;
        }

        public DataTable Hotel(string Location)
        { //Using Datatable to select the whole list of the hotel to disply on the search section based on the location
            SqlConnection myconn = GetSqlConnection();

            //Define new datatable
            DataTable searchList = new DataTable();
            string sql = "Select HotelName from hotel where Location=@location";
            SqlCommand cmd = new SqlCommand(sql, myconn);
            cmd.Parameters.AddWithValue("@location", Location);

            try
            {
                myconn.Open(); //Open the connection
                SqlDataReader dr = cmd.ExecuteReader(); //Excute the Sql command
                if (dr.HasRows)
                {
                    searchList.Load(dr); //Load the list into the datatable
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

            return searchList;  //Return the datatable
        }

        public DataTable HotelRoom(string Location)
        { //Using Datatable to select the whole list of the hotel and different rooms to disply on the search section

            SqlConnection myconn = GetSqlConnection();

            // Define a datatable
            DataTable searchList = new DataTable();
            string sql = "select ID,Hotel,Room,Price from HotelRoom,Hotel where HotelRoom.Hotel=Hotel.HotelName and Location=@location;";
            SqlCommand cmd = new SqlCommand(sql, myconn);
            cmd.Parameters.AddWithValue("@location", Location);

            try
            { //Open the connection
                myconn.Open();
                SqlDataReader dr = cmd.ExecuteReader(); //Excute the command
                if (dr.HasRows)
                {
                    searchList.Load(dr); //Load the list into the datatable
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

            return searchList; //Return the datatable
        }

        public DataTable Package(string Location)
        { //Using Datatable to select the list of the tour packages to disply on the search section
            SqlConnection myconn = GetSqlConnection();

            //Define a new datatable
            DataTable searchList = new DataTable();
            string sql = "select * from Package where Package=@location;";
            SqlCommand cmd = new SqlCommand(sql, myconn);
            cmd.Parameters.AddWithValue("@location", Location);

            try
            { // Open the connection
                myconn.Open();
                SqlDataReader dr = cmd.ExecuteReader(); //Excute the command
                if (dr.HasRows)
                {
                    searchList.Load(dr); //Load the list into the datatable
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

            return searchList; // Return the datatable
        }

        public string SelectCust(string CustomerID)
        { //checking if the customer has registered and recorded in the customers list
            DBConnect conn = new DBConnect();
            SqlConnection myconn = conn.GetSqlConnection();
            string Customer = "";
            string sql = "Select ID,Name,ContactNumber from Customer where ID=@ID";
            SqlCommand cmn = new SqlCommand(sql, myconn);
            cmn.Parameters.AddWithValue("@ID", CustomerID);
            SqlDataReader dr;

            try
            {
                myconn.Open();
                dr = cmn.ExecuteReader();
                dr.Read();
                Customer = $" Customer ID : \t \t \t {dr[0].ToString()} \n Customer Name : \t\t {dr[1].ToString()} \n Contact Number : \t\t { dr[2].ToString()} \n";
            }
            catch (SqlException ex)
            {//display on the console the exeception message
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
            finally
            {
                myconn.Close();
            }
            return Customer;
        }

        public bool Booking(string ID, string BookingDate, string BookingType, string Tour, string Hotel, string Room, int Night)
        {
            SqlConnection myconn = GetSqlConnection();
            int add;
            bool flag = false;
            string sql = "Insert into Booking(CustomerID, Date, Type, Package, Hotel, Room, HotelNight) values (@ID,@BookingDate,@BookingType,@Tour,@Hotel,@Room,@Night)";

            //Using Booking Class
            tourHotelBooking th = new tourHotelBooking(ID, BookingDate, BookingType, Tour, Hotel, Room, Night);

            //define sql command and parameters
            SqlCommand cmd = new SqlCommand(sql, myconn);
            cmd.Parameters.AddWithValue("@ID", th.GetCustomerID);
            cmd.Parameters.AddWithValue("@BookingType", th.GetBookingType);
            cmd.Parameters.AddWithValue("@Tour", th.GetTour);
            cmd.Parameters.AddWithValue("@BookingDate", th.GetDate);
            cmd.Parameters.AddWithValue("@Hotel", th.GetHotelName);
            cmd.Parameters.AddWithValue("@Room", th.GetRoomType);
            cmd.Parameters.AddWithValue("@Night", th.GetNight);

            try
            {
                myconn.Open(); //opens the connection
                add = cmd.ExecuteNonQuery();//executes the sql command
                if (add >= 1)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
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
            if (flag == true)
            { //counting the discount and update the record in the database
                double discount = 0;
                sql = "update Booking set discount= (select ((p.Cost+ (hr.Price* b.HotelNight))*@Discount) from Booking b,Package p,Hotel h,HotelRoom hr where p.Package=b.Package and b.Hotel=h.HotelName and b.Room=hr.Room and h.HotelName=hr.Hotel and b.ID=(select MAX(ID) from Booking)), Deposit=(select (p.Cost * 0.2) from Booking b,Package p where p.Package=b.Package and b.ID=(select MAX(ID) from Booking)), Total=(select (p.Cost + (hr.Price* b.HotelNight)+ b.Charge) from Booking b,Package p,Hotel h,HotelRoom hr where p.Package=b.Package and b.Hotel=h.HotelName and b.Room=hr.Room and h.HotelName=hr.Hotel and b.ID=(select MAX(ID) from Booking)) where ID=(select MAX(ID) from Booking)";
                SqlCommand cmn = new SqlCommand(sql, myconn);
                if (Room == "Single")
                {
                    discount = 0.1;
                }
                else if (Room == "Double Bed")
                {
                    discount = 0.2;
                }
                else if (Room == "Family Suite")
                {
                    discount = 0.4;
                }
                cmn.Parameters.AddWithValue("@Discount", discount);

                try
                {
                    myconn.Open(); //opens the connection
                    add = cmn.ExecuteNonQuery();//executes the sql command
                    if (add >= 1)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
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
            return flag;
        }

        public bool TourBooking(string ID, string BookingDate, string BookingType, string Tour)
        {
            SqlConnection myconn = GetSqlConnection();
            int add;
            bool flag = false;
            string sql = "Insert into Booking (CustomerID, Date, Type, Package, Hotel, Room) values (@ID,@BookingDate,@BookingType,@Tour,@Hotel,@Room)";

            //Using Booking Class
            tourBooking tr = new tourBooking(ID, BookingDate, BookingType, Tour);

            //define sql command and parameters

            SqlCommand cmd = new SqlCommand(sql, myconn);
            cmd.Parameters.AddWithValue("@ID", tr.GetCustomerID);
            cmd.Parameters.AddWithValue("@BookingType", tr.GetBookingType);
            cmd.Parameters.AddWithValue("@Tour", tr.GetTour);
            cmd.Parameters.AddWithValue("@BookingDate", tr.GetDate);
            cmd.Parameters.AddWithValue("@Hotel", DBNull.Value);
            cmd.Parameters.AddWithValue("@Room", DBNull.Value);
            try
            {
                myconn.Open(); //opens the connection
                add = cmd.ExecuteNonQuery();//executes the sql command
                if (add >= 1)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
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

            if (flag == true)
            { // Count the totalamount of the booking
                sql = "update Booking set Deposit=(select (cost *(0.2)) from Booking b, Package p where p.Package=b.Package and b.ID=(select MAX(ID) from Booking)),Total=(select cost from Booking b, Package p where p.Package=b.Package and b.ID=(select MAX(ID) from Booking)) where ID=(select MAX(ID) from Booking)";
                SqlCommand cmn = new SqlCommand(sql, myconn);
                try
                {
                    myconn.Open(); //opens the connection
                    add = cmn.ExecuteNonQuery();//executes the sql command
                    if (add >= 1)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
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

            return flag;
        }

        public bool HotelBooking(string ID, string BookingDate, string BookingType, string Hotel, string Room, int Night)
        {
            SqlConnection myconn = GetSqlConnection();
            int add;
            bool flag = false;
            string sql = "Insert into Booking (CustomerID, Date, Type, Package, Hotel, Room, HotelNight) values (@ID,@BookingDate,@BookingType,@Location,@Hotel,@Room,@Night)";

            //Using Booking Class
            hotelBooking ht = new hotelBooking(ID, BookingDate, BookingType, Hotel, Room, Night);

            //define sql command and parameters
            SqlCommand cmd = new SqlCommand(sql, myconn);
            cmd.Parameters.AddWithValue("@ID", ht.GetCustomerID);
            cmd.Parameters.AddWithValue("@BookingType", ht.GetBookingType);
            cmd.Parameters.AddWithValue("@Location", DBNull.Value);
            cmd.Parameters.AddWithValue("@BookingDate", ht.GetDate);
            cmd.Parameters.AddWithValue("@Hotel", ht.GetHotelName);
            cmd.Parameters.AddWithValue("@Room", ht.GetRoomType);
            cmd.Parameters.AddWithValue("@Night", ht.GetNight);
            try
            {
                myconn.Open(); //opens the connection
                add = cmd.ExecuteNonQuery();//executes the sql command
                if (add >= 1)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
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

            if (flag == true)
            {//counting the totalamount of booking
                sql = "update Booking set Total =(select (hr.Price * b.HotelNight) from Booking b,Hotel h, HotelRoom hr where b.Hotel = H.HotelName and h.HotelName = hr.Hotel and b.Room = hr.Room and b.ID = (select MAX(ID) from Booking)) where ID = (select MAX(ID) from Booking)";
                SqlCommand cmn = new SqlCommand(sql, myconn);
                try
                {
                    myconn.Open(); //opens the connection
                    add = cmn.ExecuteNonQuery();//executes the sql command
                    if (add >= 1)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
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
            else
            {
                flag = false;
            }

            return flag;
        }

        public bool CheckBooking(string BookingNO)
        {// Check if the booking exists in the booking list
            SqlDataReader dr;
            SqlConnection myconn = GetSqlConnection();
            DataTable dt = new DataTable();
            bool flag = false;
            string sql = "Select * from Booking where ID=@BookingNO";
            SqlCommand cmd = new SqlCommand(sql, myconn);
            cmd.Parameters.AddWithValue("@BookingNO", BookingNO);

            myconn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            myconn.Close();
            return flag;
        }

        public bool UpdateTourBooking(string BookingID, string CustomerID, string BookingDate, string BookingType, string Tour)
        {
            SqlConnection myconn = GetSqlConnection();
            int update;
            bool flag = false;

            //update statment
            string sql = "Update Booking set CustomerID=@CustomerID,Date=@date,type=@type,Package=@Package,Hotel=@hotel,Room=@room,HotelNight=@night where ID=@ID";
            //Using Booking Class
            tourBooking tr = new tourBooking(CustomerID, BookingDate, BookingType, Tour);

            //define sql command and parameters

            SqlCommand cmd = new SqlCommand(sql, myconn);
            cmd.Parameters.AddWithValue("@ID", BookingID);
            cmd.Parameters.AddWithValue("@CustomerID", tr.GetCustomerID);
            cmd.Parameters.AddWithValue("@date", tr.GetDate);
            cmd.Parameters.AddWithValue("@type", tr.GetBookingType);
            cmd.Parameters.AddWithValue("@Package", tr.GetTour);
            cmd.Parameters.AddWithValue("@hotel", DBNull.Value);
            cmd.Parameters.AddWithValue("@room", DBNull.Value);
            cmd.Parameters.AddWithValue("@night", DBNull.Value);

            try
            {
                myconn.Open(); //opens the connection
                update = cmd.ExecuteNonQuery();//executes the sql command
                if (update >= 1)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
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
            if (flag == true)
            { // Counting the deposit, amount and update the record in the database
                sql = "update Booking set Charge=0, Discount=0, Deposit=(select (cost *(0.2)) from Booking b, Package p where p.Package=b.Package and b.ID=@ID),Total=(select cost from Booking b, Package p where p.Package=b.Package and b.ID=@ID) where ID=@ID";
                SqlCommand cmn = new SqlCommand(sql, myconn);
                cmn.Parameters.AddWithValue("@ID", BookingID);
                try
                {
                    myconn.Open(); //opens the connection
                    update = cmn.ExecuteNonQuery();//executes the sql command
                    if (update >= 1)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
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

            return flag;
        }

        public bool UpdateHotelBooking(string BookingID, string CustomerID, string BookingDate, string BookingType, string Hotel, string Room, int Night)
        {
            SqlConnection myconn = GetSqlConnection();
            int update;
            bool flag = false;

            //update statment
            string sql = "Update Booking set CustomerID=@CustomerID,Date=@date,type=@type,Package=@Package,Hotel=@hotel,Room=@room,HotelNight=@night where ID=@ID";

            //Using Booking Class
            hotelBooking ht = new hotelBooking(CustomerID, BookingDate, BookingType, Hotel, Room, Night);

            //define sql command and parameters

            SqlCommand cmd = new SqlCommand(sql, myconn);
            cmd.Parameters.AddWithValue("@ID", BookingID);
            cmd.Parameters.AddWithValue("@CustomerID", ht.GetCustomerID);
            cmd.Parameters.AddWithValue("@date", ht.GetDate);
            cmd.Parameters.AddWithValue("@type", ht.GetBookingType);
            cmd.Parameters.AddWithValue("@Package", DBNull.Value);
            cmd.Parameters.AddWithValue("@hotel", ht.GetHotelName);
            cmd.Parameters.AddWithValue("@room", ht.GetRoomType);
            cmd.Parameters.AddWithValue("@night", ht.GetNight);

            try
            {
                myconn.Open(); //opens the connection
                update = cmd.ExecuteNonQuery();//executes the sql command
                if (update >= 1)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
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
            if (flag == true)
            { //counting the amount and update the record in the database
                sql = "update Booking set charge=0, Discount=0, Deposit=0, Total =(select (hr.Price * b.HotelNight) from Booking b,Hotel h, HotelRoom hr where b.Hotel = H.HotelName and h.HotelName = hr.Hotel and b.Room = hr.Room and b.ID =@ID) where ID = @ID";
                SqlCommand cmn = new SqlCommand(sql, myconn);
                cmn.Parameters.AddWithValue("@ID", BookingID);
                try
                {
                    myconn.Open(); //opens the connection
                    update = cmn.ExecuteNonQuery();//executes the sql command
                    if (update >= 1)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
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
            return flag;
        }

        public bool UpdateBooking(string BookingID, string CustomerID, string BookingDate, string BookingType, string Tour, string Hotel, string Room, int Night)
        {
            SqlConnection myconn = GetSqlConnection();
            int update;
            bool flag = false;

            // Update statment
            string sql = "Update Booking set CustomerID=@CustomerID,Date=@date,type=@type,Package=@Package,Hotel=@hotel,Room=@room,HotelNight=@night where ID=@ID";

            //Using Booking Class
            tourHotelBooking th = new tourHotelBooking(CustomerID, BookingDate, BookingType, Tour, Hotel, Room, Night);

            //define sql command and parameters

            SqlCommand cmd = new SqlCommand(sql, myconn);
            cmd.Parameters.AddWithValue("@ID", BookingID);
            cmd.Parameters.AddWithValue("@CustomerID", th.GetCustomerID);
            cmd.Parameters.AddWithValue("@date", th.GetDate);
            cmd.Parameters.AddWithValue("@type", th.GetBookingType);
            cmd.Parameters.AddWithValue("@Package", th.GetTour);
            cmd.Parameters.AddWithValue("@hotel", th.GetHotelName);
            cmd.Parameters.AddWithValue("@room", th.GetRoomType);
            cmd.Parameters.AddWithValue("@night", th.GetNight);


            try
            {
                myconn.Open(); //opens the connection
                update = cmd.ExecuteNonQuery();//executes the sql command
                if (update >= 1)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
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
            if (flag == true)
            { //counting the discount, deposit, amount and update the record in the database
                double discount = 0;
                sql = "update Booking set charge=0, discount= (select ((p.Cost+ (hr.Price* b.HotelNight))*@Discount) from Booking b,Package p,Hotel h,HotelRoom hr where p.Package=b.Package and b.Hotel=h.HotelName and b.Room=hr.Room and h.HotelName=hr.Hotel and b.ID=@ID), Deposit=(select (p.Cost * 0.2) from Booking b,Package p where p.Package=b.Package and b.ID=@ID), Total=(select (p.Cost + (hr.Price* b.HotelNight)+ b.Charge) from Booking b,Package p,Hotel h,HotelRoom hr where p.Package=b.Package and b.Hotel=h.HotelName and b.Room=hr.Room and h.HotelName=hr.Hotel and b.ID=@ID) where ID=@ID";
                SqlCommand cmn = new SqlCommand(sql, myconn);
                cmn.Parameters.AddWithValue("@ID", BookingID);
                if (Room == "Single")
                {
                    discount = 0.1;
                }
                else if (Room == "Double Bed")
                {
                    discount = 0.2;
                }
                else if (Room == "Family Suite")
                {
                    discount = 0.4;
                }
                cmn.Parameters.AddWithValue("@Discount", discount);

                try
                {
                    myconn.Open(); //opens the connection
                    update = cmn.ExecuteNonQuery();//executes the sql command
                    if (update >= 1)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
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
            return flag;
        }


        public bool CancelBooking(string BookingNo)
        {
            bool flag = false;

            // Check the cancellation Policy
            bool success = CheckCancelPolicy(BookingNo);

            if (success == true)
            { // Cancel the booking and update the record in the database

                int update;
                SqlConnection myconn = GetSqlConnection();
                string sql = "update Booking set Status='Cancelled' where ID=@ID";
                SqlCommand cmn = new SqlCommand(sql, myconn);
                cmn.Parameters.AddWithValue("@ID", BookingNo);
                try
                {
                    myconn.Open(); //opens the connection
                    update = cmn.ExecuteNonQuery();//executes the sql command
                    if (update >= 1)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
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
            else
            {
                flag = false;
            }
            return flag;
        }

        bool CheckCancelPolicy(string BookingNo)
        { // Method is used to check the cancellation policy
            DateTime BookingDate = new DateTime();
            string date;
            bool flag = false;
            SqlConnection myconn = GetSqlConnection();
            string sql = "Select date from Booking where ID=@ID";
            SqlCommand cmn = new SqlCommand(sql, myconn);
            cmn.Parameters.AddWithValue("@ID", BookingNo);
            try
            {
                myconn.Open(); //opens the connection
                SqlDataReader dr = cmn.ExecuteReader();//executes the sql command
                if (dr.HasRows)
                {
                    dr.Read();
                    date = dr["Date"].ToString();
                    BookingDate.ToShortDateString();
                    BookingDate = Convert.ToDateTime(date);
                    DateTime TodayDate = DateTime.Now;
                    TodayDate.ToShortDateString();
                    if ((BookingDate - TodayDate).TotalDays > 4)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
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
            return flag;
        }

        string CheckCharge(string BookingNo)
        { //Method is used to check if the payment is late or not
            string status = "";
            SqlConnection myconn = GetSqlConnection();
            string sql = "select * from booking where ID=@ID";
            SqlCommand cmn = new SqlCommand(sql, myconn);
            cmn.Parameters.AddWithValue("@ID", BookingNo);
            SqlDataReader dr;
            try
            {
                myconn.Open(); //opens the connection
                dr = cmn.ExecuteReader();//executes the sql command
                if (dr.HasRows)
                {
                    dr.Read();
                    DateTime BookingDate = new DateTime();
                    BookingDate.ToShortDateString();
                    BookingDate = Convert.ToDateTime(dr["Date"].ToString());
                    DateTime TodayDate = DateTime.Now;
                    TodayDate.ToShortDateString();

                    // Check the diiferent days between booking date and cuurrent date
                    if (dr["Status"].ToString() == "Not Confirmed" && ((BookingDate - TodayDate).TotalDays < 3))
                    {
                        status = "Late Not Confirmed";
                    }
                    else if (dr["Status"].ToString() == "Confirmed" && ((BookingDate - TodayDate).TotalDays < 3))
                    {
                        status = "Late Confirmed";
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
            return status;
        }

        public bool updateChargeTotal(string BookingNo)
        {
            int count;
            bool flag = false;
            SqlConnection myconn = GetSqlConnection();
            SqlCommand cmn;
            string sql = "";
            string status = CheckCharge(BookingNo);

            if (status == "Late Confirmed")
            {
                sql = "Update Booking set Charge=50, DepositStatus='forfeited' where ID=@ID";
            }
            else if (status == "Late Not Confirmed")
            {
                sql = "Update Booking set Charge=50 where ID=@ID";
            }
            else
            {
                sql = "Update Booking set Charge=0 where ID=@ID";
            }
            cmn = new SqlCommand(sql, myconn);
            cmn.Parameters.AddWithValue("@ID", BookingNo);
            try
            {
                myconn.Open(); //opens the connection
                count = cmn.ExecuteNonQuery();//executes the sql command
                if (count >= 1)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
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
            return flag;
        }

        public bool MakePayment(int BookingNo, string Type, double price, string Method, DateTime date)
        {
            SqlConnection myconn = GetSqlConnection();
            int add;
            bool flag = false;

            //Using payment class
            Payment pmt = new Payment(BookingNo, Type, price, Method, date);

            string sql = "Insert into Payment (BookingNo, Type, Amount, PaymentMethod, Date) values (@BookingNo,@Type,@Price,@PaymentMethod,@Date)";
            SqlCommand cmd = new SqlCommand(sql, myconn);
            cmd.Parameters.AddWithValue("@BookingNo", pmt.GetBookingNo);
            cmd.Parameters.AddWithValue("@Type", pmt.Gettype);
            cmd.Parameters.AddWithValue("@Price", pmt.GetAmount);
            cmd.Parameters.AddWithValue("@PaymentMethod", pmt.GetMethod);
            cmd.Parameters.AddWithValue("@Date", pmt.GetDate);
            try
            {
                myconn.Open(); //opens the connection
                add = cmd.ExecuteNonQuery();//executes the sql command
                if (add >= 1)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
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

            if (flag == true)
            {
                sql = "Update booking set TotalPaid=(select sum(Amount) from payment where BookingNo=@BookingNo) where id=@BookingNo";
                cmd = new SqlCommand(sql, myconn);
                cmd.Parameters.AddWithValue("@BookingNo", BookingNo);
                try
                {
                    myconn.Open(); //opens the connection
                    add = cmd.ExecuteNonQuery();//executes the sql command
                    if (add >= 1)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
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
            else
            {
                flag = false;
            }

            if (flag == true)
            {
                if (Type == "Total")
                {
                    sql = "update booking set Status='Successful' where TotalPaid>=Total and ID=@BookingNo";
                }
                else if (Type == "Deposit")
                {
                    sql = "update booking set Status='Confirmed' where ID=@BookingNo";
                }
                cmd = new SqlCommand(sql, myconn);
                cmd.Parameters.AddWithValue("@BookingNo", BookingNo);
                try
                {
                    myconn.Open(); //opens the connection
                    add = cmd.ExecuteNonQuery();//executes the sql command
                    if (add >= 1)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
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
            else
            {
                flag = false;
            }

            return flag;
        }
    }
}
