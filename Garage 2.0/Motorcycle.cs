public class Motorcycle : Vehicle
{
    public double CylinderVolume { get; set; }

    public Motorcycle(string regNo, string color, int wheels, double cylinderVolume)
        : base(regNo, color, wheels)
    {
        CylinderVolume = cylinderVolume;
    }
}