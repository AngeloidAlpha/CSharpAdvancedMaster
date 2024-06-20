using CarDataBank;
using System.Net.Http.Headers;

int n = int.Parse(Console.ReadLine());
List<Car> cars = new List<Car>();
//"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} 
// {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string model = input[0];
    int engineSpeed = int.Parse(input[1]);
    int enginePower = int.Parse(input[2]);
    int cargoWeight = int.Parse(input[3]);
    string cargoType = input[4];
    double tire1Pressure = double.Parse(input[5]);
    int tire1Age = int.Parse(input[6]);
    double tire2Pressure = double.Parse(input[7]);
    int tire2Age = int.Parse(input[8]);
    double tire3Pressure = double.Parse(input[9]);
    int tire3Age = int.Parse(input[10]);
    double tire4Pressure = double.Parse(input[11]);
    int tire4Age = int.Parse(input[12]);
    // започваме да стздаваме обектите като почваме от тези които не зависят от нищо и приклчваме с тези които зависят от нещо

    Engine engine = new(engineSpeed, enginePower);
    Cargo cargo = new(cargoType, cargoWeight);
    Tire[] tires = new Tire[4];
    tires[0] = new(tire1Age, tire1Pressure);
    tires[1] = new(tire2Age, tire2Pressure);
    tires[2] = new(tire3Age, tire3Pressure);
    tires[3] = new(tire4Age, tire4Pressure);
    // съкратена версия на горното с гумите 
    /*
    int counter = 0;
    for (i = 5; i <= 12; i+=2)
    {
        double tirePressure = double.Parse(input[i]);
        int tireAge = int.Parse(input[i+1]);
        tires[counter++] = new Tire(tireAge, tirePressure);
    }
    */

    Car car = new(model, cargo, engine, tires);
    // изписахме данните за колата сега трябва да създадем лист където да ги запишем всички коли

    cars.Add(car);
}
// запопочваме да приемаме команди за flammable or frigile cargo type
string targetCargoType = Console.ReadLine();
cars
    .Where(car => car.Cargo.Type == targetCargoType
    && (targetCargoType == "fragile"
    ? car.Tires.Any(x => x.Pressure < 1)
    : car.Engine.Power > 250))
    .ToList()
    .ForEach(x => Console.WriteLine(x.Model));
/*
//"fragile" - print all cars, whose cargo is "fragile" and have a pressure of a single tire < 1.
if (targetCargoType == "fragile")
{
    foreach (Car car in cars)
    {
        if(car.Cargo.Type == "fragile")
        {
            foreach(Tire tire in car.Tires)
            {
                if(tire.Pressure < 1)
                {
                    Console.WriteLine(car.Model);
                    break;
                }
            }
        }
    }
    cars
        .Where(x => x.Cargo.Type == "frigile" 
        && x.Tires.Any(x => x.Pressure < 1))
        .ToList()
        .ForEach(x => Console.WriteLine(x.Model));
// по-гъзарски начин
//"flammable" - print all cars, whose cargo is "flammable" and have engine power > 250.
else if (targetCargoType == "flammable")
{
    cars
    .Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250)
    .ToList()
    .ForEach(x => Console.WriteLine(x.Model));
}
*/
