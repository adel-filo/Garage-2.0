public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }

    public Car(string regNo, string color, int wheels, int doors)
        : base(regNo, color, wheels)
    {
        NumberOfDoors = doors;
    }
}