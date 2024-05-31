int n = int.Parse(Console.ReadLine());

Stack<int> stack = new Stack<int>();
for (int i = 0; i < n; i++)
{
    int[] input = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();
    int command = input[0];

    if (command == 1)
    {
        stack.Push(input[1]);
    }
    // ще изпише грешка ако е празен
    // допълнително условие дали стака е празен
    else if (command == 2 && stack.Any())
    {
        stack.Pop();
    }
    // допълнително условие дали стака е празен
    else if (command == 3 && stack.Any())
    {
        Console.WriteLine(stack.Max());
    }
    // допълнително условие дали стака е празен
    else if (command == 4 && stack.Any())
    {
        Console.WriteLine(stack.Min());
    }
}
Console.WriteLine(string.Join(", ", stack));