using System;
using System.Linq;

namespace _04._Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            string answer = string.Join("", n.Reverse());

            Console.WriteLine(answer);
        }
    }
}
