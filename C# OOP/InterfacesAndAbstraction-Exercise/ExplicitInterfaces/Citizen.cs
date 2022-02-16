using System;

namespace ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name,string country,int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        void IPerson.GetName()
        {
            Console.WriteLine($"{this.Name}");
        }
        void IResident.GetName()
        {
            Console.WriteLine($"Mr/Ms/Mrs {this.Name}");
        }
    }
}
