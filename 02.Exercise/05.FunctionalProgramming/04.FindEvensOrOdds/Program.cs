
int[] range = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int start = range[0];
int end = range[1];
string type = Console.ReadLine();
// за .Range(10, 10) то ще вземе от 10 до 19 заради това е изписано така с променливите
List<int> numbers = Enumerable
    .Range(start, end - start + 1)
    .ToList();
// с използване на for-цикъл
/*
List<int> numbers = new List<int>();

for (int i = start; i <= end; i++)
{
    numbers.Add(i);
}
*/

Predicate<int> isEven = x => x % 2 == 0;
Predicate<int> isOdd = x => x % 2 != 0;

// съкратено решение
// от колецията numbers искаме да намерим само тези .FindAll които отговарят на тези 2 предиката isEven isOdd
// на безата на тези термални оператори type == "even" ? isEven : isOdd
var filter = numbers.FindAll(type == "even" ? isEven : isOdd);
var result = string.Join(" ", filter);
Console.WriteLine(result);

// FindAll and RemoveAll ги има само в List
// numbers.FindAll(isEven); numbers.RemoveAll(isOdd);
// това долу е бонобо решението
/*
if (type == "even")
{
    Console.WriteLine(string.Join(" ", numbers.FindAll(isEven)));
}
else
{
    Console.WriteLine(string.Join(" ", numbers.FindAll(isOdd)));
}
*/
/*
1 10
odd	
result:
1 3 5 7 9

20 30
even
result:
20 22 24 26 28 30
*/