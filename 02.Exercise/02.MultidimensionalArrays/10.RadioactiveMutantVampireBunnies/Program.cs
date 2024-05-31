// да си изпишем данните в програмата

int[] dimensions = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int rows = dimensions[0];
int cols = dimensions[1];

char[,] board = new char[rows, cols];

int playerRow = 0;
int playerCol = 0;

List<int> bunnies = new List<int>();

for (int row = 0; row < board.GetLength(0); row++)
{
    char[] input = Console.ReadLine().ToCharArray();

    for (int col = 0; col < board.GetLength(1); col++)
    {
        // напълване на матрицата
        board[row, col] = input[col];
        // намиране на играча и записване на позицията му
        // намиране на мутиралите зайчета
        if (board[row, col] == 'P')
        {
            playerRow = row;
            playerCol = col;
        }
        if (board[row, col] == 'B')
        {
            bunnies.Add(row);
            bunnies.Add(col);
        }
    }
}
string directions = Console.ReadLine();
bool playerWon = false;
bool playerDied = false;

// започваме да се питаме ако го преместим на празно място (.) всичко е ОК, ако стъпи на заек приключва играта
// зайците започват да запълват местата около тях с всеки цикъл

foreach (var direction in directions)
{
    // зануляване на играча първо после правим логиката за местенето
    board[playerRow, playerCol] = '.';

    if (direction == 'L' && IsInside(board, playerRow, playerCol - 1))
    {
        playerCol--;
    }
    else if (direction == 'R' && IsInside(board, playerRow, playerCol + 1))
    {
        playerCol++;
    }
    else if (direction == 'U' && IsInside(board, playerRow - 1, playerCol))
    {
        playerRow--;
    }
    else if (direction == 'D' && IsInside(board, playerRow + 1, playerCol))
    {
        playerRow++;
    }
    // печели играта
    else
    {
        playerWon = true;
    }
    // ако стъпи на зайче умира
    if (board[playerRow, playerCol] == 'B')
    {
        playerDied = true;
    }
    else if (!playerWon)
    {
        board[playerRow, playerCol] = 'P';
    }
    //правим един цикъл преминаващ от листа от зайчета и ги записваме с ред и колона (за да може да ги размножим в околните места
    // презкачаме през едино в този лист
    for (int i = 0; i < bunnies.Count - 1; i += 2)
    {
        int bunnyRow = bunnies[i];
        int bunnyCol = bunnies[i + 1];

        // искаме всички възможни позиция за размножаване на зайчето (+) нагоре надолу наляво надясно
        // съкратено елегантно решение (като в задача 7 за дадените координати на кончето)
        int[] possitions =
        {
            -1, 0,
            1, 0,
            0, 1,
            0, -1
        };
        // въртим цикъл през тези позиции като прескачаме по 1
        // записваме всяка позиция в ред и колона
        // питаме те дали са в матрицата
        // и питаме вътре в нея ако е човек да го убием а ако е празно да сложем зайче
        for (int p = 0; p < possitions.Length - 1; p += 2)
        {
            int nextRow = bunnyRow + possitions[p];
            int nextCol = bunnyCol + possitions[p + 1];

            if (IsInside(board, nextRow, nextCol))
            {
                if (board[nextRow, nextCol] == 'P')
                {
                    playerDied = true;
                }
                board[nextRow, nextCol] = 'B';
            }
        }

    }

    // ако умре или е спечелил е true приключваме цикъла
    if (playerDied || playerWon)
    {
        break;
    }
    // трябва тук да им update-нем позициите на зайчетата както направихме в началото на задачата
    bunnies = new List<int>();
    for (int row = 0; row < board.GetLength(0); row++)
    {
        for (int col = 0; col < board.GetLength(1); col++)
        {
            if (board[row, col] == 'B')
            {
                bunnies.Add(row);
                bunnies.Add(col);
            }
        }
    }
}
for (int row = 0; row < board.GetLength(0); row++)
{
    for (int col = 0; col < board.GetLength(1); col++)
    {
        Console.Write(board[row, col]);
    }
    Console.WriteLine();
}
Console.WriteLine($"{(playerWon ? "won" : "dead")}: {playerRow} {playerCol}");


bool IsInside(char[,] board, int row, int col)
{
    return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
}
/*
5 8
.......B
...B....
....B..B
........
..P.....
ULLL

result:
BBBBBBBB
BBBBBBBB
BBBBBBBB
.BBBBBBB
..BBBBBB
won: 3 0

4 5
.....
.....
.B...
...P.
LLLLLLLL

result:
.B...
BBB..
BBBB.
BBB..
dead: 3 1

*/