using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightSaberPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            double totalSum = lightSaberPrice * Math.Ceiling(studentsCount * 1.1) +
                robesPrice * studentsCount + beltsPrice * (studentsCount - (studentsCount / 6));

            if (amountOfMoney >= totalSum)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalSum - amountOfMoney:f2}lv more.");
            }
        }
    }
}
