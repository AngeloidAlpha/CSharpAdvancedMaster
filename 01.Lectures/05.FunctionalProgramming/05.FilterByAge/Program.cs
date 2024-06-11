using System.Collections.Generic;
using System;

// създаваме
List<Person> people = ReadPeople();
//1
string condition = Console.ReadLine();
int ageTreshold = int.Parse(Console.ReadLine());
//1
Func<Person, bool> filter = CreateFilter(condition, ageTreshold);
//2
string format = Console.ReadLine();
//2
Action<Person> printer = CreatePrinter(format);
//3
PrintFilteredPeople(people, filter, printer);

List<Person> ReadPeople() //1
{
    List<Person> people = new List<Person>();

    int count = int.Parse(Console.ReadLine());
    
    for (int i = 0; i < count; i++)
    {
        string[] personTokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
        Person person = new Person();
        person.Name = personTokens[0];
        person.Age = int.Parse(personTokens[1]);
        people.Add(person);
    }
    return people;
}
Func<Person, bool> CreateFilter(string condition, int ageTreshold) //2
{
    switch (condition)
    {
        case "younger": return people => people.Age < ageTreshold;
        // как изглежда това    return Person(people) => { return person.Age < ageTreshold; };
        case "older": return people => people.Age >= ageTreshold;
        // задължително трябва да върна нещо ако не получа някоя от 2те думи ( за това имаме default: return null;)
        default:
            return null;
    } 
}
//2.5 това ни трябва за да направим стъпка 3
Action<Person> CreatePrinter(string format) //Action не връща стойност а извършва някакво действие
{
    switch (format)
    {
        case "name age": return people => Console.WriteLine($"{people.Name} - {people.Age}");
        case "name": return people => Console.WriteLine(people.Name);
        case "age": return people => Console.WriteLine(people.Age);
        default: return null;
    }
}
void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer) //3
{
    foreach (Person person in people)
    {
         if(filter(person))
        {
            printer(person);
        }
    }
}
public class Person // създаване
{
    public string Name { get; set; } 
    public int Age { get; set; }
}
/*
5
Lucas, 20
Tomas, 18
Mia, 29
Noah, 31
Simo, 16
older
20
name age

result:
Lucas - 20
Mia - 29
Noah - 31

5
Lucas, 20
Tomas, 18
Mia, 29
Noah, 31
Simo, 16
younger
20
name

result:
Tomas
Simo
 
5
Lucas, 20
Tomas, 18
Mia, 29
Noah, 31
Simo, 16
younger
50

result:
20
18
29
31
16
*/
