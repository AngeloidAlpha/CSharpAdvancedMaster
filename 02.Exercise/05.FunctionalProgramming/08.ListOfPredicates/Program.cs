
int n = int.Parse(Console.ReadLine()); // приемаме числото
List<int> numbers = Enumerable.Range(1, n).ToList(); // генерираме масив с числата от 0 до числото n

int[] dividers = Console.ReadLine() // приемаме разделителите
    .Split()
    .Select(int.Parse)
    .ToArray();

// създаваме метода на смятане на всички разделители едновременно 
Func<int, int[], bool> isDivisible = (number, divs) =>
divs.All(x => number % x == 0);

// създаваме нов масив (резултат) който търси в масива от всички числа тези които се делят на разделителите
// .Where( number => isDivisible(number,dividers))
int[] result = numbers
    .Where( number => isDivisible(number,dividers))
    .ToArray();

Console.WriteLine(string.Join(" ", result));
/*
10
1 1 1 2
result:
2 4 6 8 10

100
2 5 10 20
result:
20 40 60 80 100
*/