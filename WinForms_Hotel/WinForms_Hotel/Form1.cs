namespace WinForms_Hotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}

public abstract class BaseEntity
{
    public int Id { get; }
    protected BaseEntity(int id)
    {
        Id = id;
    }
}

abstract class Hotel : BaseEntity
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }

    public abstract void ShowHotelRooms();

    public virtual void ShowHotelInfo()
    {
        Console.WriteLine($"Готель: {Name}, Локація: {Location}, Опис: {Description}");
    }


    public Hotel(string name, string location, string description, int id) : base(id)
    {
        Name = name;
        Location = location;
        Description = description;
    }
}

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

interface IUser
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool Admin { get; set; }
}

class User : BaseEntity, IUser
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool Admin { get; set; }
    public User(string name, int id) : base(id)
    {
        Name = name;
    }
}

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

interface IBooking
{
    public void ConfirmBooking();
    public void CancelBooking();
}

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

    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Remove(T entity);
    }

    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected List<T> _entities = new List<T>();

        public List<T> GetAll()
        {
            return new List<T>(_entities); //ми повертаємо копію списку, для того щоб не було можливості змінити оригінальний список ззовні
        }

        public T GetById(int id)
        {
        return _entities.FirstOrDefault(e => e.Id == id);
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }
    }

    class HotelRepository<T> : GenericRepository<T> where T : Hotel
    {
        public T GetByName(string name)
        {
            return _entities.FirstOrDefault(h => h.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<T> GetAllSortedByName()
        {
            return _entities.OrderBy(h => h.Name).ToList();
        }

}
class RoomRepository<T> : GenericRepository<T> where T : Room
{
    public T GetByTypeOfRoom(string name)
    {
        return _entities.FirstOrDefault(r => r.TypeOfRoom.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public List<T> GetAllSortedByName()
    {
        return _entities.OrderBy(r => r.Price) as List<T>;
    }
}