int[] inputCups = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

int[] inputBottles = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

Queue<int> cups = new Queue<int>(inputCups);
Stack<int> bottles = new Stack<int>(inputBottles);

int wastedLiters = 0;

// докато имаме и от двете вадим бутилка и вадим купичка (в 2 вътрешни променливи)
// изваждаме ги
// ако все още купата не е пълна то изваждаме още бутилки 
// ако купата вече е негативно (т.е. е преляла) то имаме изгубена вода
// записваме изгубената вода в wastedLiters
while (cups.Any() && bottles.Any())
{
    int bottle = bottles.Pop(); //10
    int cup = cups.Dequeue(); //4

    cup -= bottle;

    while (cup > 0 && bottles.Any())
    {
        cup -= bottles.Pop();
    }

    if (cup < 0)
    {
        wastedLiters += cup;
    }
}

// ако бутилките свършат пишем това а ако купите свършат пишем отговор
// накрая записваме броя изгубена вода
if (bottles.Count > 0)
{
    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
}
else
{
    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
}

Console.WriteLine($"Wasted litters of water: {wastedLiters * -1}");
/*
4 2 10 5
3 15 15 11 6

result:
Bottles: 3
Wasted litters of water: 26

1 5 28 1 4
3 18 1 9 30 4 5

result:
Cups: 4
Wasted litters of water: 35

10 20 30 40 50
20 11

result:
Cups: 30 40 50
Wasted litters of water: 1
*/