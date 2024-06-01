int numberOfNames = int.Parse(Console.ReadLine());

// HashSet за уникални имена е най-лесно

HashSet<string> names = new HashSet<string>();

for (int i = 0; i < numberOfNames; i++)
{
    string name = Console.ReadLine();
    names.Add(name);
}

Console.WriteLine(string.Join(Environment.NewLine, names));
/*
6
John
John
John
Peter
John
Boy1234

result:
John
Peter
Boy1234

10
Peter
Maria
Peter
George
Sam
Maria
Sara
Peter
Sam
George

result:
Peter
Maria
George
Sam
Sara

*/