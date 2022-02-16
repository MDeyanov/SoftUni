using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Street_Racing
{
    public class Car
    {
        public string Make { get; private set; }
        public string Model { get; private set; }
        public string LicensePlate { get; private set; }
        public int HorsePower { get; private set; }
        public double Weight { get; private  set; }

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            Make = make;
            Model = model;
            LicensePlate = licensePlate;
            HorsePower = horsePower;
            Weight = weight;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Make: {Make}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"License Plate: {LicensePlate}");
            sb.AppendLine($"Horse Power: {HorsePower}");
            sb.AppendLine($"Weight: {Weight}");
            return sb.ToString().TrimEnd();
        }
    }
}
