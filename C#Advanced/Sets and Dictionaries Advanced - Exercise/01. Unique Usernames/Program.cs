using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> userNames = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                userNames.Add(Console.ReadLine());
            }

            foreach (var user in userNames)
            {
                Console.WriteLine(user);
            }
        }
    }
}
