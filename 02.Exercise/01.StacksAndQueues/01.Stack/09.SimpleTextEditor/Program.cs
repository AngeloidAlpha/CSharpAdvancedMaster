Stack<string> state = new Stack<string>();

int n = int.Parse(Console.ReadLine());

string text = string.Empty;

for (int i = 0; i < n; i++)
{
    string[] commandInfo = Console.ReadLine().Split();

    // ако ни пита да добавяме 
    // то ние добавя към празния стак празния text и към него конкатенираме (добавяме) стринг елемента от масива
    // това ни трябва за да може направим undo функцията
    // стака ще помни всеки един статус на стринга ни като стак с различни чинии
    if (commandInfo[0] == "1")
    {
        state.Push(text);
        text += commandInfo[1];
    }
    // ако ни пита да изтрием брой символи
    // правим го като превръщаме стринг-а в интеджер който може да ползваме после в операцията .Substring
    // която е по този начин:         6              2     =>     4
    // "toshko".Substring(0, "toshko".Length - valueToErase)
    // това ще вземе от началото на стринга то дължината му минус колкото искаме елементи 
    // дължината е с 1 по-голяма от индексите
    // "tosh" ще е резултата

    else if (commandInfo[0] == "2")
    {
        state.Push(text);
        int valueToErase = int.Parse(commandInfo[1]);
        text = text.Substring(0, text.Length - valueToErase);
    }
    // иска да дадения от дължината стринг символ
    // тука влиза правилото за това че дължината е с 1 по-голямо от индекса в един стринг
    // заради това като искаме да изпишем само един символ от стринга то се прави така:
    // text[indexToPrint - 1]
    else if (commandInfo[0] == "3")
    {
        int indexToPrint = int.Parse(commandInfo[1]);
        Console.WriteLine(text[indexToPrint - 1]);
    }

    else if (commandInfo[0] == "4")
    {
        text = state.Pop();
    }
}
/*
8
1 abc
3 3
2 3
1 xy
3 2
4
4 
3 1

result:
c
y
a

9
1 HelloThere
3 7
2 2
3 5
4
3 7
4
1 TestPassed
3 5

result:
h
o
h
P
*/