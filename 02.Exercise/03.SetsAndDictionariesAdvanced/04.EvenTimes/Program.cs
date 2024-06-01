
int n = int.Parse(Console.ReadLine());

Dictionary<int, int> numbers = new Dictionary<int, int>();

for (int i = 0; i < n; i++)
{
    int inputNumber = int.Parse(Console.ReadLine());

    // първи запис на повтарящите се числа 
    // ако числото го няма го добави със стойност 0
    // и ако го има просто увеличи стойноста му с 1 (в този случай дори не трябва да има else като долу
    if (!numbers.ContainsKey(inputNumber))
    {
        numbers.Add(inputNumber, 0);
    }
    numbers[inputNumber]++;
    // втори запис на
    /*
    if (numbers.ContainsKey(inputNumber))
    {
        numbers[inputNumber]++;
    }
    else
    {
        numbers.Add(inputNumber, 1);
    }
    */
}
// изписваме го с Linq като записваме в нова променлива evenNumber и търсим numbers.Where(x => x.Value % 2 == 0) дали е четно
// .FirstOrDefault() това ще върне key value pair
// .Key да ни изпрати ключа а не стойноста ни в evenNumber
int evenNumber = numbers
    .Where(x => x.Value % 2 == 0)
    .FirstOrDefault()
    .Key;

// друг начин за изписване:
/*
foreach (var (key, value) in numbers)
{
    if (value % 2 == 0)
    {
        evenNumber = key;
        break;
    }
}
*/

Console.WriteLine(evenNumber);
/*
3
2
-1
2

result:
2

5
1
2
3
1
5

result:
1

*/
