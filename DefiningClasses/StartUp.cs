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
            Person person = new Person { Name = "Stosh", Age = 33 };

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
