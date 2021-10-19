using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int lenght = key.Length;
            string input = String.Empty;
            while ((input = Console.ReadLine()) != "find")
            {
                int counter = 0;
                char[] letters = input.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (counter < lenght - 1)
                    {
                        int value = key[counter];
                        letters[i] = Convert.ToChar(letters[i] - value);
                        counter++;
                    }
                    else
                    {

                        int value = key[counter];
                        counter = 0;
                        letters[i] = Convert.ToChar(letters[i] - value);

                    }

                }
                string result = new string(letters);
                StringBuilder material = new StringBuilder();
                List<int> materialIdx = new List<int>();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i] == '&')
                    {
                        materialIdx.Add(i + 1);
                    }
                }

                int startMaterial = materialIdx[0];
                int lenghtMaterial = materialIdx[1] - materialIdx[0] - 1;
                string materialType = result.Substring(startMaterial, lenghtMaterial);
                if (result.Contains('<') && result.Contains('>'))
                {
                    int start = result.IndexOf('<') + 1;
                    int end = result.IndexOf('>');
                    int endx = end - start;
                    string output = result.Substring(start, endx);
                    Console.WriteLine($"Found {materialType} at {output}");

                }
            }
        }
    }
}
