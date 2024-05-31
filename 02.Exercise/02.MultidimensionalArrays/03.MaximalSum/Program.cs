int[] dimension = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

int rows = dimension[0];
int cols = dimension[1];

int[,] matrix = new int[rows, cols];

// цикъл за да напълним 2д матрицата 
for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] input = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries) //Beware!!!
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = input[col];
    }
}
// записваме макс сумата като започнем от минималната възможна за интеджер (тя ще се пренапише с каквато и да е от -intMax до +intMax
// питаме също от къде започва макс сумата за това създаваме променливи да помни започващия ред и колона
int maxSum = int.MinValue;
int targetRow = 0;
int targetCol = 0;
// цикъл за ред и колона която ще върти началния индекс който ще може да започне нашия куб от 3
// той ще бъде разписън по-нататък с 2 цикъла
for (int row = 0; row < matrix.GetLength(0) - 2; row++)
{
    for (int col = 0; col < matrix.GetLength(1) - 2; col++)
    {
        int currentSum = 0;
        // тук той е разписан в 2 цикъла въртящи спрямо началния ред и колона
        // събираме всичко в currentsum и ако тя е по-голяма я записваме в maxSum (за да може да я ползваме накрая при отговора)
        // също така записваме ни началната ред и колона когато стигнем до if проверката
        for (int i = row; i < row + 3; i++)
        {
            for (int j = col; j < col + 3; j++)
            {
                currentSum += matrix[i, j];
            }
        }

        if (currentSum > maxSum)
        {
            maxSum = currentSum;
            targetRow = row;
            targetCol = col;
        }
    }
}
// изписваме общата сума
// въртим цикли за да изпишем квадрата
Console.WriteLine($"Sum = {maxSum}");

for (int row = targetRow; row < targetRow + 3; row++)
{
    for (int col = targetCol; col < targetCol + 3; col++)
    {
        Console.Write(matrix[row, col] + " ");
    }
    Console.WriteLine();
}

/*

4 5
1 5 5 2 4
2 1 4 14 3
3 7 11 2 8
4 8 12 16 4

result:
Sum = 75
1 4 14
7 11 2
8 12 16

*/