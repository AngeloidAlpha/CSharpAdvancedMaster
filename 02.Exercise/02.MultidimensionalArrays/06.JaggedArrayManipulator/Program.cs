int rows = int.Parse(Console.ReadLine());

int[][] jaggedArray = new int[rows][];

for (int i = 0; i < rows; i++)
{
    int[] imput = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();
    jaggedArray[i] = imput;
}
// в задачата питаме ако 2те имад еднаква дължина да ги умножаваме по 2
// ако те имат различна дължина то тогава да ги разделим
// jaggedArray.Length е дължината надолу (за да не излезем от масива изваждаме с 1 (защото това което въртим са индекси)
for (int row = 0; row < jaggedArray.Length - 1; row++)
{
    // сравняваме редовете дали са равни (индекси) в случая ще са jaggedArray[0] == jaggedArray[1] в 1вото сравнение
    // те ще са с идентична дължина и ще може да комбинираме умножението за 2та реда
    if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
    {
        for (int col = 0; col < jaggedArray[row].Length; col++)
        {
            // 1вия ред
            // 2рия ред
            jaggedArray[row][col] *= 2;
            jaggedArray[row + 1][col] *= 2;
        }
    }
    else
    {
        // тука те не са еднакви по дължина заради това ще ни трябва да обходим всеки ред поотделно и разделим стойноста й
        for (int col = 0; col < jaggedArray[row].Length; col++)
        {
            jaggedArray[row][col] /= 2;
        }
        for (int col = 0; col < jaggedArray[row + 1].Length; col++)
        {
            jaggedArray[row + 1][col] /= 2;
        }
    }
}
// как да изпишем командите дадени в задачата
// приемаме стринга и го разделяме в масив и му парсваме дадените елементи
// после трябва да питаме дали тези елементи са валидни?
// и когато те са валидни да изпълним действието
string command = Console.ReadLine();

while (command != "End")
{
    string[] commandInfo = command.Split();
    int targetRow = int.Parse(commandInfo[1]);
    int targetCol = int.Parse(commandInfo[2]);
    int value = int.Parse(commandInfo[3]);

    // при въвеждане на IsValid(матрицата, реда, колоната)
    // матрицата с която работим 
    // стойността на реда и на колоната която искаме да проверим
    if (commandInfo[0] == "Add" && IsValid(jaggedArray, targetRow, targetCol))
    {
        jaggedArray[targetRow][targetCol] += value;
    }
    else if (commandInfo[0] == "Subtract" && IsValid(jaggedArray, targetRow, targetCol))
    {
        jaggedArray[targetRow][targetCol] -= value;
    }
    command = Console.ReadLine();
}
// за да изпишем назъбен масив правим цикъл броящ редовете и изписваме стойностите на реда с string.Join(" ", jaggedArray[row]

for (int row = 0; row < jaggedArray.Length; row++)
{
    Console.WriteLine(string.Join(" ", jaggedArray[row]));
}

static bool IsValid(int[][] array, int row, int col)
{
    // питаме реда дали е по-голяма от 0 дали е по-малка от дължината на масива ни
    // питаме колоната дали е по-голяма от 0 дали е по-малка от дължината на масива ни
    return row >= 0 && row < array.Length && col >= 0 && col < array[row].Length;
}
/*
5
10 20 30
1 2 3
2
2
10 10
End

result
20 40 60
1 2 3
2
2
5 5 

5
10 20 30
1 2 3
2
2
10 10
Add 0 10 10
Add 0 0 10
Subtract -3 0 10
Subtract 3 0 10
End

result
30 40 60
1 2 3
2
-8
5 5
*/