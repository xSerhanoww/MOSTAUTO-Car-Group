using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CarDealershipTeam2
{
    internal class Program
    {
        static List<Cars> Vehicles = new List<Cars>();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintText();
            LoadCars();
            Console.WriteLine("=====================================================");
            Console.WriteLine("WELCOME TO MOSTAUTO CAR GROUP");
            Console.WriteLine("=====================================================");

            while (true)
            {
                Console.WriteLine("1) Add a new car");
                Console.WriteLine("2) Sell a car");
                Console.WriteLine("3) List all available car");
                Console.WriteLine("4) List all sold car");
                Console.WriteLine("5) Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("--------------------------");
                        AddNewCar();
                        break;
                    case "2":
                        Console.WriteLine("--------------------------");
                        SellCar();
                        break;
                    case "3":
                        Console.WriteLine("--------------------------");
                        ListAvblCar();
                        break;
                    case "4":
                        Console.WriteLine("--------------------------");
                        ListSoldCar();
                        break;
                    case "5":
                        SaveCarToFile();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine("--------------------------");
                        break;


                }
            }
        }
        static void AddNewCar()
        {
            Console.WriteLine("Adding a new car ...");
            Cars newCar = new Cars();

            Console.Write("ID (number/s): ");
            newCar.ID = int.Parse(Console.ReadLine());

            bool carExists = Vehicles.Any(car => car.ID == newCar.ID);
            if (carExists)
            {
                Console.WriteLine("Car with the same ID already exists!");
                Console.WriteLine("Unable to add the car.");
                Console.WriteLine("--------------------------");
                return;
            }


            Console.Write("Brand: ");
            newCar.Brand = Console.ReadLine();

            Console.Write("Model: ");
            newCar.Model = Console.ReadLine();

            Console.Write("YearOfManufacture: ");
            newCar.YearOfManufacture = int.Parse(Console.ReadLine());

            Console.Write("HorsePower(HP): ");
            newCar.HorsePower = int.Parse(Console.ReadLine());

            Console.Write("Fuel type: ");
            newCar.FuelType = Console.ReadLine();

            Console.Write("Gearbox: ");
            newCar.GearBox = Console.ReadLine();

            Console.Write("Price: ");
            newCar.Price = int.Parse(Console.ReadLine());

            Console.Write("Color: ");
            newCar.Color = Console.ReadLine();

            Console.Write("isNew (true/false): ");
            newCar.isNew = bool.Parse(Console.ReadLine());

            Console.Write("Mileage (km): ");
            newCar.Mileage = int.Parse(Console.ReadLine());


            newCar.Availability = true;
            newCar.NewOwner = "";

            Vehicles.Add(newCar);

            SaveCarToFile();

            Console.WriteLine("Car added successfully!");
            Console.WriteLine("--------------------------");
        }

        static void SellCar()
        {
            Console.WriteLine("Selling a car...");

            ListAvblCar();

            Console.Write("Enter the ID of the car to sell: ");
            int introduceId = int.Parse(Console.ReadLine());

            Cars car = Vehicles.Find(v => v.ID == introduceId && v.Availability);
            if (car != null)
            {
                Console.Write("Enter the new owner: ");
                string NewOwner2 = Console.ReadLine();

                car.Availability = false;
                car.NewOwner = NewOwner2;
                SaveCarToFile();
                Console.WriteLine("Car sold successfully!");
                Console.WriteLine("--------------------------");
            }
            else
            {
                Console.WriteLine("Car with the specified ID is not available for sale.");
                Console.WriteLine("--------------------------");
            }

        }

        static void ListAvblCar()
        {
            Console.WriteLine("Available cars: ");

            var sortedCars = Vehicles.Where(car => car.Availability).OrderBy(car => car.ID);

            foreach (Cars car in sortedCars)
            {
                if (car.Availability == true)
                {
                    Console.WriteLine($"ID: {car.ID},Brand: {car.Brand},Model: {car.Model},YearOfManufacture: {car.YearOfManufacture}," +
                    $"HorsePower(HP): {car.HorsePower}hp,Fuel type: {car.FuelType},Gearbox: {car.GearBox},Price: {car.Price}BGN,Color: {car.Color}," +
                    $"isNew: {car.isNew},Mileage: {car.Mileage}km,Availability: {car.Availability}");
                    Console.WriteLine("--------------------------");
                }
            }

        }

        static void ListSoldCar()
        {
            Console.WriteLine("Sold cars: ");

            foreach (Cars car in Vehicles)
            {
                if (!car.Availability)
                {
                    Console.WriteLine(car.ToString());
                    Console.WriteLine("--------------------------");
                }
            }

        }
        static void PrintText()
        {
            Console.WriteLine("\r\n /$$      /$$  /$$$$$$   /$$$$$$  /$$$$$$$$        /$$$$$$  /$$   /$$ /$$$$$$$$  /$$$$$$ \r\n| $$$    /$$$ /$$__  $$ /$$__  $$|__  $$__/       /$$__  $$| $$  | $$|__  $$__/ /$$__  $$\r\n| $$$$  /$$$$| $$  \\ $$| $$  \\__/   | $$         | $$  \\ $$| $$  | $$   | $$   | $$  \\ $$\r\n| $$ $$/$$ $$| $$  | $$|  $$$$$$    | $$         | $$$$$$$$| $$  | $$   | $$   | $$  | $$\r\n| $$  $$$| $$| $$  | $$ \\____  $$   | $$         | $$__  $$| $$  | $$   | $$   | $$  | $$\r\n| $$\\  $ | $$| $$  | $$ /$$  \\ $$   | $$         | $$  | $$| $$  | $$   | $$   | $$  | $$\r\n| $$ \\/  | $$|  $$$$$$/|  $$$$$$/   | $$         | $$  | $$|  $$$$$$/   | $$   |  $$$$$$/\r\n|__/     |__/ \\______/  \\______/    |__/         |__/  |__/ \\______/    |__/    \\______/ \r\n                                                                                         \r\n                                                                                         \r\n                                                                                         \r\n");
        }
        static void LoadCars()
        {
            StreamReader reader = new StreamReader("CarsForP.txt");
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',').ToArray();
                if (parts.Length == 13)
                {
                    Cars car = new Cars();
                    car.ID = int.Parse(parts[0]);
                    car.Brand = parts[1];
                    car.Model = parts[2];
                    car.YearOfManufacture = int.Parse(parts[3]);
                    car.HorsePower = int.Parse(parts[4]);
                    car.FuelType = parts[5];
                    car.GearBox = parts[6];
                    car.Price = int.Parse(parts[7]);
                    car.Color = parts[8];
                    car.isNew = bool.Parse(parts[9]);
                    car.Mileage = int.Parse(parts[10]);
                    car.Availability = bool.Parse(parts[11]);
                    car.NewOwner = parts[12];

                    Vehicles.Add(car);

                    if (car.NewOwner == "")
                    {
                        car.Availability = true;
                    }
                }
                
               

            }
            reader.Close();
        }

        static void SaveCarToFile()
        {
            using (StreamWriter writer = new StreamWriter("CarsForP.txt"))
            {
                foreach (Cars car in Vehicles)
                {
                    writer.WriteLine($"{car.ID},{car.Brand},{car.Model},{car.YearOfManufacture},{car.HorsePower},{car.FuelType},{car.GearBox}" +
                        $",{car.Price},{car.Color},{car.isNew},{car.Mileage},{car.Availability},{car.NewOwner}");
                   
                }

            }
        }
    }
}
