using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment2
{
    class hotelBooking : Booking
    {
        private string hotelName;
        private string room;
        private int night;
        public hotelBooking(string CustomerID, string BookingDate, string BookingType, string HotelName, string Room, int Night) : base(CustomerID, BookingDate, BookingType)
        {
            hotelName = HotelName;
            room = Room;
            night = Night;
        }

        public string GetHotelName
        {
            get { return hotelName; }
            set { hotelName = value; }
        }

        public string GetRoomType
        {
            get { return room; }
            set { room = value; }
        }

        public int GetNight
        {
            get { return night; }
            set { night = value; }
        }
    }
}
