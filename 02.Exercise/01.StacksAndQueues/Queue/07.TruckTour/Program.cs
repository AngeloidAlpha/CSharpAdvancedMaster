int n = int.Parse(Console.ReadLine());

Queue<(int, int)> petrolPumps = new Queue<(int, int)>();

// правим цикъл за да запълним опашката с двата параметъра км и гориво
for (int i = 0; i < n; i++)
{
    int[] input = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

    int petrol = input[0];
    int km = input[1];

    petrolPumps.Enqueue((petrol, km));
}

int startIndex = 0;

while (true)
{
    int totalPetrol = 0;

    // търсим петролната станция от която да почнем
    // с item.Item1 и item.Item2 може да вземем от текущия в опашката двете стойности и да им ги приложим в другите променливи
    foreach (var item in petrolPumps)
    {
        totalPetrol += item.Item1;
        int km = item.Item2;

        totalPetrol -= km;

        // проверка ако не стига горивото, да минем на следващата станция от опашката
        if (totalPetrol < 0)
        {
            break;
        }
    }
    // правим същата проверка за това дали горивото стига
    // ако не казваме ок време е да минем на следващата станция от която да почнем
    // и вземаме първата станция която тестваме от опашката и я поставяме най-отзад
    if (totalPetrol < 0)
    {
        startIndex++;
        petrolPumps.Enqueue(petrolPumps.Dequeue());
    }
    // така ще стигнем пак до последната каръшка станция и ще приключим while цикъла ни и ще може да изпишем коя е стартиращата станция
    else
    {
        break;
    }
}
Console.WriteLine(startIndex);