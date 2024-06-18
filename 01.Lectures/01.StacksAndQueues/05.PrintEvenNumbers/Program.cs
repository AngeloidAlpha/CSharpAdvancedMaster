Queue<int> numbers = new(
    Console.ReadLine()
    .Split(" ")
    .Select(int.Parse));
List<int> evenNumbers = new List<int>();
while (numbers.Count > 0)
{
    if (numbers.Peek() % 2 == 0)
    {
        int even = numbers.Peek();
        evenNumbers.Add(even);
        numbers.Dequeue();
    }
    else
    {
        numbers.Dequeue();
    }
}
Console.WriteLine(string.Join(", ", evenNumbers));