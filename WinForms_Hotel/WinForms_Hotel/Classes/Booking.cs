using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms_Hotel.Interfaces;

namespace WinForms_Hotel.Classes
{
    class Booking : BaseEntity, IBooking
    {
        public Hotel Hotel { get; set; }
        public IUser User { get; set; }
        public Room Room { get; set; }
        public string DateIn { get; set; }
        public string DateOut { get; set; }
        public string Status { get; set; }

        public void ConfirmBooking()
        {
            Status = "booked";
            Console.WriteLine("Бронювання виконане");
        }
        public void CancelBooking()
        {
            Status = "canceled";
            Console.WriteLine("Бронювання скасоване");
        }

        public Booking(Hotel hotel, IUser user, Room room, string dateIn, string dateOut, string status, int id) : base(id)
        {
            Hotel = hotel;
            User = user;
            Room = room;
            DateIn = dateIn;
            DateOut = dateOut;
            Status = status;
        }
    }
}
