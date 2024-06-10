
Func<string, int> parser = str => int.Parse(str);

int[] numbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(str => parser(str))
    .ToArray();

Console.WriteLine(numbers.Length);
Console.WriteLine(numbers.Sum());

/*
4, 2, 1, 3, 5, 7, 1, 4, 2, 12
result:
10
41

2, 4, 6
result:
3
12
*/