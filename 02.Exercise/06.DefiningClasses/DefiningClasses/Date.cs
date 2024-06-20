using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Date
    {
        static void Main(string[] args)
        {
            string fistDateString = Console.ReadLine();
            string secondDateString = Console.ReadLine();

            DateTime firstDate = DateTime.Parse(fistDateString);
            DateTime secondDate = DateTime.Parse(secondDateString);

            int dayDifference = DateModifier.CalculateDiffInDays(firstDate, secondDate);
            Console.WriteLine(dayDifference);
        }
    }
}
