public class Bus : Vehicle
{
    public int NumberOfSeats { get; set; }

    public Bus(string regNo, string color, int wheels, int seats)
        : base(regNo, color, wheels)
    {
        NumberOfSeats = seats;
    }
}