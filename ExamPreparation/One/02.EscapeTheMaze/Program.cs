


int playerRow = 0;
int playerCol = 0;
int health = 100;
int sizeMatrix = int.Parse(Console.ReadLine());

char[,] board = new char [sizeMatrix, sizeMatrix];

for (int row = 0; row < board.GetLength(0); row++)
{
    char[] input = Console.ReadLine().ToCharArray();
    for (int col = 0; col < input.Length; col++)
    {
        board[row,col] =input[col];
        if (board[row,col] == 'P')
        {
            playerRow = row;
            playerCol = col;
        }
    }
}
while (true)
{
    string direction = Console.ReadLine();
    int nextRow = 0;
    int nextCol = 0;
    if (direction == "left")
    {
        nextRow = -1;
    }
    else if (direction == "right")
    {
        nextRow = 1;
    }
    else if (direction == "up")
    {
        nextCol = -1;
    }
    else if (direction == "down")
    {
        nextCol = 1;
    }
    if (!IsInside(board, playerRow + nextRow, playerCol + nextCol))
    {
        continue;
    }

    board[playerRow, playerCol] = '-';
    playerRow += nextRow;
    playerCol += nextCol;

    if (board[playerRow, playerCol] == 'M')
    {
        health -= 40;
    }
    if (health <= 0)
    {
        health = 0;
        board[playerRow, playerCol] = 'P';
        break;
    }
    if (board[playerRow, playerCol] == 'H')
    {
        health = Math.Min(health + 15, 100);
        /*
        health += 15;
        if (health > 100)
        {
            health = 100;
        } 
        */
    }
    if (board[playerRow, playerCol] == 'X')
    {
        board[playerRow, playerCol] = 'P';
        break;
    }
    board[playerRow, playerCol] = 'P';
    for (int row = 0; row < board.GetLength(0); row++)
    {
        for (int col = 0; col < board.GetLength(1); col++)
        {
            Console.Write(board[row, col]);
        }
        Console.WriteLine();
    }
}
if (health == 0)
{
    Console.WriteLine("Player is dead. Maze over!");
}
else
{
    Console.WriteLine("Player escaped the maze. Danger passed!");
}
Console.WriteLine($"Player's health: {health} units");

for (int row = 0; row < board.GetLength(0); row++)
{
    for (int col = 0; col < board.GetLength(1); col++)
    {
        Console.Write(board[row, col]);
    }
    Console.WriteLine();
}

static bool IsInside(char[,] board, int row, int col)
    => row >= 0 && row < board.GetLength(0)
    && col >= 0 && col < board.GetLength(1);
/*
5
-----
-PM--
-M---
---H-
-X---
down
right
down
down
left
*/