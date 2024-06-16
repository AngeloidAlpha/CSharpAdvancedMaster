using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Demo
{
    // класовете вианги са public
    // 1во са полетата
    // 2ро конструктура той задава default state на класа
    // напиши ctor и Enter
    // 3то пропъртита
    // 4то методи
    internal class Person
    {
        // sharplab.io
        // полетата винаги трябва да са private
        // те не трябва да бъдат достъпвани от външния свят
        // те се създават със default стойности (string == null) (int == 0) и т.нат
        private string name;
        private int age;
        private int weight;
        // конструктори
        public Person()
        {
            this.Name = "Default Name";
            this.Age = 18;
            this.Weight = 70;
        }
        public Person(int age)
            : this()
        {
            this.Age = age;
        }
        public Person (string name, int age, int weight) : this(age)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Age 
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }
        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }

    }
}
