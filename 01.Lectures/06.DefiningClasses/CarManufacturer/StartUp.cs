using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            int fuelQuantity = int.Parse(Console.ReadLine());
            int fuelConsumption = int.Parse(Console.ReadLine());
            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
            // Car car = new Car("VW", "Passat", 2007, 75, 6.5);
            Console.WriteLine(thirdCar.WhoAmI());

            // задача 4
            Engine engine = new Engine(560, 6300);
            Tire[] tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3)
            };
            Car car = new Car("Lamboghini", "Urus", 2010, 250, 9, engine, tires);

        }
    }
}
/*
1ва задача е това:
Car car = new Car();

car.Make = "VW";
car.Model = "MK3";
car.Year = 1992;

Console.WriteLine($"Make: {car.Make}");
Console.WriteLine($"Model: {car.Model}");
Console.WriteLine($"Year: {car.Year}");

2ра задача добавяме тези редове:
car.FuelQuantity = 130;
car.FuelConsumption = 13;
car.Drive(50);
Console.WriteLine(car.WhoAmI());
*/
