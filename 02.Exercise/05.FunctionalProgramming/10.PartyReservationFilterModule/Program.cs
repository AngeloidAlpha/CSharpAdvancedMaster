
using System.Buffers;

List<string> names = Console.ReadLine().Split().ToList();

string command = Console.ReadLine();

List<string> operations = new List<string>();

while (command != "Print")
{
    string[] commandInfo = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
    string filterCommand = commandInfo[0];
    string filter = commandInfo[1];
    string value = commandInfo[2];

    if (filterCommand == "Add filter")
    {
        operations.Add($"{filter};{value}");
    }
    else
    {
        operations.Remove($"{filter};{value}");
    }

    command = Console.ReadLine();
}