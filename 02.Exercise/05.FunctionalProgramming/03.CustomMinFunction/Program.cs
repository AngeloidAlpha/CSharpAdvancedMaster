
int[] inputNumbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

Func<int[], int> getminimumnumber = number => number.Min();

Console.WriteLine(getminimumnumber(inputNumbers));
/*
1 4 3 2 1 7 13
result:
1

4 5 -2 3 -5 8
result:
-5

*/