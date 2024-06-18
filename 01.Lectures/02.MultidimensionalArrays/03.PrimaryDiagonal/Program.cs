using System.Diagnostics.CodeAnalysis;
using System.Numerics;

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
int sumDiagonal = 0;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(0); col++)
    {
        if (row == col)
        {
            sumDiagonal += matrix[row, col];
        }
    }
}
Console.WriteLine(sumDiagonal);

/*
3
11 2 4
4 5 6
10 8 -12

result
4

3
1 2 3
4 5 6
7 8 9

result
15

*/