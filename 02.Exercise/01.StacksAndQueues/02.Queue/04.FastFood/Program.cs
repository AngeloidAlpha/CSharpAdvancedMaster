int foodQuantity = int.Parse(Console.ReadLine());
int[] inputOrder = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

Queue<int> orders = new Queue<int>(inputOrder);
// проверка дали имаме поръчни и дали имаме храна

Console.WriteLine(orders.Max());

while (orders.Count > 0 && foodQuantity > 0)
{
    // проверяваме дали имаме достатъчно храна ако да изваждаме
    if (foodQuantity - orders.Peek() >= 0)
    {
        foodQuantity -= orders.Dequeue();
    }
    else
    {
        break;
    }
}
if (orders.Count == 0)
{
    Console.WriteLine("Orders complete");
}
else
{
    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
}
/*
348
20 54 30 16 7 9
// 54
// Orders complete
499
57 45 62 70 33 90 88 76
// 90
// Orders left: 76
*/