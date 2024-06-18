int[] dimensions = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[,] matrix = new int[dimensions[0], dimensions[1]];
for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] values = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = values[col];
    }
}
// пишем минимум Int стойност (защото матрицата може да съдържа отрицателни числа (ако поставим 0 то то ще е по-голямо от тях)
int maxSum = int.MinValue;
int maxSumRow = 0;
int maxSumCol = 0;

for (int row = 0; row < matrix.GetLength(0) - 1; row++)
{
    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
    {
        // трябва да изпишем квадратчето от които координати да съберем сумата
        // за да не излиза това квадратче извън матрицата то ние ще въртим циклите тук с 1 по-малко от максималния брой дължина
        // matrix.GetLength(0) - 1 за редовете и matrix.GetLength(1) - 1 за колоните
        int currSum =
            matrix[row, col] + matrix[row, col + 1] +
            matrix[row + 1, col] + matrix[row + 1, col + 1];
        // условие за да запазваме винаги най-голямата сума от квадратите и неговата начална позиция
        // след като знаем началния индекс ще може да изпишем целия квадрат с най-голяма сума в Console.WriteLine
        if (currSum > maxSum)
        {
            maxSumRow = row;
            maxSumCol = col;
            maxSum = currSum;
        }
    }
}
Console.WriteLine($"{matrix[maxSumRow, maxSumCol]} {matrix[maxSumRow, maxSumCol + 1]}");
Console.WriteLine($"{matrix[maxSumRow + 1, maxSumCol]} {matrix[maxSumRow + 1, maxSumCol + 1]}");
Console.WriteLine(maxSum);
/*
3, 6
7, 1, 3, 3, 2, 1
1, 3, 9, 8, 5, 6
4, 6, 7, 9, 1, 0

output
9 8
7 9
33

2, 4
10, 11, 12, 13
14, 15, 16, 17

output
12 13 
16 17 
58

*/