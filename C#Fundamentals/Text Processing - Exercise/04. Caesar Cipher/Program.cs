using System;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] ex = input.ToCharArray();
            for (int i = 0; i < ex.Length; i++)
            {
                ex[i] = Convert.ToChar(ex[i] + 3);
            }
            input = new string(ex);
            Console.WriteLine(input);
        }
    }
}
