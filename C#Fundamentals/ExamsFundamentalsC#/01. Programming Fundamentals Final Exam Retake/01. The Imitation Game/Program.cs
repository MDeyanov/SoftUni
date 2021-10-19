using System;
using System.Text;
namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            sb.Append(input);
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Decode")
                {
                    break;
                }
                string[] parts = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                if (command == "Move")
                {
                    int number = int.Parse(parts[1]);

                    string text = sb.ToString().Substring(0, number);
                    sb.Append(text);
                    sb.Remove(0, number);

                }
                else if (command == "Insert")
                {
                    int index = int.Parse(parts[1]);
                    string value = parts[2];
                    sb.Insert(index, value);
                }
                else if (command == "ChangeAll")
                {
                    string old = parts[1];
                    string newText = parts[2];
                    sb.Replace(old, newText);
                }
            }
            Console.WriteLine($"The decrypted message is: {sb}");
        }
    }
}
