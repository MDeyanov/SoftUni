using System;

namespace _01._Guinea_Pig
{
    class Program
    {
        static void Main(string[] args)
        {
            double foodKg = double.Parse(Console.ReadLine());
            double hayKg = double.Parse(Console.ReadLine());
            double coverKg = double.Parse(Console.ReadLine());
            double weightKg = double.Parse(Console.ReadLine());

            double gramsFood = foodKg * 1000;
            double hayGrams = hayKg * 1000;
            double coverGrams = coverKg * 1000;
            double weightGrams = weightKg * 1000;
            int days = 1;

            while (days <=30)
            {
                gramsFood -= 300;
                if (days % 2 == 0)
                {
                    hayGrams -= (gramsFood * 5) / 100;
                }
                if (days % 3 == 0)
                {
                    coverGrams -= weightGrams * 0.3333;
                }
                days++;

            }
            var kgFood = gramsFood / 1000;
            var kgHay = hayGrams / 1000;
            var kgCover = coverGrams / 1000;

            if (kgFood >= 0 && kgHay >= 0 && kgCover >= 0)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {kgFood:f2}, Hay: {kgHay:f2}, Cover: {kgCover:f2}.");
            }
            else if (kgFood < 0 || kgHay < 0 || kgCover < 0)
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
        }
    }
}
