
Func<string,int,bool> func = (name, length)
    => name.Length <= length;

int lenght = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split()
    .Where(names => func(names, lenght))
    .ToArray();

Console.WriteLine(string.Join(Environment.NewLine, names));
// същото отгоре без да правя масив от имената 
/*
Console.ReadLine()
    .Split()
    .Where(names => func(names, lenght))
    .ToList()
    .ForEach(Console.WriteLine);
*/
/*
4
Karl Anna Kris Yahto
result:
Karl
Anna
Kris

4
Karl James George Robert Patricia
result:
Karl
*/