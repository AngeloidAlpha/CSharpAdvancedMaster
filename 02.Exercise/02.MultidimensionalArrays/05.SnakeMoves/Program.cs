int[] dimensions = Console.ReadLine()
   .Split()
   .Select(int.Parse)
   .ToArray();

int rows = dimensions[0];
int cols = dimensions[1];

string snake = Console.ReadLine();

char[,] matrix = new char[rows, cols];
// трябва да запълним матрицата със думата която ни е подадена
// задачата е да пуснем змята да мине 1вия ред напред
// 2рия ред отзад напред
// 3тия от пред назад и т.нат докато свърши
// за да вземем определена буква от стринга записваме така snake[counter] counter почва от 0
// snake = "SoftUni"
// snake[0] = 'S' snake[1] = 'o' snake[2] = 'f' и т.нат.

// начина да сменяме посоката на редовете е да питаме дали реда е четен или нечетен
int counter = 0;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        if (row % 2 == 0)
        {
            // тук вземаме отляво надясно елементите
            matrix[row, col] = snake[counter++];

            if (counter == snake.Length)
            {
                counter = 0;
            }
        }
        else
        {
            // тук вземаме отдясно наляво елементите
            matrix[row, matrix.GetLength(1) - 1 - col] = snake[counter++];

            if (counter == snake.Length)
            {
                counter = 0;
            }
        }
    }
}
// така се изписва матрица с 2 цикъла
for (int row = 0; (row < matrix.GetLength(0)); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        Console.Write(matrix[row, col]);
    }
    Console.WriteLine();
}
/*
5 6
SoftUni

result:
SoftUn
UtfoSi
niSoft
foSinU
tUniSo
*/