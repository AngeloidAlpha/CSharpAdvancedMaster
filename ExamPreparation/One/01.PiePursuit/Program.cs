// Template
// 1. Which sequence is for the Stack and which sequence is for the Queue
// 2. When to break while cycle - contenstants.Count > 0 && pies.Count > 0
// 3. When to Dequeue or Pop - start with Peek and Dequeue or Pop when it's timme 
// 4. Where comparing operators >= > == 


Queue<int> contestants = new (Console.ReadLine().Split().Select(int.Parse));
Stack<int> pies = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

while (contestants.Count > 0 && pies.Count > 0)
{
    int contestant = contestants.Dequeue();
    int pie = pies.Pop();

    if (contestant >= pie)
    {
        contestant -= pie;
        if (contestant > 0)
        {
            contestants.Enqueue(contestant);
        }
    }
    else
    {
        pie -=contestant;

        if (pies.Count > 1 && pie == 1)
        {
            var nextPiece = pies.Pop();
            nextPiece += 1;
            pies.Push(nextPiece);

        }
        else
        {
            pies.Push(pie);
        }
    }
}
if (pies.Count == 0 && contestants.Count > 0)
{
    Console.WriteLine("We will have to wait for more pies to be baked!");
    Console.WriteLine($"Contestants left: {string.Join(", ", contestants)}");
}
else if (pies.Count == 0 && contestants.Count == 0)
{
    Console.WriteLine("We have a champion!");
}
else if (pies.Count > 0 && contestants.Count == 0)
{
    Console.WriteLine("Our contestants need to rest!");
    Console.WriteLine($"Pies left: {string.Join(", ", pies)}");
}