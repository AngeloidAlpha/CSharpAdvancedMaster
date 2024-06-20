using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDataBank
{
    public class Car
    {
        public Car(string model, Cargo cargo, Engine engine, Tire[] tires)
        {
            Model = model;
            Cargo = cargo;
            Engine = engine;
            Tires = tires;
        }

        public string Model { get; set; }
        public Cargo Cargo { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

    }
}
