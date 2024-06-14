
List<string> names = Console.ReadLine()
    .Split()
    .ToList();

string command = Console.ReadLine();
// изписване на функцията с тернарни оператори
// пишем променливите които получаваме и какво искаме да получим
// после изписваме (3те променливи които ще използваме) =>
// започваме да пишем математиката за функцията
// искаме да връща при оператор "StartsWith" да вземе всичките думи и запише в нов лист започващи с дадена буква
// споле имаме else if написано с : питащ дали оператор-а е с "EndsWith" ако е така да ми ги напише нов лист с думите свъшващи с дадена буква
// и ако това не е вярно накрая да ми запише лист с всички думи от дадена дължина
Func<List<string>, string, string, List<string>> removal
    = (listOfNames, operations, value) =>
    {
        return operations == "StartsWith"
        ? listOfNames.Where(x => x.StartsWith(value)).ToList()
        : operations == "EndsWith"
        ? listOfNames.Where(x => x.EndsWith(value)).ToList()
        : listOfNames.Where(x => x.Length == int.Parse(value)).ToList();
    };
// започваме да използваме функцията ни
while (command != "Party!")
{
    string[] commandInfo = command.Split();
    string commandName = commandInfo[0];
    string operation = commandInfo[1];
    string value = commandInfo[2];
    // извикваме нов Лист с параметри = функцията можейки да изпишем дадените променливи в скоби
    List<string> targetNames = removal(names, operation, value);

    if (commandName == "Remove")
    {
        // после вземаме текущия лист и питаме в него всички които съвпадат да ги презапишем в нов (само че обратното с ! )
        // така ще презапишем само тези които не съвпадат 
        names = names.Where(x => !targetNames.Contains(x)).ToList();
    }
    else if (commandName == "Double")
    {
        foreach (var item in targetNames)
        {
            int index = names.IndexOf(item);
            names.Insert(index, item);
        }
    }
    command = Console.ReadLine();
}
if (names.Count > 0)
{
    Console.WriteLine(string.Join(", ", names) + " are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}
/*
Peter Misha Stephen
Remove StartsWith P
Double Length 5
Party!

result:
Misha, Misha, Stephen are going to the party!

Peter
Double StartsWith Pete
Double EndsWith eter
Party!

result:
Peter, Peter, Peter, Peter are going to the party!

Peter
Remove StartsWith P
Party!

result:
Nobody is going to the party!
*/