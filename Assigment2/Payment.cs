using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment2
{
    class Payment
    {
        private int bookingNo;
        private string type;
        private double amount;
        private string method;
        private DateTime date;

        public Payment(int BookingNo, string Type, double Amount, string Method, DateTime Date)
        {
            bookingNo = BookingNo;
            type = Type;
            amount = Amount;
            method = Method;
            date = Date;
        }

        public int GetBookingNo
        {
            get { return bookingNo; }
            set { bookingNo = value; }
        }

        public string Gettype
        {
            get { return type; }
            set { type = value; }
        }

        public double GetAmount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string GetMethod
        {
            get { return method; }
            set { method = value; }
        }

        public DateTime GetDate
        {
            get { return date; }
            set { date = value; }
        }
    }
}
