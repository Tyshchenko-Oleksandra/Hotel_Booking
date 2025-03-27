using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Hotel.Classes
{
    class Hotel_5Star : Hotel
    {
        public override void ShowHotelRooms()
        {
            Console.WriteLine("Rooms: ");
        }

        public Hotel_5Star(string name, string location, string description, int id) : base(name, location, description, id)
        {
        }
    }
}
