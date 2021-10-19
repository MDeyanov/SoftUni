using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> registration = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split();

                string command = parts[0];

                if (command == "register")
                {
                    string username = parts[1];
                    string platesNumber = parts[2];

                    if (registration.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {platesNumber}");
                    }
                    else
                    {
                        registration.Add(username, platesNumber);
                        Console.WriteLine($"{username} registered {platesNumber} successfully");
                    }
                }
                else if (command == "unregister")
                {
                    string user = parts[1];

                    bool removed = registration.Remove(user);

                    if (removed)
                    {
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                }
            }
            foreach (var users in registration)
            {
                Console.WriteLine($"{users.Key} => {users.Value}");
            }
        }
    }
}
