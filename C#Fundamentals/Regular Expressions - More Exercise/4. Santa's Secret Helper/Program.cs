using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace _4._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"@([A-Za-z]+)[^@\-!:>]*!([GN])!");
            List<string> goodKids = new List<string>();
            while (true)
            {
                string line = Console.ReadLine();
                string kidsRegex = string.Empty;
                StringBuilder sb = new StringBuilder();
                if (line == "end")
                {
                    break;
                }
                for (int i = 0; i < line.Length; i++)
                {
                    int c = Convert.ToInt32(line[i]);
                    char newChar = Convert.ToChar(c - n);
                    sb.Append(newChar);


                }

                MatchCollection matches = regex.Matches(sb.ToString());
                foreach (Match match in matches)
                {
                    string good = match.Groups[2].Value;
                    if (good == "G")
                    {
                        goodKids.Add(match.Groups[1].Value);
                    }
                    else
                    {
                        continue;
                    }
                }

            }
            Console.WriteLine(string.Join("\n", goodKids));
        }
    }
}
