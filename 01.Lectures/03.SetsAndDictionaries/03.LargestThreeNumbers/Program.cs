var numbers = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries) // разделя и премахва празни пространства
    .Select(int.Parse) // парсва ги в интеджери
    .OrderByDescending(x => x) // пренарежда ги от най-голямото към най-малкото
    .Take(3); // 1вите 3 елемента

Console.WriteLine(string.Join(" ", numbers));

/*

10 30 15 20 50 5
result:
50 30 20

20 30
result:
30 20

*/