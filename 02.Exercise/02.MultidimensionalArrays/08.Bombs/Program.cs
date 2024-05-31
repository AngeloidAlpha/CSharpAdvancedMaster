// да си вземем данните и запишем в матрица
// дадена ни е големината на матрицата и после масив от интеджери за всеки ред

using System.Text;

int n = int.Parse(Console.ReadLine());

int[,] board = new int[n, n];

for (int row = 0; row < board.GetLength(0); row++)
{
    int[] input = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();
    for (int col = 0; col < board.GetLength(1); col++)
    {
        board[row, col] = input[col];
    }
}
// бомбите в нов масив
int[] bombs = Console.ReadLine()
    .Split(' ', ',')
    .Select(int.Parse)
    .ToArray();
// обхождаме масива от координати на бомби 
// вземаме кординатите и ги вписваме във 2 променлини за ред и колона
// силата на бомбата ще е избрания елемент
// ако елемента е <=0 то тогава не правим нищо
// правим цикъла да презкача 1 индекс
for (int i = 0; i < bombs.Length - 1; i += 2)
{
    int targetRow = bombs[i];
    int targetCol = bombs[i + 1];
    int value = board[targetRow, targetCol];

    if (board[targetRow, targetCol] <= 0)
    {
        continue;
    }
    // правим цикъл който започва от на бомбата координатите с -1 и завършва с координати +1 (правим така един 3х3 квадрат около нея)
    for (int row = targetRow - 1; row <= targetRow + 1; row++)
    {
        for (int col = targetCol - 1; col <= targetCol + 1; col++)
        {
            // питаме дали всеки индекс е вътре в този кръг и дали стойноста е >0
            // за да не правим операция на нещо което не съществува
            if (IsInside(board, row, col) && board[row, col] > 0)
            {
                board[row, col] -= value;
            }
        }
    }
}

// питаме колко от клетките все още имат по-висока стойност от 0 и колко е тяхната сума
// чрез стрингбилдер може да пресъздадем нашата матрица
int aliveCells = 0;
int cellsSum = 0;
StringBuilder stringBuilder = new StringBuilder();

for (int row = 0; row < board.GetLength(0); row++)
{
    for (int col = 0; col < board.GetLength(1); col++)
    {
        if (board[row, col] > 0)
        {
            aliveCells++;
            cellsSum += board[row, col];
        }
        // тука правим един голям стринг събираме стойноста с празно място
        stringBuilder.Append(board[row, col] + " ");
    }
    // тук му казваме да започне на нов ред
    stringBuilder.AppendLine();
}
Console.WriteLine($"Alive cells: {aliveCells}");
Console.WriteLine($"Sum: {cellsSum}");
Console.WriteLine(stringBuilder);

bool IsInside(int[,] board, int row, int col)
{
    return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
}

/*
4
8 3 2 5
6 4 7 9
9 9 3 6
6 8 1 2
1,2 2,1 2,0

result:
Alive cells: 3
Sum: 12
8 -4 -5 -2
-3 -3 0 2
0 0 -4 -1
-3 -1 -1 2

3
7 8 4
3 1 5
6 4 9
0,2 1,0 2,2

result:
Alive cells: 3
Sum: 8
4 1 0
0 -3 -8
3 -8 0

*/