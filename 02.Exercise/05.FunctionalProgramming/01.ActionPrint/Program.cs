// използване на Action
string[] names = Console.ReadLine().Split();
Action<string[]> printnames = allNames => Console.WriteLine(string.Join(Environment.NewLine, allNames));

printnames(names);
// използване на разписан метод от нас
PrintNames(names);

static void PrintNames(string[] names)
{
    Console.WriteLine(string.Join(Environment.NewLine, names));
}
/*
Lucas Noah Tea
result:
Lucas
Noah
Tea

Teo Lucas Harry
result:
Teo
Lucas
Harry

Ashurbanipal Napoleon Caeser
result:
Ashurbanipal
Napoleon
Caeser
*/