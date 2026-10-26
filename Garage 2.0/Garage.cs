using System;
using System.Collections.Generic;

public class Garage
{
    private List<Vehicle> vehicles;
    public int Capacity { get; private set; }

    public Garage(int capacity)
    {
        Capacity = capacity;
        vehicles = new List<Vehicle>();
    }

    public bool IsFull()
    {
        return vehicles.Count >= Capacity;
    }

    public bool IsRegistrationNumberTaken(string regNo)
    {
        for (int i = 0; i < vehicles.Count; i++)
        {
            if (vehicles[i].RegistrationNumber.Equals(regNo, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        if (IsFull() || IsRegistrationNumberTaken(vehicle.RegistrationNumber))
        {
            return false;
        }

        vehicles.Add(vehicle);
        return true;
    }

    public bool UnparkVehicle(string regNo)
    {
        for (int i = 0; i < vehicles.Count; i++)
        {
            if (vehicles[i].RegistrationNumber.Equals(regNo, StringComparison.OrdinalIgnoreCase))
            {
                vehicles.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public List<Vehicle> GetVehicles()
    {
        return vehicles;
    }
}