
int[] lengthOfSets = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int n = lengthOfSets[0];
int m = lengthOfSets[1];

HashSet<int> setA = new HashSet<int>();
HashSet<int> setB = new HashSet<int>();
for (int i = 0; i < n; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());
    
    setA.Add(currentNumber);
}

for (int i = 0;i < m; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());

    setB.Add(currentNumber);
}
// умен начин да намерим тези елементи които се засичат в 2 сет-а .Intersect (тези които съвпадат)
Console.WriteLine(string.Join(" ", setA.Intersect(setB)));
/*

foreach (int i in setA)
{
    if (setB.Contains(i))
    {
        Console.Write(i + " ");
    }
}

4 3
1
3
5
7
3
4
5

result:
3 5

2 2
1
3
1
5

result:
1

*/