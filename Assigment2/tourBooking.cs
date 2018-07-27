using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment2
{
    class tourBooking : Booking
    {
        private string tour;
        public tourBooking(string CustomerID, string BookingDate, string BookingType, string Tour) : base(CustomerID, BookingDate, BookingType)
        {
            tour = Tour;
        }

        public string GetTour
        {
            get { return tour; }
            set { tour = value; }
        }
    }
}