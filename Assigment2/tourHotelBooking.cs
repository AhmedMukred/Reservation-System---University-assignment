using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment2
{
    class tourHotelBooking : hotelBooking
    {
        string tour;
        public tourHotelBooking(string CustomerID, string BookingDate, string BookingType, string Tour, string HotelName, string Room, int Night) : base(CustomerID, BookingDate, BookingType, HotelName, Room, Night)
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