using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
            int sum = 0;
            while (heroes.Count<n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                if (type == nameof(Druid))
                {
                    heroes.Add(new Druid(name));

                    sum += 80;
                }
                else if (type == nameof(Paladin))
                {
                    heroes.Add(new Paladin(name));
                    sum += 100;
                }
                else if (type == nameof(Rogue))
                {
                    heroes.Add(new Rogue(name));
                    sum += 80;
                }
                else if (type == nameof(Warrior))
                {
                    heroes.Add(new Warrior(name));
                    sum += 100;
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            int boss = int.Parse(Console.ReadLine());
            if (sum>=boss)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
