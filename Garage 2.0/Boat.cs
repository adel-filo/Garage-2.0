public class Boat : Vehicle
{
    public double Length { get; set; }

    public Boat(string regNo, string color, int wheels, double length)
        : base(regNo, color, wheels)
    {
        Length = length;
    }
}