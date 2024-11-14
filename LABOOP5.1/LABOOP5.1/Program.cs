using System;
using System.Collections.Generic;

public abstract class Vehicle
{
    public double Speed { get; set; }  // Швидкість транспорту (км/год)
    public int Capacity { get; set; }  // Вмістимість транспорту (кількість пасажирів)
    public int CurrentPassengers { get; private set; } 

    public abstract void Move();

    public virtual void BoardPassengers(int passengers)
    {
        if (CurrentPassengers + passengers <= Capacity)
        {
            CurrentPassengers += passengers;
            Console.WriteLine($"{passengers} пасажирів сіли. Поточна кількість пасажирів: {CurrentPassengers}");
        }
        else
        {
            Console.WriteLine("Немає місця для всіх пасажирів.");
        }
    }

    public virtual void DisembarkPassengers(int passengers)
    {
        if (CurrentPassengers >= passengers)
        {
            CurrentPassengers -= passengers;
            Console.WriteLine($"{passengers} пасажирів вийшли. Поточна кількість пасажирів: {CurrentPassengers}");
        }
        else
        {
            Console.WriteLine("У транспорті немає достатньо пасажирів для висадки.");
        }
    }
}

public class Human
{
    public double Speed { get; set; } 

    public Human(double speed)
    {
        Speed = speed;
    }

    public void Move()
    {
        Console.WriteLine($"Людина рухається зі швидкістю {Speed} км/год.");
    }
}

public class Car : Vehicle
{
    public Car(double speed, int capacity)
    {
        Speed = speed;
        Capacity = capacity;
    }

    public override void Move()
    {
        Console.WriteLine($"Автомобіль рухається зі швидкістю {Speed} км/год.");
    }
}

public class Bus : Vehicle
{
    public Bus(double speed, int capacity)
    {
        Speed = speed;
        Capacity = capacity;
    }

    public override void Move()
    {
        Console.WriteLine($"Автобус рухається зі швидкістю {Speed} км/год.");
    }
}

public class Train : Vehicle
{
    public Train(double speed, int capacity)
    {
        Speed = speed;
        Capacity = capacity;
    }

    public override void Move()
    {
        Console.WriteLine($"Поїзд рухається зі швидкістю {Speed} км/год.");
    }
}

public class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }
    public double Distance { get; set; } 

    public Route(string startPoint, string endPoint, double distance)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
        Distance = distance;
    }

    public double CalculateOptimalTime(Vehicle vehicle)
    {
        return Distance / vehicle.Speed;
    }

    public double CalculateOptimalTime(Human human)
    {
        return Distance / human.Speed;
    }

    public override string ToString()
    {
        return $"Маршрут: {StartPoint} -> {EndPoint}, відстань: {Distance} км";
    }
}

public class TransportNetwork
{
    public List<Vehicle> Vehicles { get; set; } 
    public List<Route> Routes { get; set; } 

    public TransportNetwork()
    {
        Vehicles = new List<Vehicle>();
        Routes = new List<Route>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
    }

    public void AddRoute(Route route)
    {
        Routes.Add(route);
    }

    public void StartAllVehicles()
    {
        foreach (var vehicle in Vehicles)
        {
            vehicle.Move();
        }
    }

    // Метод для посадки пасажирів на всі транспортні засоби
    public void BoardAllPassengers(int passengers)
    {
        foreach (var vehicle in Vehicles)
        {
            vehicle.BoardPassengers(passengers);
        }
    }

    // Метод для висадки пасажирів з усіх транспортних засобів
    public void DisembarkAllPassengers(int passengers)
    {
        foreach (var vehicle in Vehicles)
        {
            vehicle.DisembarkPassengers(passengers);
        }
    }
}

public class Program
{
    public static void Main()
    {

        var network = new TransportNetwork();

        var car = new Car(80, 4);
        var bus = new Bus(60, 30);
        var train = new Train(120, 100);

        network.AddVehicle(car);
        network.AddVehicle(bus);
        network.AddVehicle(train);

        // Створюємо маршрути
        var route1 = new Route("Київ", "Одеса", 500);
        var route2 = new Route("Львів", "Харків", 800);

        network.AddRoute(route1);
        network.AddRoute(route2);

        network.StartAllVehicles();

        var person = new Human(5);

        person.Move();

        // Розрахунок часу для руху по маршруту для транспорту та людини
        Console.WriteLine($"Час для поїздки на автомобілі по маршруту Київ -> Одеса: {route1.CalculateOptimalTime(car)} год.");
        Console.WriteLine($"Час для поїздки на поїзді по маршруту Львів -> Харків: {route2.CalculateOptimalTime(train)} год.");
        Console.WriteLine($"Час для людини для проходження маршруту Львів -> Харків: {route2.CalculateOptimalTime(person)} год.");

        // Посадка пасажирів
        network.BoardAllPassengers(5);  // 5 пасажирів сіли в усі транспортні засоби

        // Висадка пасажирів
        network.DisembarkAllPassengers(3);  // 3 пасажирів вийшли з усіх транспортних засобів
    }
}
