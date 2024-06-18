// записваме всичките ни стойности в масив

double[] numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .ToArray();
// създаваме една библютека която ще притежава ключа (дадената стойност) и стойност (колко пъти се среща)
Dictionary<double, int> numbersCounts = new();

// създаваме един цикъл да превъртим всичките стойности
foreach (double number in numbers)
{
    // питам дали стойноста я има в библютеката
    // ако не я добавям
    if (!numbersCounts.ContainsKey(number))
    {
        numbersCounts.Add(number, 0);
    }
    // и след това за него ключ увеличавам стойноста 

    numbersCounts[number]++;
}
// как да изпишем тази библютека
// правим един цикъл вървящ из библютеката KeyValuePair<double, int> 
// и изписваме numberCount.Key numberCount.Value
foreach (KeyValuePair<double, int> numberCount in numbersCounts)
{
    Console.WriteLine($"{numberCount.Key} - {numberCount.Value} times");
}
/*
-2.5 4 3 -2.5 -5.5 4 3 3 -2.5 3

result:
-2.5 - 3 times
4 - 2 times
3 - 4 times
-5.5 - 1 times

2 4 4 5 5 2 3 3 4 4 3 3 4 3 5 3 2 5 4 3

result:
2 - 3 times
4 - 6 times
5 - 4 times
3 - 7 times

*/