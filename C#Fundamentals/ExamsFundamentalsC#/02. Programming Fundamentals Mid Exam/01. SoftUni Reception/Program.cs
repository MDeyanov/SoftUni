using System;

namespace _01._SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int sec = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            double students = double.Parse(Console.ReadLine());
            int counter = 0;

            double totalPerHour = first + sec + third;
            while (students > 0)
            {


                counter++;

                if (counter % 4 == 0)
                {
                    counter++;

                }
                students -= totalPerHour;
            }
            Console.WriteLine($"Time needed: {counter}h.");
        }
    }
}
