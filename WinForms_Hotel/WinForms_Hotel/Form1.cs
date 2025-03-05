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
abstract class Hotel
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }

    public abstract void ShowHotelRooms();

    public virtual void ShowHotelInfo()
    {
        Console.WriteLine($"������: {Name}, �������: {Location}, ����: {Description}");
    }


    public Hotel(string name, string location, string description)
    {
        Name = name;
        Location = location;
        Description = description;
    }
}

interface IUser
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool Admin { get; set; }
}

class Room
{
    public string TypeOfRoom { get; }
    public int MaxGuests { get; }
    public float Price { get; set; }
    public bool Availability { get; set; }

    public virtual void ShowRoomInfo()
    {
        Console.WriteLine($"��� ������: {TypeOfRoom}, ʳ������ ������: {MaxGuests}, ����: {Price}, ����������: {Availability}");
    }


    public Room(string typeOfRoom, int maxGuests, float price, bool availability)
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

class Booking : IBooking
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
        Console.WriteLine("���������� ��������");
    }
    public void CancelBooking()
    {
        Status = "canceled";
        Console.WriteLine("���������� ���������");
    }
}
