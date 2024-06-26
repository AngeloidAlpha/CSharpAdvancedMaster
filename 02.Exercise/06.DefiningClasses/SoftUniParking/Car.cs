﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make,
            string model,
            int horsePower,
            string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            //Better readibilty -> StringBuilder
            return $"Make: {this.Make}{Environment.NewLine}Model: {this.Model}{Environment.NewLine}HorsePower: {this.HorsePower}{Environment.NewLine}RegistrationNumber: {this.RegistrationNumber}";

            ;
        }
    }
}
