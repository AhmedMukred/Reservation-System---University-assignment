using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment2
{
    class Booking
    {
        private string customerID;
        private string bookingType;
        private string bookingDate;

        public Booking(string CustomerID, string BookingDate, string BookingType)
        {
            customerID = CustomerID;
            bookingType = BookingType;
            bookingDate = BookingDate;
        }

        public string GetCustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string GetBookingType
        {
            get { return bookingType; }
            set { bookingType = value; }
        }

        public string GetDate
        {
            get { return bookingDate; }
            set { bookingDate = value; }
        }
    }
}
