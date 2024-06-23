
int beeRow = 0;
int beeCol = 0;
int beeEnergy = 15;
int sizeHive = int.Parse(Console.ReadLine());
char[,] beeHive = new char[sizeHive, sizeHive];

for (int row = 0; row < beeHive.GetLength(0); row++)
{
    char[] input = Console.ReadLine().ToCharArray();
    for (int col = 0; col < input.Length; col++)
    {
        beeHive[row, col] = input[col];
        if (beeHive[row, col] == 'B')
        {
            beeRow = row;
            beeCol = col;
            beeHive[row, col] = '-';
        }
    }
}
int nectar = 0;
// bool end = true;
// hive or no energy
while (true)
{
    string direction = Console.ReadLine();
    int nextRow = 0;
    int nextCol = 0;
    if (direction == "left")
    {
        nextCol = -1;
    }
    else if (direction == "right")
    {
        nextCol = 1;
    }
    else if (direction == "up")
    {
        nextRow = -1;
    }
    else if (direction == "down")
    {
        nextRow = 1;
    }
    beeEnergy--;
    beeRow += nextRow;
    beeCol += nextCol;
    if (!IsInside(beeHive, beeRow, beeCol))
    {
        // da mislim
        if (direction == "left")
        {
            beeCol = sizeHive - 1;
        }
        else if (direction == "right")
        {
            beeCol = 0;
        }
        else if (direction == "up")
        {
            beeRow = sizeHive - 1;
        }
        else if (direction == "down")
        {
            beeRow = 0;
        }
        char newPlace = beeHive[beeRow, beeCol];
        if (newPlace != '-' && newPlace != 'H')
        {
            char number = beeHive[beeRow, beeCol];
            int value = number - '0';
            nectar += value;
            beeHive[beeRow, beeCol] = '-';
        }
    }
    else
    {
        char newPlace = beeHive[beeRow, beeCol];
        if (newPlace != '-' && newPlace != 'H')
        {
            char number = beeHive[beeRow, beeCol];
            int value = number - '0';
            nectar += value;
            beeHive[beeRow, beeCol] = '-';
        }
    }
    bool onlyOneTime = false;
    if (onlyOneTime != true)
    {
        onlyOneTime = true;
        if (beeEnergy == 0 && nectar < 30)
        {
            break;
        }
        else if (beeEnergy == 0 && nectar >= 30)
        {
            beeEnergy = nectar - 30;
            nectar -= 30;
            if (beeEnergy == 0)
            {
                break;
            }
        }
    }

    if (beeHive[beeRow, beeCol] == 'H')
    {
        if (nectar >= 30)
        {
            Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {beeEnergy}");
            beeHive[beeRow, beeCol] = 'B';
            break;
        }
        else
        {
            Console.WriteLine("Beesy did not manage to collect enough nectar.");
            beeHive[beeRow, beeCol] = 'B';
            break;
        }
    }
}
if (beeEnergy == 0)
{
    Console.WriteLine("This is the end! Beesy ran out of energy.");
    beeHive[beeRow, beeCol] = 'B';
}
for (int row = 0; row < beeHive.GetLength(0); row++)
{
    for (int col = 0; col < beeHive.GetLength(1); col++)
    {
        Console.Write(beeHive[row, col]);
    }
    Console.WriteLine();
}
static bool IsInside(char[,] board, int row, int col)
    => row >= 0 && row < board.GetLength(0)
    && col >= 0 && col < board.GetLength(1);
// honey success 30 nectar

// if nectar is == 30 but no hive it moves along

/*
5
--B--
H-987
-4812
5----
2----
down
right
right
down
left
left
left
down
left
up
up

*/