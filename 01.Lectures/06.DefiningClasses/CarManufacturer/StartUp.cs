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
