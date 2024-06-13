//"{contest}:{password for contest}" 
//"end of contests". 
// създаваме библютека за изпитите и паролите им
Dictionary<string, string> contestPasswords
    = new Dictionary<string, string>();

// създаваме библютека която ще държи имената им и техните постижения
Dictionary<string, Dictionary<string, int>> userContests =
    new Dictionary<string, Dictionary<string, int>>();

// приемаме вход
string input = Console.ReadLine();
// питаме тоя вход дали е "end of contests" ако не прибавяме хората и техните пароли
while (input != "end of contests")
{
    string[] inputInfo = input.Split(':');

    string contest = inputInfo[0];
    string password = inputInfo[1];

    contestPasswords.Add(contest, password);

    input = Console.ReadLine();
}
// след това питаме за "end of submissions" и ако не получаваме това записваме тяхните постижения
input = Console.ReadLine();

while (input != "end of submissions")
{
    //"{contest}=>{password}=>{username}=>{points}
    string[] inputInfo = input.Split("=>");

    string contest = inputInfo[0];
    string password = inputInfo[1];
    string username = inputInfo[2];
    int points = int.Parse(inputInfo[3]);

    // това е филтър за неправилни задания
    // питаме обратното на това дали имаме такъв изпит с парола
    if (!(contestPasswords.ContainsKey(contest)
        && contestPasswords[contest] == password))
    {
        // ако намерим такъв преминаваме към нов
        input = Console.ReadLine();
        continue;
    }
    // питаме дали човека вече е в библютеката ако не го добавяме
    if (!userContests.ContainsKey(username))
    {
        // добавяме името му с value нова библютека която ще пази даденото упражнение и точките 
        userContests.Add(username, new Dictionary<string, int>());
    }
    // бъркаме в добавения човек и питаме дали вече има това задание ако не го добавяме с 0 точки
    if (!userContests[username].ContainsKey(contest))
    {
        userContests[username].Add(contest, 0);
    }
    // после бъркаме в името на човека бъркаме в заданието му и даваме value на точките points
    if (points > userContests[username][contest])
    {
        // тук записваме само наравно (за да може ако е повишена просто да я замести)
        userContests[username][contest] = points;
    }
    // приемаме следващия човек
    input = Console.ReadLine();
}
// искаме да намерим топ кандидата от всичките
// записваме чрез нова променлива от тип var (за да не я изписваме изцяло)
// после използваме анонимна функция OrderByDescending(x => x.Value.Sum(y => y.Value))
// и питаме 1вия от този нов лист да ни го присвои с .FirstOrDefault();
var topCandidate = userContests
    .OrderByDescending(x => x.Value.Sum(y => y.Value))
    .FirstOrDefault();
// изписваме кандидата който е 1ви
Console.WriteLine($"Best candidate is {topCandidate.Key} with total {topCandidate.Value.Values.Sum(x => x)} points.");

//string topCanidate = string.Empty;
//int maxPoints = int.MinValue;

//foreach (var (user, contest) in userContests)
//{
//    int totalSum = contest.Values.Sum(x => x);

//    if (totalSum > maxPoints)
//    {
//        maxPoints = totalSum;
//        topCanidate = user;
//    }
//}

Console.WriteLine("Ranking:");

// създаваме 2 цикъла въртящи 1во името на човека(key) и заданията му (value)
foreach (var (user, contests) in userContests.OrderBy(x => x.Key))
{
    Console.WriteLine(user);

    // въртим после в contests което е вече (key) за нашите точки и contest.Value за точките
    foreach (var contest in contests.OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
    }
}
/*
Part One Interview:success
Js Fundamentals:JSFundPass
C# Fundamentals:fundPass
Algorithms:fun
end of contests
C# Fundamentals=>fundPass=>Tanya=>350
Algorithms=>fun=>Tanya=>380
Part One Interview=>success=>Nikola=>120
Java Basics Exam=>JSFundPass=>Parker=>400
Part One Interview=>success=>Tanya=>220
OOP Advanced=>password123=>BaiIvan=>231
C# Fundamentals=>fundPass=>Tanya=>250
C# Fundamentals=>fundPass=>Nikola=>200
Js Fundamentals=>JSFundPass=>Tanya=>400
end of submissions

result:
Best candidate is Tanya with total 1350 points.
Ranking:
Nikola
#  C# Fundamentals -> 200
#  Part One Interview -> 120
Tanya
#  Js Fundamentals -> 400
#  Algorithms -> 380
#  C# Fundamentals -> 350
#  Part One Interview -> 220

Java Advanced:funpass
Part Two Interview:success
Math Concept:asdasd
Java Web Basics:forrF
end of contests
Math Concept=>ispass=>Monika=>290
Java Advanced=>funpass=>Simon=>400
Part Two Interview=>success=>Drago=>120
Java Advanced=>funpass=>Petyr=>90
Java Web Basics=>forrF=>Simon=>280
Part Two Interview=>success=>Petyr=>0
Math Concept=>asdasd=>Drago=>250
Part Two Interview=>success=>Simon=>200
end of submissions

result:
Best candidate is Simon with total 880 points.
Ranking: 
Drago
#  Math Concept -> 250
#  Part Two Interview -> 120
Petyr
#  Java Advanced -> 90
#  Part Two Interview -> 0
Simon
#  Java Advanced -> 400
#  Java Web Basics -> 280
#  Part Two Interview -> 200
*/