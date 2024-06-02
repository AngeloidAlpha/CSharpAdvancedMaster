
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(" -> ");

    string color = input[0];
    string[] clothes = input[1].Split(",");

    if (!wardrobe.ContainsKey(color))
    {
        wardrobe.Add(color, new Dictionary<string, int>());
    }
    foreach (var item in clothes)
    {
        if (!wardrobe[color].ContainsKey(item))
        {
            wardrobe[color].Add(item, 0);
        }
        // това са библютеките които сме създали
        // Dictionary<string, Dictionary<string, int>> wardrobe
        // wardrobe = Dictionary<string, Dictionary<string, int>>;
        // wardrobe[color] = Dictionary<string, int>;
        // wardrobe[color][item] = int;
        wardrobe[color][item] += 1;

    }
}
string[] lookupValues = Console.ReadLine().Split();

foreach (var (color, clothes) in wardrobe)
{
    Console.WriteLine($"{color} clothes:");

    foreach (var (item, count) in clothes)
    {
        string outputValue = $"* {item} - {count}";

        if (color == lookupValues[0] && item == lookupValues[1])
        {
            outputValue += " (found!)";
        }
        Console.WriteLine(outputValue);
    }
}
/*
 * 
4
Blue -> dress,jeans,hat
Gold -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
Blue dress

result:
Blue clothes:
* dress - 1 (found!)
* jeans - 1
* hat - 1
* gloves - 1
Gold clothes:
* dress - 1
* t-shirt - 1
* boxers - 1
White clothes:
* briefs - 1
* tanktop - 1

4
Red -> hat
Red -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
White tanktop

result:
Red clothes:
* hat - 1
* dress - 1
* t-shirt - 1
* boxers - 1
White clothes:
* briefs - 1
* tanktop - 1 (found!)
Blue clothes:
* gloves - 1

5
Blue -> shoes
Blue -> shoes,shoes,shoes
Blue -> shoes,shoes
Blue -> shoes
Blue -> shoes,shoes
Red tanktop

result:
Blue clothes:
* shoes - 9

*/