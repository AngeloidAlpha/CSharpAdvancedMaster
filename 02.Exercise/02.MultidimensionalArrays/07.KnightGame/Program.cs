int rows = int.Parse(Console.ReadLine());

char[,] board = new char[rows, rows];

// Попълване на масива
for (int row = 0; row < board.GetLength(0); row++)
{
    char[] input = Console.ReadLine().ToCharArray();

    for (int col = 0; col < board.GetLength(1); col++)
    {
        board[row, col] = input[col];
    }
}
// брояч за броя коне премахнати
int removedKnights = 0;

while (true)
{
    // трябва да помним коня с най-много атаки и неговата позиция
    // слагаме maxAttacks в while цикъла защото така го зануляваме след всяко завъртване на 2та цикъла с кон с най-много попадения
    int maxAttacks = 0;
    int knightRow = 0;
    int knightCol = 0;
    // 2 цикъла за да обходим борда
    for (int row = 0; row < board.GetLength(0); row++)
    {
        for (int col = 0; col < board.GetLength(1); col++)
        {
            // трябва да помним коня на който сме с колко атаки е
            // ако борда е празен премини на следващото поле
            int currentAttacks = 0;

            if (board[row, col] != 'K')
            {
                continue;
            }
            // питаме дали хода на коня е валиден (дали е в матрицата) питайки първо дали имаме такова поле и
            // после питаме за ходене 2 нагоре и едно наляво или надясно има 'K'
            // за нагоре
            if (IsInside(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
            {
                currentAttacks++;
            }
            if (IsInside(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
            {
                currentAttacks++;
            }
            // за надолу
            if (IsInside(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
            {
                currentAttacks++;
            }
            if (IsInside(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
            {
                currentAttacks++;
            }
            // за наляво
            if (IsInside(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
            {
                currentAttacks++;
            }
            if (IsInside(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
            {
                currentAttacks++;
            }
            // за надясно
            if (IsInside(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
            {
                currentAttacks++;
            }
            if (IsInside(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
            {
                currentAttacks++;
            }
            // питаме дали настоящия кон е с максимални атаки
            if (currentAttacks > maxAttacks)
            {
                maxAttacks = currentAttacks;
                knightRow = row;
                knightCol = col;
            }
        }
    }
    // ако имаме кон който е с най-много атаки то тогава искаме този кон да го махнем и запишем с '0'
    if (maxAttacks > 0)
    {
        board[knightRow, knightCol] = '0';
        removedKnights++;
    }
    // спираме while цикъла
    else
    {
        break;
    }
}
Console.WriteLine(removedKnights);

static bool IsInside(char[,] board, int row, int col)
{
    return row >= 0 && row < board.GetLength(0)
        && col >= 0 && col < board.GetLength(1);
}
/*
5 
0K0K0
K000K
00K00
K000K 
0K0K0

result:
1

2
KK
KK

result:
0

8
0K0KKK00
0K00KKKK
00K0000K
KKKKKK0K
K0K0000K
KK00000K
00K0K000
000K00KK

result:
12

*/