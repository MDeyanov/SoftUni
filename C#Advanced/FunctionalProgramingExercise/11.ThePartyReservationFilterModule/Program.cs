using System;
using System.Linq;
using System.Collections.Generic;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {

            var guests = new List<string>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            List<string> filters = new List<string>();
            string input = Console.ReadLine();

            while (input != "Print")
            {
                var commands = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Add filter")
                {
                    filters.Add(commands[1] + " " + commands[2]);
                }
                else if (commands[0]=="Remove filter")
                {
                    filters.Remove(commands[1] + " " + commands[2]);
                }
                input = Console.ReadLine();
            }
            foreach (var filter in filters)
            {
                var comands = filter.Split(' ');
                if (comands[0] == "Starts")
                {
                    guests = guests.Where(p => !p.StartsWith(comands[2])).ToList(); 
                }
                else if (comands[0]=="Ends")
                {
                    guests = guests.Where(p => !p.EndsWith(comands[2])).ToList();
                }
                else if (comands[0]=="Lenght")
                {
                    guests = guests.Where(p => p.Length != int.Parse(comands[1])).ToList();
                }
                else if (comands[0]=="Contains")
                {
                    guests = guests.Where(p => !p.Contains(comands[1])).ToList();
                }
            }
            if (guests.Any())
            {
                Console.WriteLine(string.Join(" ", guests));
            }

        }
    }
}
