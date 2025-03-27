using WinForms_Hotel.Classes;

namespace WinForms_Hotel
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            Hotel_5Star hotel1 = new Hotel_5Star("Radison", "Kyiv", "Luxury Hotel", 1);

            Room room1 = new Room("Lux", 4, 150, true, 1);
            Room room2 = new Room("Standart", 2, 70, false, 2);

            HotelRepository<Hotel_5Star> hotelRepository = new HotelRepository<Hotel_5Star>();
            hotelRepository.Add(hotel1);

            RoomRepository roomRepository = new RoomRepository();
            roomRepository.Add(room1);
            roomRepository.Add(room2);

            //Output
            Console.WriteLine("=== Всі готелі ===");
            foreach (var hotel in hotelRepository.GetAll())
            {
                hotel.ShowHotelInfo();
            }

            Console.WriteLine("\n=== Всі кімнати ===");
            foreach (var room in roomRepository.GetAll())
            {
                room.ShowRoomInfo();
            }

            Console.WriteLine("\n Пошук готелю за ID (1)");
            var hotelById = hotelRepository.GetById(1);
            hotelById?.ShowHotelInfo();

            Console.WriteLine("\nПошук кімнати за ID (2)");
            var roomById = roomRepository.GetById(2);
            roomById?.ShowRoomInfo();
        }
    }
}