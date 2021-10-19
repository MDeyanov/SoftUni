using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double money = (headsetPrice * (lostGamesCount / 2)) +
                (mousePrice * (lostGamesCount / 3)) +
                (keyboardPrice * (lostGamesCount / 6)) +
                (displayPrice * (lostGamesCount / 12));
            Console.WriteLine($"Rage expenses: {money:f2} lv.");
        }
    }
}
