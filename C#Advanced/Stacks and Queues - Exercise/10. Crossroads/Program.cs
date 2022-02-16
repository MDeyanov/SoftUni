using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int secondsToPass = int.Parse(Console.ReadLine());
            Queue<string> carQueue = new Queue<string>();

            int totalCarPassed = 0;

            while (true)
            {
                string command = Console.ReadLine();

                int greenLight = greenLightSeconds;
                int passSeconds = secondsToPass;

                if (command == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{totalCarPassed} total cars passed the crossroads.");
                    return;
                }

                if (command == "green")
                {
                    while (greenLight > 0 && carQueue.Count != 0)
                    {
                        string firstCar = carQueue.Dequeue();
                        greenLight -= firstCar.Length;
                        if (greenLight > 0)
                        {
                            totalCarPassed++;
                        }
                        else
                        {
                            passSeconds += greenLight;
                            if (passSeconds < 0)
                            {

                                Console.WriteLine($"A crash happened!{Environment.NewLine}" +
                                $"{firstCar} was hit at {firstCar[firstCar.Length + passSeconds]}.");
                                return;
                            }
                            totalCarPassed++;
                        }
                    }
                }
                else
                {
                    carQueue.Enqueue(command);
                }
            }
        }
    }
}
