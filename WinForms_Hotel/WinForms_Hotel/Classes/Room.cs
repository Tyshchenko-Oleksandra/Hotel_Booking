using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_Hotel.Classes
{
    class Room : BaseEntity
    {
        public string TypeOfRoom { get; }
        public int MaxGuests { get; }
        public float Price { get; set; }
        public bool Availability { get; set; }

        public virtual void ShowRoomInfo()
        {
            Console.WriteLine($"Тип номера: {TypeOfRoom}, Кількість гостей: {MaxGuests}, ціна: {Price}, доступність: {Availability}");
        }


        public Room(string typeOfRoom, int maxGuests, float price, bool availability, int id) : base(id)
        {
            TypeOfRoom = typeOfRoom;
            MaxGuests = maxGuests;
            Price = price;
            Availability = availability;
        }
    }
}
