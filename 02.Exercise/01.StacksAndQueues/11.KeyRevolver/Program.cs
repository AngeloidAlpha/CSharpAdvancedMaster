
int priceOfBullet = int.Parse(Console.ReadLine());
int sizeOfGunBarrel = int.Parse(Console.ReadLine());

int[] inputBullets = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] inputLocks = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int valueOfIntelligence = int.Parse(Console.ReadLine());
// по условие ще изваждаме locks един след друг
// по условие ще изваждаме bullets отзад напред
Queue<int> locks = new Queue<int>(inputLocks);
Stack<int> bullets = new Stack<int>(inputBullets);

// 2 променливи броящи броя на всички изтрели и броя на изтрелите при които трябва да презаредим
int shootsCount = 0;
int totalShoots = 0;
// докато имаме ключалки и патрони прави нещо (ако едното свърши приключваме)
while (locks.Any() && bullets.Any())
{
    // независимо дали сме bang или ping премахваме патрона (на всеки 2 изтрела имаме презареждане)
    int bullet = bullets.Pop();
    int currentLock = locks.Peek();
    shootsCount++;
    totalShoots++;

    if (bullet <= currentLock)
    {
        locks.Dequeue();
        Console.WriteLine("Bang!");
    }
    else
    {
        Console.WriteLine("Ping!");
    }
    // ако броя на изтрели (2) е равен на размера на барела 2 и имаме още патрони в стака то презареждаме и нулираме брояча
    if (shootsCount == sizeOfGunBarrel && bullets.Any())
    {
        Console.WriteLine("Reloading!");
        shootsCount = 0;
    }
}

if (locks.Count > 0)
{
    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
}
else
{
    // променлива помнеща колко пари сме печелили 
    int moneyEarned = valueOfIntelligence - (priceOfBullet * totalShoots);
    Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
}
/*
50
2
11 10 5 11 10 20
15 13 16
1500

result:
Ping!
Bang!
Reloading!
Bang!
Bang!
Reloading!
2 bullets left. Earned $1300

20
6
14 13 12 11 10 5
13 3 11 10
800

result:
Bang!
Ping!
Ping!
Ping!
Ping!
Ping!
Couldn't get through. Locks left: 3

33
1
12 11 10
10 20 30
100

result:
Bang!
Reloading!
Bang!
Reloading!
Bang!
0 bullets left. Earned $1
*/