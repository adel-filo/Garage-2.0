public class Airplane : Vehicle
{
    public int NumberOfEngines { get; set; }

    public Airplane(string regNo, string color, int wheels, int engines)
        : base(regNo, color, wheels)
    {
        NumberOfEngines = engines;
    }
}