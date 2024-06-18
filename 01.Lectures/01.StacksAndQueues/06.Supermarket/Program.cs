string input;
Queue<string> output = new();
while ((input = Console.ReadLine()) != "End")
{
    if (input == "Paid")
    {
        int count = output.Count;
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(output.Dequeue());
        }
    }
    else
    {
        output.Enqueue(input);
    }
}
Console.WriteLine($"{output.Count()} people remaining.");