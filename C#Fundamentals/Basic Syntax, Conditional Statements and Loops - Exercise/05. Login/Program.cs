using System;
using System.Linq;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string password = string.Join("", username.Reverse());
            for (int i = 0; i < 4; i++)
            {
                string pass = Console.ReadLine();
                if (pass == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    return;
                }
                if (i == 3)
                {
                    Console.WriteLine($"User { username} blocked!");
                    break;
                }
                if (pass != password)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}
