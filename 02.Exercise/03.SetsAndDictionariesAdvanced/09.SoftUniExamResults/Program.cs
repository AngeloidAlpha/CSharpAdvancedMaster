
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

*/