using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    internal class Family
    {
        // конструктора е важен за класа (все едно е storage-a на класа)
        public Family()
        {
            this.People = new List<Person>();
        }
        public List<Person> People { get; set; }
        public void AddMember(Person person)
        {
            this.People.Add(person);
        }

        public Person GetOldestMember()
        {
            return this.People
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();
        }
    }
}
