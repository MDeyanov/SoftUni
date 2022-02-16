using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _03._Street_Racing
{
    public class Race
    {
        private readonly List<Car> Participants;
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Laps { get; private set; }
        public int Capacity { get; private set; }
        public int MaxHorsePower { get; private set; }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Participants = new List<Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public int Count => Participants.Count;

        public void Add(Car Car)
        {
            bool existingPlate = !Participants.Exists(x => x.LicensePlate == Car.LicensePlate);
            bool horsePowerLimit = this.MaxHorsePower >= Car.HorsePower;
            bool haveSpot = Count < this.Capacity;
            if (existingPlate && haveSpot && horsePowerLimit)
            {
                Participants.Add(Car);
            }

        }

        public bool Remove(string licensePlate)
        {
           return Participants.Remove(Participants.FirstOrDefault(x => x.LicensePlate == licensePlate));
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.Find(x => x.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants)
            {
                sb.AppendLine($"Make: {car.Make}");
                sb.AppendLine($"Model: {car.Model}");
                sb.AppendLine($"License Plate: {car.LicensePlate}");
                sb.AppendLine($"Horse Power: {car.HorsePower}");
                sb.AppendLine($"Weight: {car.Weight}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
