using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    public class SkiRental
    {
        private readonly List<Ski> data;

        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public int Count => data.Count;

        public SkiRental(string name, int capacity)
        {
            data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public void Add(Ski ski)
        {
            if (Capacity > data.Count)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer,string model)
        {
            return data.Remove(data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model));
        }

        public Ski GetNewestSki()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in data)
            {
                sb.AppendLine($"{ski.Manufacturer} - {ski.Model} - {ski.Year}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
