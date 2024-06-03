
string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, SortedSet<string>> vloggersFollowing = new();
Dictionary<string, SortedSet<string>> vloggersFollowed = new();

while (input[0] != "Statistics")
{
    string vloggerName = input[0];
    string command = input[1];

    if (command == "joined")
    {
        // TryAdd ни спестява проверката от if (!vloggersFollowing.ContainsKey(command))
        // ще се опита да добави вътре името ако го няма
        vloggersFollowed.TryAdd(vloggerName, new SortedSet<string>());
        vloggersFollowing.TryAdd(vloggerName, new SortedSet<string>());
    }

    else if (command == "followed")
    {
        string currentvlogger = input[2];
        if (vloggersFollowed.ContainsKey(vloggerName) && vloggersFollowing.ContainsKey(currentvlogger) && vloggerName != currentvlogger)
        {
            vloggersFollowing[vloggerName].Add(currentvlogger);
            vloggersFollowed[currentvlogger].Add(vloggerName);
        }
    }
    input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
}
Console.WriteLine($"The V-Logger has a total of {vloggersFollowing.Count()} vloggers in its logs.");
var sortedVloggers = vloggersFollowed
    // да подредим последвалите влогери по азбучен ред
    .OrderByDescending(x => x.Value.Count())
    // vloggerFollowing бръкнем в дадения човек [x.Key] и да извадим бройката на следващите го хора .Count
    .ThenBy(x => vloggersFollowing[x.Key].Count);

int counter = 1;
foreach (var name in sortedVloggers)
{
    Console.WriteLine($"{counter++}. {name.Key} : {name.Value.Count} followers, {vloggersFollowing[name.Key].Count} following");
    // как да направим да принтираме само 1вия
    // използваме counter-a за бройка при изписване 1,2,3,4, и т.нат.
    // започваме от 1 и добавяме едно след като е изписано
    if (counter == 2)
    {
        foreach (var vloggers in name.Value)
        {
            Console.WriteLine($"*  {vloggers}");
        }
    }
}

/*

EmilConrad joined The V-Logger
VenomTheDoctor joined The V-Logger
Saffrona joined The V-Logger
Saffrona followed EmilConrad
Saffrona followed VenomTheDoctor
EmilConrad followed VenomTheDoctor
VenomTheDoctor followed VenomTheDoctor
Saffrona followed EmilConrad
Statistics

result:
The V-Logger has a total of 3 vloggers in its logs.
1. VenomTheDoctor : 2 followers, 0 following
*  EmilConrad
*  Saffrona
2. EmilConrad : 1 followers, 1 following
3. Saffrona : 0 followers, 2 following                  

JennaMarbles joined The V-Logger
JennaMarbles followed Zoella
AmazingPhil joined The V-Logger
JennaMarbles followed AmazingPhil
Zoella joined The V-Logger
JennaMarbles followed Zoella
Zoella followed AmazingPhil
Christy followed Zoella
Zoella followed Christy
JacksGap joined The V-Logger
JacksGap followed JennaMarbles
PewDiePie joined The V-Logger
Zoella joined The V-Logger
Statistics

result:
The V-Logger has a total of 5 vloggers in its logs.
1. AmazingPhil : 2 followers, 0 following
*  JennaMarbles
*  Zoella
2. Zoella : 1 followers, 1 following
3. JennaMarbles : 1 followers, 2 following
4. PewDiePie : 0 followers, 0 following
5. JacksGap : 0 followers, 1 following

*/