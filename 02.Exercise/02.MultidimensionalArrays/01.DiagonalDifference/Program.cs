int dimensions = int.Parse(Console.ReadLine());

int[,] matrix = new int[dimensions, dimensions];
for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] values = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = values[col];
    }
}
int primaryDiagonall = 0;
int secondaryDiagonall = 0;
// По-лесно решение: главния диагонал е винаги индекса на реда (0,0) (1,1) (2,2) и т.нат 
// т.е. може да ползваме директно priamaryDiahonall += matrix[row, row]; без 2рия цикъл и без проверката
for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(0); col++)
    {
        if (row == col)
        {
            // вземането на стойноста от матрицата matrix[row, col] 
            primaryDiagonall += matrix[row, col];
        }
    }
}
// правим променлива която ще вземе дължината на колоните в 3,2,1 което в индекси ще е 2,1,0 (изваждаме с -1)

// а в matrix[row, colDiag--] с единициа за да получим в последствие и по-малките
int colDiag = matrix.GetLength(1) - 1;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    secondaryDiagonall += matrix[row, colDiag--];
}

Console.WriteLine(Math.Abs(primaryDiagonall - secondaryDiagonall));
/*
3
11 2 4
4 5 6
10 8 -12

result:
15
*/