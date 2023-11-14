using System.Runtime.InteropServices;

enum Type
{
    Car,
    Truck
}

class Vehicle
{
    public Type Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public decimal HorsePower { get; set; }

    public Vehicle (string type, string model, string color, string horsePower)
    {
        Type = type == "car" ? Type.Car : Type.Truck;
        Model = model;
        Color = color;
        HorsePower = decimal.Parse(horsePower);
    }
    public override string ToString()
    {
        return $"Type: {Type}\n" +
               $"Model: {Model}\n" +
               $"Color: {Color}\n" +
               $"Horsepower: {HorsePower}";
    }
}

internal class Program
{
    static void Main()
    {
        List<Vehicle> catalogue = new List<Vehicle>();        

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] commands = input.Split().ToArray();

            string typeOfVehicle = commands[0];
            string model = commands[1];
            string color = commands[2];
            string horsePower = commands[3];

            catalogue.Add(new Vehicle(typeOfVehicle, model, color, horsePower));            

        }

        while ((input = Console.ReadLine()) != "Close the Catalogue")
        {
            string model = input;

            Vehicle found = catalogue.FirstOrDefault(v => v.Model == model);
            if (found != null)
            {
                Console.WriteLine(found);
            }
        }

        decimal averageHP = catalogue
            .Where(vehicle => vehicle.Type == Type.Car)
            .Select(vehicle => vehicle.HorsePower)
            .DefaultIfEmpty()
            .Average();
        Console.WriteLine($"Cars have average horsepower of: {averageHP:F2}.");

        averageHP = catalogue
            .Where(vehicle => vehicle.Type == Type.Truck)
            .Select(vehicle => vehicle.HorsePower)
            .DefaultIfEmpty()
            .Average();
        Console.WriteLine($"Trucks have average horsepower of: {averageHP:F2}.");
    }
}
