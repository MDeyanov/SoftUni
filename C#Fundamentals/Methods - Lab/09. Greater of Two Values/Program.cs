using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secValue = Console.ReadLine();

            if (type == "int")
            {
                int firstInt = int.Parse(firstValue);
                int secInt = int.Parse(secValue);
                Console.WriteLine(GetMax(firstInt, secInt));
            }
            else if (type == "char")
            {
                char firstChar = char.Parse(firstValue);
                char secChar = char.Parse(secValue);
                Console.WriteLine(GetMax(firstChar, secChar));
            }
            else if (type == "string")
            {
                string result = GetMax(firstValue, secValue);
                Console.WriteLine(result);
            }
        }
        static int GetMax(int firstInt, int secInt)
        {
            if (firstInt > secInt)
            {
                return firstInt;
            }
            return secInt;
        }
        static char GetMax(char firstChar, char secChar)
        {
            if (firstChar > secChar)
            {
                return firstChar;
            }
            return secChar;
        }
        static string GetMax(string firstValue, string secValue)
        {

            int result = firstValue.CompareTo(secValue);

            if (result > 0)
            {
                return firstValue;
            }
            return secValue;

        }
    }
}
