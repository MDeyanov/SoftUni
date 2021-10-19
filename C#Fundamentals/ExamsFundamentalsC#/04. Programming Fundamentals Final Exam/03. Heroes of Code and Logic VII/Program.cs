using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                string name = line[0];
                int hp = int.Parse(line[1]);
                int mp = int.Parse(line[2]);
                heroes.Add(name, new List<int>());
                heroes[name].Add(hp);
                heroes[name].Add(mp);
            }
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                string[] parts = line.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                if (command == "CastSpell")
                {
                    string heroName = parts[1];

                    int manaNeeded = int.Parse(parts[2]);
                    string spellName = parts[3];
                    if (manaNeeded <= heroes[heroName][1])
                    {
                        heroes[heroName][1] -= manaNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }

                }
                else if (command == "TakeDamage")
                {
                    string heroName = parts[1];

                    int damage = int.Parse(parts[2]);
                    string attacker = parts[3];
                    if (heroes[heroName][0] - damage <= 0)
                    {
                        heroes.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                    else
                    {
                        heroes[heroName][0] -= damage;
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName][0]} HP left!");
                    }

                }
                else if (command == "Recharge")
                {
                    string heroName = parts[1];

                    int amount = int.Parse(parts[2]);
                    if (heroes[heroName][1] + amount > 200)
                    {
                        int oldAmount = heroes[heroName][1] - 200;
                        heroes[heroName][1] = 200;
                        Console.WriteLine($"{heroName} recharged for {Math.Abs(oldAmount)} MP!");
                    }
                    else
                    {
                        heroes[heroName][1] += amount;
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }

                }
                else if (command == "Heal")
                {
                    string heroName = parts[1];

                    int amount = int.Parse(parts[2]);
                    if (heroes[heroName][0] + amount > 100)
                    {
                        int left = heroes[heroName][0] - 100;
                        heroes[heroName][0] = 100;
                        Console.WriteLine($"{heroName} healed for {Math.Abs(left)} HP!");
                    }
                    else
                    {
                        heroes[heroName][0] += amount;
                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }

                }
            }
            Dictionary<string, List<int>> sorted = heroes.OrderByDescending(h => h.Value[0]).ThenBy(h => h.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var hero in sorted)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value[0]}");
                Console.WriteLine($"  MP: {hero.Value[1]}");
            }
        }
    }
}
