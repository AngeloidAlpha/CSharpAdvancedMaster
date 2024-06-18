int[] dimensions = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[,] matrix = new int[dimensions[0], dimensions[1]];
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
// искаме да обхождаме матрицата първо колона по колона и всеки елемент от нея колона
// правим променлива за да сумираме колко е общо за дадената колона и принриваме още в цикъла

for (int col = 0; col < matrix.GetLength(1); col++)
{
    int sum = 0;
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        sum += matrix[row, col];
    }
    Console.WriteLine(sum);
}
/*
3, 6
7 1 3 3 2 1
1 3 9 8 5 6
4 6 7 9 1 0
*/