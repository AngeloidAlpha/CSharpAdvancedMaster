
// 1vi red s pachages
// 2nd red s couriers

using System.Reflection.PortableExecutable;

Stack<int> packages = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
Queue<int> couriers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
int totalWheightPackages = 0;

while (packages.Count > 0 && couriers.Count > 0)
{

    // note maybe need Peek()
    int package = packages.Pop();
    int courier = couriers.Dequeue();

    if (courier >= package)
    {
        if (courier > package)
        {
            int newMan = courier;
            newMan -= package * 2;
            if (newMan > 0)
            {
                couriers.Enqueue(newMan);
                // dequeue here
            }
        }
        // pop here
        totalWheightPackages += package;
    }
    else
    {
        package -= courier;
        packages.Push(package);
        totalWheightPackages += courier;
    }
}
Console.WriteLine($"Total weight: {totalWheightPackages} kg");
if (packages.Count == 0)
{
    if (packages.Count == 0 && couriers.Count > 0)
    {
        Console.WriteLine($"Couriers are still on duty: {string.Join(", ", couriers)} but there are no more packages to deliver.");
    }
    else
    {
        Console.WriteLine("Congratulations, all packages were delivered successfully by the couriers today.");
    }
}
else if (packages.Count > 0 && couriers.Count == 0)
{
    Console.WriteLine($"Unfortunately, there are no more available couriers to deliver the following packages: {string.Join(", ", packages)}");
}

/*
2 4 6 8
8 6 4 2

2 4 6 8
18 6 4 2 6
*/