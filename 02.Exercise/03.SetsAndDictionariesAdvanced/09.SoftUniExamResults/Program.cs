
HashSet<string> bannedUsers = new HashSet<string>();
Dictionary<string, int> topResults = new Dictionary<string, int>();
Dictionary<string, int> submissions = new Dictionary<string, int>();

string input = Console.ReadLine();

while (input != "exam finished")
{
    string[] inputinfo = input.Split('-');

    string username = inputinfo[0];
    
    if (inputinfo[1] == "banned")
    {
        bannedUsers.Add(username);
    }
    if (!bannedUsers.Contains(username))
    {
        string exam = inputinfo[1];
        int point = int.Parse(inputinfo[2]);
        if (!submissions.ContainsKey(exam))
            {
                submissions.Add(exam, 0);
            }
        submissions[exam]++;

        if (!topResults.ContainsKey(username))
        {
            topResults.Add(username, point);
        }

        if (point > topResults[username])
        {
            topResults[username] = point;
        }
    }
    input = Console.ReadLine();
}
Console.WriteLine("Results:");

foreach(var item in topResults
    // да преминем през всички които не са баннати
    // и ги подрждаме по условие
    .Where(x => !bannedUsers.Contains(x.Key))
    .OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{item.Key} | {item.Value}");
}
Console.WriteLine("Submissions:");

foreach (var item in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}
/*
Peter-Java-84
George-C#-70
George-C#-84
Sam-C#-94
exam finished

result:

Results:
Sam | 94
George | 84
Peter | 84
Submissions:
C# - 3
Java - 1

Peter-Java-91
George-C#-84
Sam-JavaScript-90
Sam-C#-50
Sam-banned
exam finished

result:

Results:
Peter | 91
George | 84
Submissions:
C# - 2
Java - 1
JavaScript - 1
*/