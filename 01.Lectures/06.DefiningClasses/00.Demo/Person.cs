using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Demo
{
    // класовете вианги са public
    internal class Person
    {
        // sharplab.io
        // полетата винаги трябва да са private
        // те не трябва да бъдат достъпвани от външния свят
        // те се създават със default стойности (string == null) (int == 0) и т.нат
        private string name;
        private int age;
        // полетата могат да бъдат всякакъв тип
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

    }
}
