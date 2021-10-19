using System;

namespace _11._Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double dul = double.Parse(Console.ReadLine());
            double sh = double.Parse(Console.ReadLine());
            double v = double.Parse(Console.ReadLine());
            double c = (dul * sh * v) / 3;

            Console.WriteLine($"Length: Width: Height: Pyramid Volume: {c:f2}");
        }
    }
}
