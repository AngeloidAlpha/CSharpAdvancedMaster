Stack<int> packages = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
Queue<int> couriers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

int totalDeliveredWeight = 0;


while (packages.Count > 0 && couriers.Count > 0)
{
    int currentPackage = packages.Peek();
    int currentCourier = couriers.Peek();

    if (currentCourier >= currentPackage)
    {
        if (currentCourier > currentPackage)
        {
            currentCourier -= currentPackage * 2;

            if (currentCourier > 0)
            {
                couriers.Dequeue();
                couriers.Enqueue(currentCourier);
            }
            else
            {
                couriers.Dequeue();
            }

            totalDeliveredWeight += currentPackage;
            packages.Pop();
        }
        else
        {
            totalDeliveredWeight += currentPackage;
            packages.Pop();
            couriers.Dequeue();
        }
    }
    else
    {
        totalDeliveredWeight += currentCourier;
        packages.Push(packages.Pop() - couriers.Dequeue());
    }
}

Console.WriteLine($"Total weight: {totalDeliveredWeight} kg");

if (packages.Count == 0 && couriers.Count == 0)
{
    Console.WriteLine($"Congratulations, all packages were delivered successfully by the couriers today.");
}
else
{
    if (packages.Count > 0)
    {
        Console.WriteLine($"Unfortunately, there are no more available couriers to deliver the following packages: {string.Join(", ", packages)}");
    }
    else
    {
        Console.WriteLine($"Couriers are still on duty: {string.Join(", ", couriers)} but there are no more packages to deliver.");
    }
}