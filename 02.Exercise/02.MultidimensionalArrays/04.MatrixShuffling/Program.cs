int[] dimensions = Console.ReadLine()
   .Split()
   .Select(int.Parse)
   .ToArray();

int rows = dimensions[0];
int cols = dimensions[1];

string[,] matrix = new string[rows, cols];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    string[] input = Console.ReadLine()
        .Split();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = input[col];
    }
}

string command = Console.ReadLine();

while (command != "END")
{
    // масив от стрингове
    //["swap", "0", "0", "1", "1"]
    string[] commandInfo = command.Split();
    // питаме дали той е различен от 5 броя елементи и дали има ключова дума swap
    // ако не изписваме грешка и искаме нова команда и после продължаваме
    if (commandInfo.Length != 5
        || commandInfo[0] != "swap")
    {
        Console.WriteLine("Invalid input!");
        command = Console.ReadLine();
        continue;
    }
    // парсваме стринговете (числа) в интеджери
    int firstRow = int.Parse(commandInfo[1]);
    int firstCol = int.Parse(commandInfo[2]);

    int secondRow = int.Parse(commandInfo[3]);
    int secondCol = int.Parse(commandInfo[4]);

    // може да изкараме в метод IsInside като натиснем ctrl + . на метода просто го селектирай целия:
    // if (firstRow >= 0 && firstRow < matrix.GetLength(0) && firstCol >= 0 && secondCol < matrix.GetLength(1))
    // това е проверка за да проверим дали дадените ни цифри са в матрицата или не
    if (!IsInside(matrix, firstRow, firstCol)
        || !IsInside(matrix, secondRow, secondCol))
    {
        Console.WriteLine("Invalid input!");
        command = Console.ReadLine();
        continue;
    }
    // правим променлива tempValue която помни 1вия елемент
    // записваме 2рия елемент на мястото на 1вия
    // записваме променливата temValue на 1вия елемент в мястото на 2рия елемент
    string tempValue = matrix[firstRow, firstCol];
    matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
    matrix[secondRow, secondCol] = tempValue;

    // изписваме матрицата
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col] + " ");
        }
        Console.WriteLine();
    }

    command = Console.ReadLine();
}

static bool IsInside(string[,] board, int firstRow, int firstCol)
{
    return firstRow >= 0 && firstRow < board.GetLength(0)
                        && firstCol >= 0 && firstCol < board.GetLength(1);
}
/*
 *

2 3
1 2 3
4 5 6
swap 0 0 1 1
swap 10 9 8 7
swap 0 1 1 0
END

result:
5 2 3
4 1 6
Invalid input!
5 4 3
2 1 6

1 2
Hello World
0 0 0 1
swap 0 0 0 1
swap 0 1 0 0
END

result:
Invalid input!
World Hello
Hello World

*/