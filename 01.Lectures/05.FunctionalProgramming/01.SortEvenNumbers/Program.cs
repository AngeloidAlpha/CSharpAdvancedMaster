// наименованите функциите скрити зад анонимните функции на Lambda 
Func<string, int> parser = str => int.Parse(str);
Func<int, bool> filter = number => number % 2 == 0;
Func<int, int> sort = number => number;

int[] sortedNumbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(parser) //.Select(int.Parse)
    .Where(filter) // .Where(x => x % 2 == 0)
    .OrderBy(sort) //.OrderBy(number => number)
    .ToArray();

Console.WriteLine(String.Join(", ", sortedNumbers));
/*
4, 2, 1, 3, 5, 7, 1, 4, 2, 12
result:
2, 2, 4, 4, 12

1, 3, 5
result:
нищо

2, 4, 6
result:
2, 4, 6
*/