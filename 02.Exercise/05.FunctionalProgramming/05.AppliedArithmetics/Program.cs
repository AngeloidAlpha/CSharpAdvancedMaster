
int[] inputNumbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

string command = Console.ReadLine();

// обединено всичко в 1 функция
/*Func<int[], string, int[]> applyAritmetics
    = (numbers, operation) =>
    {
        return operation == "add"
        ? numbers.Select(x => x + 1).ToArray()
        : operation == "multiply"
        ? numbers.Select(x => x * 2).ToArray()
        : numbers.Select(x => x - 1).ToArray();
    };
*/
// това е изписано в няколко функции
Func<int[], int[]> add = numbers 
    => numbers.Select(x => x +1).ToArray();
Func<int[], int[]> subtract = numbers
    => numbers.Select(x => x - 1).ToArray();
Func<int[], int[]> multiply = numbers
    => numbers.Select(x => x * 2).ToArray();

while (command != "end")
{
    if (command == "print")
    {
        Console.WriteLine(string.Join(" ", inputNumbers));
    }
    else
    {
        inputNumbers = command == "add"
            ? add(inputNumbers)
            : command == "multiply"
            ? multiply(inputNumbers)
            : subtract(inputNumbers);
    }
    command = Console.ReadLine ();
    //inputNumbers = applyAritmetics(inputNumbers, command);
}
/*
1 2 3 4 5
add
add
print
end	

result:
3 4 5 6 7

5 10
multiply
subtract
print
end
result:
9 19

*/