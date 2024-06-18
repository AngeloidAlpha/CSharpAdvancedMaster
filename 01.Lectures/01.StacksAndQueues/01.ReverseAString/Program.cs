string input = Console.ReadLine();

Stack<char> reversed = new(input);
Console.Write(string.Join("", reversed));