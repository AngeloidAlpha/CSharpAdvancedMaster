using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;
        
        // генериране на конструктор
        // ctor tab tab (празен) или селектирай пропъртитата и ctrl + .
        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }
        public Person (int age) : this()
        {
            this.Name = "No name";
            this.Age = age;
        }
        public Person(string name, int age) : this(age)
        {
            this.Name = name;
        }
        // като вземаме стойност минаваме стъпка get
        // като записваме стойност използваме часта set
        public string Name { get { return name; } set { name = value; } } 
        public int Age { get { return age; } set { age = value; } }
    }
}
