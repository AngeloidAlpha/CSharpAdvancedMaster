// вземаме размера на редовете
// въртим цикъл за броя редове
// напълваме масив с отделните елементи
// като го имаме масива още тогава го попълваме в сортиран HashSet -> SortedSet
// принтираме сортираните ни уникални елементи

int n = int.Parse(Console.ReadLine());

SortedSet<string> elements = new SortedSet<string>();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split();

    foreach (string el in input)
    {
        elements.Add(el);
    }
}

Console.WriteLine(string.Join(" ", elements));

/*

4
Ce O
Mo O Ce
Ee
Mo

result:
Ce Ee Mo O

3
Ge Ch O Ne
Nb Mo Tc
O Ne

result:
Ch Ge Mo Nb Ne O Tc

*/