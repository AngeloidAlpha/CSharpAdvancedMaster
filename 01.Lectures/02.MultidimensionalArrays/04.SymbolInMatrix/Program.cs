int dimensions = int.Parse(Console.ReadLine());

char[,] matrix = new char[dimensions, dimensions];
for (int row = 0; row < dimensions; row++)
{
    string values = Console.ReadLine();

    for (int col = 0; col < dimensions; col++)
    {
        matrix[row, col] = values[col];
    }
}

string searchSymbol = Console.ReadLine();

for (int row = 0; row < dimensions; row++)
{
    for (int col = 0; col < dimensions; col++)
    {
        if (matrix[row, col] == searchSymbol[0])
        {
            Console.WriteLine($"({row}, {col})");
            return;
        }
    }
}
Console.WriteLine($"{searchSymbol} does not occur in the matrix");

/*
3
ABC
DEF
X!@
!
result
(2, 1)

4
asdd
xczc
qwee
qefw
4

result
4 does not occur in the matrix

*/