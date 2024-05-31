int[] inputValues = Console.ReadLine()
   .Split()
   .Select(int.Parse)
   .ToArray();

int rackCapacity = int.Parse(Console.ReadLine());

// може директно да напълним Stack от Array
Stack<int> clothes = new Stack<int>(inputValues);

int currentRackCapacity = 0;
int box = 1;

while (clothes.Any())
{
    // вземаме и махаме от стака последния елемент и му даваме нова променлива която да ползваме
    int currentClothes = clothes.Pop();

    // проверяваме дали вече събраните дрехи + новата дреха е над капацитета ни
    // ако не я добавяме
    // ако да присвояваме дадената дреха в сегашния капацитет и отваряме нова кутия
    if (currentClothes + currentRackCapacity <= rackCapacity)
    {
        currentRackCapacity += currentClothes;
    }
    else
    {
        currentRackCapacity = currentClothes;
        box++;
    }
}
Console.WriteLine(box);
/*
5 4 8 6 3 8 7 7 9
16
отговор 5
1 7 8 2 5 4 7 8 9 6 3 2 5 4 6
20
отговор 5
*/