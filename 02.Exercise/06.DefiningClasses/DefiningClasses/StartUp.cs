using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");

            // задача 2 тук използваме set часта на класа
            // Person person = new Person("Stosh", 28); // задаване на параметри като имаме конструктор

            // задача 1 без конструктор
            // Person person = new Person { Name = "Stosh", Age = 33 };
            // тук използваме get часта на класа
            // Console.WriteLine(person.Name);
            // Console.WriteLine(person.Age);
        }
    }
}
