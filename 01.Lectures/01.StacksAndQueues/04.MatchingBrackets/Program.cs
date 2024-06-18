string input = Console.ReadLine();
Stack<int> openingBracketsIndecs = new();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '(')
    {
        openingBracketsIndecs.Push(i);
    }
    else if (input[i] == ')')
    {
        int start = openingBracketsIndecs.Pop();
        int end = i;

        string subExpression = input.Substring(start, end - start + 1);
        Console.WriteLine(subExpression);
    }
}