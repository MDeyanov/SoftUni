using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal balance = decimal.Parse(Console.ReadLine());
            decimal spending = 0;
            decimal firstBalance = balance;
            string game = "";
            while (game != "Game Time")
            {
                game = Console.ReadLine();
                decimal gamePrice = 0;
                if (game == "OutFall 4")
                {
                    gamePrice = 39.99m;
                    if (balance < gamePrice)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    balance -= 39.99m;
                    spending += 39.99m;
                    Console.WriteLine($"Bought {game}");
                }
                else if (game == "CS: OG")
                {
                    gamePrice = 15.99m;
                    if (balance < gamePrice)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    balance -= 15.99m;
                    spending += 15.99m;
                    Console.WriteLine($"Bought {game}");
                }
                else if (game == "Zplinter Zell")
                {
                    gamePrice = 19.99m;
                    if (balance < gamePrice)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    balance -= 19.99m;
                    spending += 19.99m;
                    Console.WriteLine($"Bought {game}");
                }
                else if (game == "Honored 2")
                {
                    gamePrice = 59.99m;
                    if (balance < gamePrice)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    balance -= 59.99m;
                    spending += 59.99m;
                    Console.WriteLine($"Bought {game}");
                }
                else if (game == "RoverWatch")
                {
                    gamePrice = 29.99m;
                    if (balance < gamePrice)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    balance -= 29.99m;
                    spending += 29.99m;
                    Console.WriteLine($"Bought {game}");
                }
                else if (game == "RoverWatch Origins Edition")
                {
                    gamePrice = 39.99m;
                    if (balance < gamePrice)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    balance -= 39.99m;
                    spending += 39.99m;
                    Console.WriteLine($"Bought {game}");
                }
                else
                {
                    if (game != "Game Time")
                    {
                        Console.WriteLine("Not Found");
                    }
                }

                if (balance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
            }
            if (balance > 0)
            {
                Console.WriteLine($"Total spent: ${spending}. Remaining: ${balance}");
            }
        }
    }
}
