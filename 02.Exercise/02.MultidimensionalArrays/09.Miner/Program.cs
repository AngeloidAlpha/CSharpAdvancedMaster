// започваме със изписването на всичките си inputs


using System.Xml.Schema;

int rows = int.Parse(Console.ReadLine());
string[] directions = Console.ReadLine().Split();

char[,] board = new char[rows, rows];
int totalCoals = 0;
int minorRow = 0;
int minorCol = 0;
int minedCoals = 0;
bool isGameOver = false;
// въртим из матрицата си
for (int row = 0; row < board.GetLength(0); row++)
{
    // като всеки ред е нов стринг масив
    string[] input = Console.ReadLine().Split();

    for (int col = 0; col < board.GetLength(1); col++)
    {
        // който го запълваме като минаваме през колоните
        // забележка може да изпишем масива като единична матрица input[col][0]
        board[row, col] = input[col][0];
        // докато сме тук също ще запишем миньора ни и колко въглища имаме
        if (board[row, col] == 'c')
        {
            totalCoals++;
        }
        if (board[row, col] == 's')
        {
            minorRow = row;
            minorCol = col;
        }
    }
}
// какви са ни възможните действия в събирането
// питаме се дали може да вървим в посоката, питаме дали има въглища, питаме дали не е край на играта, и да се преместим там

foreach (var direction in directions)
{
    // това вече е новата позиция на миньора
    if (direction == "left" && IsInside(board, minorRow, minorCol - 1))
    {
        minorCol--;
    }
    else if (direction == "right" && IsInside(board, minorRow, minorCol + 1))
    {
        minorCol++;
    }
    else if (direction == "up" && IsInside(board, minorRow - 1, minorCol))
    {
        minorRow--;
    }
    else if (direction == "down" && IsInside(board, minorRow + 1, minorCol))
    {
        minorRow++;
    }
    else
        continue;
    // започваме да питаме дали в тази клетка има нещата които търсим?
    if (board[minorRow, minorCol] == 'e')
    {
        isGameOver = true;
    }
    else if (board[minorRow, minorCol] == 'c')
    {
        board[minorRow, minorCol] = '*';
        minedCoals++;
    }
    if (totalCoals == minedCoals)
    {
        break;
    }

}
// накрая да пишем логиката за изписване при 3те случая на край на играта
if (totalCoals == minedCoals)
{
    Console.WriteLine($"You collected all coals! ({minorRow}, {minorCol})");
}
else if (isGameOver)
{
    Console.WriteLine($"Game over! ({minorRow}, {minorCol})");
}
else
{
    Console.WriteLine($"{totalCoals - minedCoals} coals left. ({minorRow}, {minorCol})");
}

bool IsInside(char[,] board, int row, int col)
{
    return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
}
/*
5
up right right up right
* * * c *
* * * e *
* * c * *
s * * c *
* * c * *

result:
Game over! (1, 3)

4
up right right right down
* * * e
* * c *
* s * c
* * * *

result:
You collected all coals! (2, 3)

6
left left down right up left left down down down
* * * * * *
e * * * c *
* * c s * *
* * * * * *
c * * * c *
* * c * * *

result: 
3 coals left. (5, 0)
*/