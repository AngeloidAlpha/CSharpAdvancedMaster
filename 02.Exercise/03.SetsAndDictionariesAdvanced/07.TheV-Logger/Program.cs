
string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, HashSet<string>> vloggers = new();
Dictionary<string, int[]> followersFollwing = new();

while (input[0] != "Statistics")
{
    string vloggerName = input[0];
    string command = input[1];
    int follwer = 0;

    if (command == "joined")
    {
        if (!vloggers.ContainsKey(command))
        {
            followersFollwing.Add(vloggerName, new int[1]);
            vloggers.Add(vloggerName, new HashSet<string>());
        }
    }

    else if (command == "followed")
    {
        string currentvlogger = input[2];
        if (vloggers.ContainsKey(currentvlogger))
        {
            if (vloggerName != currentvlogger)
            {
                follwer++;
                // followersFollwing[vloggerName];
                vloggers[vloggerName].Add(currentvlogger);
            }
        }
    }
    input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
}
int maxFollowers = 0;
string maxFollowedPerson = string.Empty;
foreach (var name in vloggers)
{
    int numberOfFollowers = name.Value.Count();
    if (numberOfFollowers > maxFollowers)
    {
        maxFollowers = numberOfFollowers;
        maxFollowedPerson = name.Key;
    }
}
Console.WriteLine($"The V-Logger has a total of {vloggers.Keys.Count()} vloggers in its logs.");
Console.WriteLine($"{maxFollowedPerson} : {maxFollowers} followers, {0} following");
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

result

*/