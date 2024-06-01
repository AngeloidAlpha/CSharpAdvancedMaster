// получаваме стринга
// създаваме сортирана библютека
// въртим през всичките символи и ги записваме във библютека
// ако има вече такива увеличаваме им стойноста 
// преминаваме през библютеката и изписваме

string input = Console.ReadLine();

SortedDictionary<char, int> charOccurences = new SortedDictionary<char, int>();

foreach (var currentChar in input)
{
    if (!charOccurences.ContainsKey(currentChar))
    {
        charOccurences.Add(currentChar, 0);
    }

    charOccurences[currentChar]++;
}

foreach (var (symbol, occurences) in charOccurences)
{
    Console.WriteLine($"{symbol}: {occurences} time/s");
}

/*
SoftUni rocks

result:
 : 1 time/s
S: 1 time/s
U: 1 time/s
c: 1 time/s
f: 1 time/s
i: 1 time/s
k: 1 time/s
n: 1 time/s
o: 2 time/s
r: 1 time/s
s: 1 time/s
t: 1 time/s

Did you know Math.Round rounds to the nearest even integer?

result:
 : 9 time/s
.: 1 time/s
?: 1 time/s
D: 1 time/s
M: 1 time/s
R: 1 time/s
a: 2 time/s
d: 3 time/s
e: 7 time/s
g: 1 time/s
h: 2 time/s
i: 2 time/s
k: 1 time/s
n: 6 time/s
o: 5 time/s
r: 3 time/s
s: 2 time/s
t: 5 time/s
u: 3 time/s
v: 1 time/s
w: 1 time/s
y: 1 time/s

*/