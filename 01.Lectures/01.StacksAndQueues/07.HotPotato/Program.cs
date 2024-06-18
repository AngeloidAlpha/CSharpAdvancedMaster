// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Queue<string> kids = new(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

int passes = int.Parse(Console.ReadLine());

while (kids.Count > 1)
{
    for (int i = 0; i < passes - 1; i++)
    {
        string currentKid = kids.Dequeue();
        kids.Enqueue(currentKid);
    }
    string kidToRemove = kids.Dequeue();
    Console.WriteLine($"Removed {kidToRemove}");
}
Console.WriteLine($"Last is {kids.Dequeue()}");