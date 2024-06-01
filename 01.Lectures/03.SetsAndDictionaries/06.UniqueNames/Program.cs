
int count = int.Parse(Console.ReadLine());
// HashSet добавя изважда много бързо елементи, не добавя единтични елементи
// за сортиран сет може да напишем така
// var set = new SortedSet<string>();
HashSet<string> list = new HashSet<string>();
for (int i = 0; i < count; i++)
{
    list.Add(Console.ReadLine());
}
Console.WriteLine(string.Join(Environment.NewLine, list));