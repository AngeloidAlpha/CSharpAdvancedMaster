//ctrl + f отваря меню за променяне на типа на променливата int double string etc..
Dictionary<string, Dictionary<string, double>> shops = new();
// за да не правим сортирането накрая може да ползваме SortedDictionary която ще ги сортира докато ги запомня 
string command;

// вътрешните скоби спират преди .ToLower() за да може command да не се промени към само малки букви а да си стои от подадените
// (command = Console.ReadLine().ToLower()) така command ще бъде запаметена с малки букви и ще прецака други сравнения по-надолу
while ((command = Console.ReadLine()).ToLower() != "revision")
{
    string[] tokens = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

    string shop = tokens[0];
    string product = tokens[1];
    double price = double.Parse(tokens[2]);

    if (!shops.ContainsKey(shop))
    {
        shops.Add(shop, new Dictionary<string, double>());
        //shops[shop] = new Dictionary<string, double>();
    }

    shops[shop].Add(product, price);
}
var orderedShops = shops.OrderBy(x => x.Key);
foreach ((string shop, Dictionary<string, double> products) in orderedShops)
{
    Console.WriteLine($"{shop}->");
    foreach ((string product, double price) in products)
    {
        Console.WriteLine($"Product: {product}, Price: {price}");
    }
}

/*
lidl, juice, 2.30
fantastico, apple, 1.20
kaufland, banana, 1.10
fantastico, grape, 2.20
Revision

result:
fantastico->
Product: apple, Price: 1.2
Product: grape, Price: 2.2
kaufland->
Product: banana, Price: 1.1
lidl->
Product: juice, Price: 2.3

tmarket, peanuts, 2.20
GoGrill, meatballs, 3.30
GoGrill, HotDog, 1.40
tmarket, sweets, 2.20
Revision

result:
GoGrill->
Product: meatballs, Price: 3.3
Product: HotDog, Price: 1.4
tmarket->
Product: peanuts, Price: 2.2
Product: sweets, Price: 2.2
*/