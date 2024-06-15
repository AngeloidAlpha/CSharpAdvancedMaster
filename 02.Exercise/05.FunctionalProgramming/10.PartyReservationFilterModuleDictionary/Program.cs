
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
// тука вместо да имаме проверки извикваме директно ключа и value-то което е фукцията за смятане
Dictionary<string, Func<string, string, bool>> predicate = new()
{
    { "Starts with",  (name, value) => name.StartsWith(value) },
    { "Ends with",  (name, value) => name.EndsWith(value) },
    { "Contains",  (name, value) => name.Contains(value) },
    { "Length", (name, value) => name.Length == int.Parse(value) },
};

foreach (string items in operations)
{
    string[] operationInfo = items.Split(";", StringSplitOptions.RemoveEmptyEntries);
    string operation = operationInfo[0];
    string value = operationInfo[1];
    names = names.Where(name => !predicate[operation](name, value)).ToList();
}
Console.WriteLine(string.Join(" ", names));
/*
Peter Misha Slav
Add filter;Starts with;P
Add filter;Starts with;M
Print

result:
Slav

Peter Misha John
Add filter;Starts with;P
Add filter;Starts with;M
Remove filter;Starts with;M
Print

result:
Misha John
*/