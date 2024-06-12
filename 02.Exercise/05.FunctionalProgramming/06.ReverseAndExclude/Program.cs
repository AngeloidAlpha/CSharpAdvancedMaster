
int[] inputReversedNumbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .Reverse()
    .ToArray();

int n = int.Parse(Console.ReadLine());

Func<int, int, bool> filter = (number, div) => number % div == 0;

int[] result = inputReversedNumbers
    .Where(x => !filter(x, n))
    .ToArray();

Console.WriteLine(string.Join(" ", result));
/*
1 2 3 4 5 6
2	
result:
5 3 1

20 10 40 30 60 50
3
result:
50 40 10 20
*/