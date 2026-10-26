using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static Garage garage;

    static void Main(string[] args)
    {
        int capacity = 0;
        while (true)
        {
            Console.Write("Enter capacity for the new garage: ");
            if (int.TryParse(Console.ReadLine(), out capacity) && capacity > 0)
            {
                garage = new Garage(capacity);
                Console.WriteLine($"A garage with space for {capacity} vehicles has been created.");
                break;
            }
            Console.WriteLine("Invalid input! Please enter a valid positive number.");
        }

        PopulateDefaultVehicles();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- GARAGE MENU ---");
            Console.WriteLine("1. List all parked vehicles");
            Console.WriteLine("2. List vehicle types and counts");
            Console.WriteLine("3. Park vehicle");
            Console.WriteLine("4. Unpark vehicle");
            Console.WriteLine("5. Search vehicle by registration number");
            Console.WriteLine("6. Search vehicles by properties (Type / Color / Wheels)");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    ListAllVehicles();
                    break;
                case "2":
                    ListVehicleTypesAndCounts();
                    break;
                case "3":
                    ParkVehicleMenu();
                    break;
                case "4":
                    UnparkVehicleMenu();
                    break;
                case "5":
                    SearchByRegNo();
                    break;
                case "6":
                    SearchByProperties();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    static void PopulateDefaultVehicles()
    {
        garage.ParkVehicle(new Car("ABC123", "Red", 4, 5));
        garage.ParkVehicle(new Motorcycle("XYZ789", "Black", 2, 600));
        garage.ParkVehicle(new Bus("BUS444", "Yellow", 6, 45));
        Console.WriteLine("Garage pre-populated with 3 default vehicles for testing.");
    }

    static bool IsValidRegistrationNumber(string regNo)
    {
        string pattern = @"^[A-Za-z]{3}[0-9]{3}$";
        return Regex.IsMatch(regNo, pattern);
    }

    static void ListAllVehicles()
    {
        Console.WriteLine("--- Parked vehicles ---");
        List<Vehicle> vehicles = garage.GetVehicles();

        if (vehicles.Count == 0)
        {
            Console.WriteLine("The garage is empty.");
            return;
        }

        for (int i = 0; i < vehicles.Count; i++)
        {
            Vehicle v = vehicles[i];
            Console.WriteLine($"Slot {i + 1}: Type: {v.GetType().Name}, RegNo: {v.RegistrationNumber}, Color: {v.Color}, Wheels: {v.NumberOfWheels}");
        }
    }

    static void ListVehicleTypesAndCounts()
    {
        List<Vehicle> vehicles = garage.GetVehicles();
        string[] types = new string[vehicles.Count];
        int[] counts = new int[vehicles.Count];
        int uniqueTypesCount = 0;

        for (int i = 0; i < vehicles.Count; i++)
        {
            string typeName = vehicles[i].GetType().Name;
            bool found = false;

            for (int j = 0; j < uniqueTypesCount; j++)
            {
                if (types[j] == typeName)
                {
                    counts[j]++;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                types[uniqueTypesCount] = typeName;
                counts[uniqueTypesCount] = 1;
                uniqueTypesCount++;
            }
        }

        Console.WriteLine("--- Vehicle types and counts ---");
        if (uniqueTypesCount == 0)
        {
            Console.WriteLine("No vehicles in the garage.");
        }
        else
        {
            for (int i = 0; i < uniqueTypesCount; i++)
            {
                Console.WriteLine($"{types[i]}: {counts[i]}");
            }
        }
    }

    static void ParkVehicleMenu()
    {
        if (garage.IsFull())
        {
            Console.WriteLine("Failed: The garage is full!");
            return;
        }

        Console.WriteLine("What type of vehicle do you want to park?");
        Console.WriteLine("1. Car");
        Console.WriteLine("2. Motorcycle");
        Console.WriteLine("3. Airplane");
        Console.WriteLine("4. Bus");
        Console.WriteLine("5. Boat");
        Console.Write("Choice: ");
        string typeChoice = Console.ReadLine();

        if (typeChoice != "1" && typeChoice != "2" && typeChoice != "3" && typeChoice != "4" && typeChoice != "5")
        {
            Console.WriteLine("Invalid vehicle type choice.");
            return;
        }

        string regNo = "";
        while (true)
        {
            Console.Write("Enter registration number (Format: 3 letters + 3 digits, e.g. ABC123): ");
            regNo = Console.ReadLine();

            if (!IsValidRegistrationNumber(regNo))
            {
                Console.WriteLine("Invalid format! Registration number must consist of 3 letters followed by 3 digits (e.g., ABC123).");
                continue;
            }

            if (garage.IsRegistrationNumberTaken(regNo))
            {
                Console.WriteLine("Failed: A vehicle with this registration number already exists!");
                return;
            }
            break;
        }

        Console.Write("Enter color: ");
        string color = Console.ReadLine();

        int wheels = 0;
        while (true)
        {
            Console.Write("Enter number of wheels: ");
            if (int.TryParse(Console.ReadLine(), out wheels) && wheels >= 0)
            {
                break;
            }
            Console.WriteLine("Invalid input! Please enter a valid number for wheels.");
        }

        Vehicle vehicleToPark = null;

        if (typeChoice == "1")
        {
            int doors = 0;
            while (true)
            {
                Console.Write("Enter number of doors: ");
                if (int.TryParse(Console.ReadLine(), out doors) && doors >= 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input! Please enter a valid number for doors.");
            }
            vehicleToPark = new Car(regNo, color, wheels, doors);
        }
        else if (typeChoice == "2")
        {
            double cyl = 0;
            while (true)
            {
                Console.Write("Enter cylinder volume: ");
                if (double.TryParse(Console.ReadLine(), out cyl) && cyl >= 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input! Please enter a valid number for cylinder volume.");
            }
            vehicleToPark = new Motorcycle(regNo, color, wheels, cyl);
        }
        else if (typeChoice == "3")
        {
            int engines = 0;
            while (true)
            {
                Console.Write("Enter number of engines: ");
                if (int.TryParse(Console.ReadLine(), out engines) && engines >= 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input! Please enter a valid number for engines.");
            }
            vehicleToPark = new Airplane(regNo, color, wheels, engines);
        }
        else if (typeChoice == "4")
        {
            int seats = 0;
            while (true)
            {
                Console.Write("Enter number of seats: ");
                if (int.TryParse(Console.ReadLine(), out seats) && seats >= 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input! Please enter a valid number for seats.");
            }
            vehicleToPark = new Bus(regNo, color, wheels, seats);
        }
        else if (typeChoice == "5")
        {
            double length = 0;
            while (true)
            {
                Console.Write("Enter length: ");
                if (double.TryParse(Console.ReadLine(), out length) && length >= 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input! Please enter a valid number for length.");
            }
            vehicleToPark = new Boat(regNo, color, wheels, length);
        }

        if (vehicleToPark != null)
        {
            bool success = garage.ParkVehicle(vehicleToPark);
            if (success)
            {
                Console.WriteLine("The vehicle has been parked successfully!");
            }
            else
            {
                Console.WriteLine("Failed: Could not park vehicle.");
            }
        }
    }

    static void UnparkVehicleMenu()
    {
        if (garage.GetVehicles().Count == 0)
        {
            Console.WriteLine("The garage is empty. No vehicles to unpark.");
            return;
        }

        Console.Write("Enter registration number of the vehicle to unpark: ");
        string regNo = Console.ReadLine();

        bool success = garage.UnparkVehicle(regNo);
        if (success)
        {
            Console.WriteLine("The vehicle has been unparked from the garage.");
        }
        else
        {
            Console.WriteLine("The vehicle was not found.");
        }
    }

    static void SearchByRegNo()
    {
        if (garage.GetVehicles().Count == 0)
        {
            Console.WriteLine("The garage is empty. No vehicles to search.");
            return;
        }

        Console.Write("Enter registration number to search for: ");
        string searchReg = Console.ReadLine();

        List<Vehicle> vehicles = garage.GetVehicles();
        bool found = false;

        for (int i = 0; i < vehicles.Count; i++)
        {
            if (vehicles[i].RegistrationNumber.Equals(searchReg, StringComparison.OrdinalIgnoreCase))
            {
                Vehicle v = vehicles[i];
                Console.WriteLine($"Found! Type: {v.GetType().Name}, RegNo: {v.RegistrationNumber}, Color: {v.Color}, Wheels: {v.NumberOfWheels}");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("No vehicle with that registration number was found.");
        }
    }

    static void SearchByProperties()
    {
        if (garage.GetVehicles().Count == 0)
        {
            Console.WriteLine("The garage is empty. No vehicles to search.");
            return;
        }

        Console.WriteLine("--- Search vehicles by properties ---");
        Console.Write("Enter vehicle type (e.g. Car, Bus, Motorcycle) or leave blank to skip: ");
        string searchType = Console.ReadLine();

        Console.Write("Enter color to filter by (or leave blank to skip): ");
        string searchColor = Console.ReadLine();

        Console.Write("Enter number of wheels to filter by (or type -1 to skip): ");
        int searchWheels = -1;
        int.TryParse(Console.ReadLine(), out searchWheels);

        List<Vehicle> vehicles = garage.GetVehicles();
        bool anyFound = false;

        Console.WriteLine("\n--- Search Results ---");
        for (int i = 0; i < vehicles.Count; i++)
        {
            Vehicle v = vehicles[i];
            bool match = true;

            if (!string.IsNullOrWhiteSpace(searchType) && !v.GetType().Name.Equals(searchType, StringComparison.OrdinalIgnoreCase))
            {
                match = false;
            }

            if (!string.IsNullOrWhiteSpace(searchColor) && !v.Color.Equals(searchColor, StringComparison.OrdinalIgnoreCase))
            {
                match = false;
            }

            if (searchWheels != -1 && v.NumberOfWheels != searchWheels)
            {
                match = false;
            }

            if (match)
            {
                anyFound = true;
                Console.WriteLine($"Type: {v.GetType().Name}, RegNo: {v.RegistrationNumber}, Color: {v.Color}, Wheels: {v.NumberOfWheels}");
            }
        }

        if (!anyFound)
        {
            Console.WriteLine("No vehicles matched the search criteria.");
        }
    }
}