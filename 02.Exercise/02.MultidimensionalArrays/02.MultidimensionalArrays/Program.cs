int[] dimensions = Console.ReadLine()
   .Split()
   .Select(int.Parse)
   .ToArray();

int rows = dimensions[0];
int collums = dimensions[1];

// създаваме матрица 
// попълваме матрицата с char 
char[,] matrix = new char[rows, collums];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    string[] input = Console.ReadLine().Split(); // string "A B C D" => ["A", "B", "C", "D"]

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = input[col][0]; // ["A"][0] => 'A' като нулата е просто че е 1вия ред и единствен)
        // масива може да се ипише като матрица със скрита колона [0] която не е записана
    }
}
// брой на еднаквите квадрати
// 2 цикъла за да минем през всички редове и колони
// нова променлива от тип bool за да отчете моментите когато квадратите са от едни и същи елементи
// и ще ги запише като прой когато bool е true
// изписване
int equalSquares = 0;

for (int row = 0; row < matrix.GetLength(0) - 1; row++)
{
    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
    {
        bool areEqual =
            matrix[row, col] == matrix[row + 1, col]
            && matrix[row, col + 1] == matrix[row + 1, col + 1]
            && matrix[row, col] == matrix[row + 1, col + 1];
        if (areEqual)
        {
            equalSquares++;
        }
    }
}
Console.WriteLine(equalSquares);
/*

3 4
A B B D
E B B B
I J B B

result:
2

2 2
a b
c d

result:
0

*/