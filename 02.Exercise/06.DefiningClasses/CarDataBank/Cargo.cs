using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDataBank
{
    public class Cargo
    {
        public Cargo(string type, int weght)
        {
            Type = type;
            Weght = weght;
        }

        public string Type { get; set; }
        public int Weght { get; set; }
    }
}
