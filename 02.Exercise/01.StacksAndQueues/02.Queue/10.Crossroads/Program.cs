int greenLight = int.Parse(Console.ReadLine());
int freeWindow = int.Parse(Console.ReadLine());

string command = Console.ReadLine();

Queue<string> cars = new Queue<string>();

int passedCars = 0;
bool isHitted = false;

while (command != "END")
{
    // колите се събират на кръстовището докато чакаме зеления сигнал
    // трупаме тези коли в една опашка
    if (command != "green")
    {
        cars.Enqueue(command);
        command = Console.ReadLine();
        continue;
    }

    // създаваме променлива която ще е равна на дължината на зеления светофар и ще бъде намаляна с всяка секунда(буква от колата)
    int currentGreenLight = greenLight;

    // започваме да питаме дали има коли на опашката и дали зелената ни светлена не е свършила currentGreenLight
    // пропускаме коли като дължината на колата е равна на броя секунди зелена светлина която ще отнеме за да премине
    // защото имаме и допълнително време freeWindow то имаме 2ра проверка на останалото зелено време + допълнителното
    // дали стига за кола да премнине
    while (cars.Count > 0 && currentGreenLight > 0)
    {
        string currentCar = cars.Dequeue();

        if (currentGreenLight - currentCar.Length >= 0)
        {
            currentGreenLight -= currentCar.Length;
            passedCars++;
            continue;
        }

        if ((currentGreenLight + freeWindow) - currentCar.Length >= 0)
        {
            passedCars++;
            break;
        }
        // какво става ако не стигне времето а има кола която пресича
        // вземамената останали ги събираме и те правят броя букви изминати от колата (програмата ги брои в индекси) 
        // това е якото обаче че ние искаме на следващата буква че е станал сблъсъка т.е. (броя индекси + 1) = на броя секунди
        //currentGreenLight = 1
        //freeWindow = 3
        //1234 секунди
        //0123 индекси
        //Hummer
        //    * сблъсък

        char hittedChar = currentCar[currentGreenLight + freeWindow];

        Console.WriteLine("A crash happened!");
        Console.WriteLine($"{currentCar} was hit at {hittedChar}.");
        // създадохме bool за да решим кога кола е ударена и кога не и кое да изпишем
        isHitted = true;
        break;
    }
    if (isHitted)
    {
        break;
    }
    // защото не сме вкарали command = Console.ReadLine() във while ние напъхваме същата променлива да търси нов вход
    // ако не го поставим ще получим безкраен while цикъл и програмата ще изгори
    command = Console.ReadLine();
}
// ако няма сблъсък
if (!isHitted)
{
    Console.WriteLine("Everyone is safe.");
    Console.WriteLine($"{passedCars} total cars passed the crossroads.");
}
/*
10
5
Mercedes
green
Mercedes
BMW
Skoda
green
END

result: 
Everyone is safe.
3 total cars passed the crossroads.

9
3
Mercedes
Hummer
green
Hummer
Mercedes
green
END

result:
A crash happened!
Hummer was hit at e.
*/