using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isValid = true;
            if (!InRange(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }
            if (ContainInvalidCharacter(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }
            if (!ContainDigits(password, 2))
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }
            if (isValid)
            {
                Console.WriteLine("Password is valid");

            }
        }
        private static bool ContainDigits(string password, int v1)
        {
            int digitsCount = 0;
            foreach (var symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    digitsCount += 1;
                }
                if (digitsCount == v1)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool ContainInvalidCharacter(string password)
        {
            foreach (var symbol in password)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool InRange(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }
    }
}
