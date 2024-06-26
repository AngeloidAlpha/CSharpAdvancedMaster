﻿
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
Func<List<string>, string, string, List<string>> filterNames = (names, operation, value) =>
{
    return operation == "Starts with" ? names.Where(x => x.StartsWith(value)).ToList()
    : operation == "Ends with" ? names.Where(x => x.EndsWith(value)).ToList()
    : operation == "Contains" ? names.Where(x => x.Contains(value)).ToList()
    : names.Where(x => x.Length == int.Parse(value)).ToList();
};

foreach (string items in operations)
{
    string[] operationInfo = items.Split(";", StringSplitOptions.RemoveEmptyEntries);
    string operation = operationInfo[0];
    string value = operationInfo[1];
    // на този ред става филтрацията на името
    List<string> filteredNames = filterNames(names, operation, value);
    // тука искаме да презапишем всички имена от листа като изключим това което сме намерили от предишния ред
    names = names.Where(x => !filteredNames.Contains(x)).ToList();
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