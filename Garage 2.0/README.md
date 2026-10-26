# Garage 2.0

## Short Description
Garage 2.0 is a C# console application designed to simulate a vehicle parking management system. It allows users to create a garage with a specified capacity, park and unpark various types of vehicles, view detailed lists of parked vehicles along with their counts by type, and perform robust searches by registration number or specific vehicle properties (such as type, color, and wheels).

## How to Start the Program
1. Open the project in Visual Studio or your preferred C# IDE.
2. Build and run the project (press `F5` or click the **Start** button).
3. When prompted in the console, enter a positive number to set the maximum capacity for the garage.
4. The application will automatically pre-populate the garage with default test vehicles and present the main menu.
5. Use the numerical menu options to navigate through the application features, and select `0` to exit.

## Classes and Responsibilities

* **`Program`**: Manages the text-based user interface, console menu navigation, user input validation, and orchestrates calls to the garage management logic.
* **`Garage`**: Represents the physical garage building. It internally manages a private `List<Vehicle>` to store parked vehicles, enforces maximum capacity constraints, prevents duplicate registration numbers, and handles parking/unparking operations.
* **`Vehicle` (Abstract Base Class)**: Defines the core properties common to all vehicles, such as `RegistrationNumber`, `Color`, and `NumberOfWheels`.
* **`Car`**: Inherits from `Vehicle` and adds a unique property for the number of doors (`NumberOfDoors`).
* **`Motorcycle`**: Inherits from `Vehicle` and adds a unique property for cylinder volume (`CylinderVolume`).
* **`Airplane`**: Inherits from `Vehicle` and adds a unique property for the number of engines (`NumberOfEngines`).
* **`Bus`**: Inherits from `Vehicle` and adds a unique property for the number of seats (`NumberOfSeats`).
* **`Boat`**: Inherits from `Vehicle` and adds a unique property for the boat's length (`Length`).