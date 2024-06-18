int passCount = int.Parse(Console.ReadLine());
int totalCount = 0;

Queue<string> cars = new();

string command;

while ((command = Console.ReadLine()) != "end")
{
    if (command.ToLower() == "green")
    {
        int currentPasses = passCount;
        while (cars.Count > 0 && currentPasses > 0)
        {
            string currentCar = cars.Dequeue();
            Console.WriteLine($"{currentCar} passed!");
            currentPasses--;
            totalCount++;
        }
        continue;
    }
    cars.Enqueue(command);
}
Console.WriteLine($"{totalCount} cars passed the crossroads.");