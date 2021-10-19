using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split();
            string[] secArray = Console.ReadLine().Split();


            for (int i = 0; i < secArray.Length; i++)
            {
                string currentElements = secArray[i];
                for (int j = 0; j < firstArray.Length; j++)
                {
                    if (currentElements == firstArray[j])
                    {
                        Console.Write(currentElements + " ");
                    }

                }
            }
        }
    }
}
