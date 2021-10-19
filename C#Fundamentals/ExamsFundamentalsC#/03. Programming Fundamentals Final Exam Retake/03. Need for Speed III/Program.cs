using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] info = input.Split("|");
                string carname = info[0];
                int mileage = int.Parse(info[1]);
                int fuel = int.Parse(info[2]);
                if (!cars.ContainsKey(carname))
                {
                    cars.Add(carname, new List<int> { mileage, fuel });
                }
                else
                {
                    cars[carname][0] = mileage;
                    cars[carname][1] = fuel;
                }
            }

            string commands = Console.ReadLine();
            while (commands != "Stop")
            {
                string[] comandInfo = commands.Split(" : ");
                string doing = comandInfo[0];
                if (doing == "Drive")
                {
                    string car = comandInfo[1];
                    int distance = int.Parse(comandInfo[2]);
                    int fuel = int.Parse(comandInfo[3]);
                    if (cars[car][1] < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[car][0] += distance;
                        cars[car][1] -= fuel;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        if (cars[car][0] >= 100000)
                        {
                            cars.Remove(car);
                            Console.WriteLine($"Time to sell the {car}!");
                        }

                    }
                }
                else if (doing == "Refuel")
                {
                    string car = comandInfo[1];
                    int fuel = int.Parse(comandInfo[2]);
                    int fuelBefore = cars[car][1];
                    int fuelLeft = 0;
                    if (fuel + fuelBefore > 75)
                    {
                        fuelLeft = Math.Abs(fuelBefore - 75);
                        cars[car][1] = 75;
                    }
                    else
                    {
                        cars[car][1] += fuel;
                        fuelLeft = fuel;
                    }
                    Console.WriteLine($"{car} refueled with {fuelLeft} liters");
                }
                else if (doing == "Revert")
                {
                    string car = comandInfo[1];
                    int kilometers = int.Parse(comandInfo[2]);
                    if (Math.Abs(kilometers - cars[car][0]) < 10000)
                    {
                        cars[car][0] = 10000;
                    }
                    else
                    {
                        cars[car][0] -= kilometers;
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }



                commands = Console.ReadLine();
            }


            foreach (var car in cars.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }
    }
}
