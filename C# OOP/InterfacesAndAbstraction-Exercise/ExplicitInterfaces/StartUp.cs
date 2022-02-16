using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line=="End")
                {
                    break;
                }

                string[] parts = line.Split();

                var name = parts[0];
                var country = parts[1];
                var age = int.Parse(parts[2]);

                citizens.Add(new Citizen(name,country,age));
            }

            foreach (var citizen in citizens)
            {
                (citizen as IPerson).GetName();
                (citizen as IResident).GetName();
            }
             
        }
    }
}
