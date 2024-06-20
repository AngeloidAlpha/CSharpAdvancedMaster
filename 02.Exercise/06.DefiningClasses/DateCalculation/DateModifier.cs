using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCalculation
{
    public static class DateModifier
    {
        public static int CalculateDiffInDays(DateTime date, DateTime endDate)
        {
            // return (date - endDate).Days;
            TimeSpan result = date - endDate;
            return Math.Abs(result.Days);
        }
    }
}
