int rows = int.Parse(Console.ReadLine());
int[][] jaggedArr = new int[rows][];

for (int i = 0; i < rows; i++)
{
    jaggedArr[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
}
string command;
while ((command = Console.ReadLine().ToLower()) != "end")
{
    string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    string action = tokens[0];
    int row = int.Parse(tokens[1]);
    int col = int.Parse(tokens[2]);
    int value = int.Parse(tokens[3]);

    if (row < 0 || row >= rows || col < 0 || col >= jaggedArr.Length)
    {
        Console.WriteLine("Invalid coordinates");
        continue;
    }
    switch (action)
    {
        case "add":
            jaggedArr[row][col] += value;
            break;
        case "subtract":
            jaggedArr[row][col] -= value;
            break;
        default:
            break;
    }
}

foreach (var row in jaggedArr)
{
    Console.WriteLine(string.Join(" ", row));
}
/*
3
1 2 3
4 5 6 7
8 9 10
Add 0 0 5
Subtract 1 2 2
Subtract 1 4 7
END

result: 
Invalid coordinates
6 2 3
4 5 4 7
8 9 10

4
1 2 3 4
5
8 7 6 5
4 3 2 1
Add 4 4 100
Add 3 3 100
Subtract -1 -1 42
Subtract 0 0 42
END

result
Invalid coordinates
Invalid coordinates
-41 2 3 4
5
8 7 6 5
4 3 2 101
*/