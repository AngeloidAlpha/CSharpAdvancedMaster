
// класовете се създават във нови файлове
// ctrl + shift + A 

using _00.Demo;

Person person = new ();
person.Name = "Gosho";
person.Age = 25;

Console.WriteLine ($"{person.Name} is {person.Age} year old!");

// мога да го запеметя 
CoffeeSize sizeNum = CoffeeSize.Small;
int sizeClass = CoffeeSizeClass.Small;

// използваме ги за да имаме правилните извиквания (като например правилния размер кафе, и застраховка от грешно изписани променливи)
// извикваме долното с CoffeeSize.Small
DrinkCoffee(CoffeeSize.Small);
void DrinkCoffee(CoffeeSize coffeeSize)
{
    if (coffeeSize == CoffeeSize.Large)
    {
        Console.WriteLine("Not right cup size coffee");
    }
    else if (coffeeSize == CoffeeSize.Small)
    {
        Console.WriteLine("Right cup size coffee");
    }
}
CoffeeSize size = CoffeeSize.Medium;
Console.WriteLine(size);
Console.WriteLine((int)size);
Console.WriteLine((CoffeeSize)300);
Console.WriteLine((CoffeeSize)30); // ще изпише int който сме записали (защото нямаме такава константа
Console.WriteLine("++++++++++++++++");
Console.WriteLine(sizeClass);
