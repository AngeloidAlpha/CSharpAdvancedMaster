string[] inputNames = Console.ReadLine().Split();
Action<string[]> printnames = names
    => Console.WriteLine(
        string.Join(
            Environment.NewLine,
            names.Select(name => "Sir " + name)));

printnames(inputNames);
/*
 друг начин за решаване на задачата с лист на който може да ползваме накрая .ForEach
List<string> inputNames = Console.ReadLine().Split().ToList();
Action<string> print = name => Console.WriteLine("Sir" + name);
inputNames.ForEach(print);
*/
/*
Eathan Lucas Noah Arthur
result:
Sir Eathan
Sir Lucas
Sir Noah
Sir Arthur

Lucas Jade Hugo
result:
Sir Lucas
Sir Jade
Sir Hugo

Ashurbanipal Napoleon Caeser
result:
Sir Ashurbanipal
Sir Napoleon
Sir Caeser

*/