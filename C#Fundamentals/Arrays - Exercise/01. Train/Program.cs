using System;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] train = new int[n];
            for (int i = 0; i < n; i++)
            {
                int people = int.Parse(Console.ReadLine());
                train[i] = people;
            }
            int totalPeople = 0;
            for (int i = 0; i < train.Length; i++)
            {
                totalPeople += train[i];
                Console.Write(train[i] + " ");

            }
            Console.WriteLine();
            Console.WriteLine(totalPeople);
        }
    }
}
