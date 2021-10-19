using System;
using System.Linq;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int Health = 100;
            int bitCoints = 0;
            string[] dungeonRooms = Console.ReadLine().Split('|').ToArray();

            for (int i = 0; i < dungeonRooms.Length; i++)
            {
                string[] command = dungeonRooms[i].Split();

                if (command[0] == "potion")
                {
                    int heal = int.Parse(command[1]);
                    if (Health == 100)
                    {
                        continue;
                    }
                    else if (Health < 100)
                    {
                        int currentHealth = Health;
                        Health += heal;
                        if (Health > 100)
                        {
                            Health = 100;
                            heal = Math.Abs(currentHealth - 100);
                        }
                        Console.WriteLine($"You healed for {heal} hp.");
                        Console.WriteLine($"Current health: {Health} hp.");
                    }
                }
                else if (command[0] == "chest")
                {
                    int amountBit = int.Parse(command[1]);
                    bitCoints += amountBit;
                    Console.WriteLine($"You found {amountBit} bitcoins.");
                }
                else
                {
                    int dmg = int.Parse(command[1]);

                    Health -= dmg;
                    if (Health > 0)
                    {
                        Console.WriteLine($"You slayed {command[0]}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command[0]}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                }
            }
            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitCoints}");
            Console.WriteLine($"Health: {Health}");
        }
    }
}
