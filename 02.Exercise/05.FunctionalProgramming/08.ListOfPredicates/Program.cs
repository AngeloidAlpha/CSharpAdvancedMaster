
int n = int.Parse(Console.ReadLine());
List<int> numbers = Enumerable.Range(0, n).ToList();

int[] dividers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

