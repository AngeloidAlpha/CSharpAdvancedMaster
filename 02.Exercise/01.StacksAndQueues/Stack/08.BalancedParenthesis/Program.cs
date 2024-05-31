Stack<char> stack = new Stack<char>();

string input = Console.ReadLine();

bool isBalanced = true;

// въртим из всичките символи в string-a
// така след като сме напълнили стака с лявата страна започваме да въртим дясната (ако това е средата) 
// но също ако има леви и десни скоби една след друга то кода ще ги премахва още докато върти foreach-a
foreach (var item in input)
{
    if (item is '(' or '[' or '{')
    {
        stack.Push(item);
        continue;
    }

    // ще взелем в нашия стак ще опитаме да видим най-горния елемент ако може ще го запишем в променлива currentChar
    // така няма да се сблъскаме с проблема ако стака е празен
    bool canPop = stack.TryPeek(out char currentChar);

    // тук питаме дали canPop -> true/false и
    // проверяваме дали двете мачват -> true/false 
    // и само ако двете са верни то ще ги премахнем
    // това е дефакто запитване дали стака е симетричен
    if (canPop && ((currentChar == '(' && item == ')')
            || (currentChar == '[' && item == ']')
            || (currentChar == '{' && item == '}')))
    {
        stack.Pop();
    }
    else
    {
        // ако не е симетричен то записваме isBalanced като false
        // и на базата на това изкарваме отговора ни на задачата
        isBalanced = false;
        break;
    }
}
if (isBalanced)
{
    Console.WriteLine("YES");
}
else
{
    Console.WriteLine("NO");
}
/*
{[()]}

result YES

{[(])}

result NO

{{[[(())]]}}

result YES
*/