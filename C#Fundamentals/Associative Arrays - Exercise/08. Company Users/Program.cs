using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> companies = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                string[] parts = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string company = parts[0];
                string employeeId = parts[1];

                if (!companies.ContainsKey(company))
                {
                    companies.Add(company, new List<string>());
                }

                companies[company].Add(employeeId);
            }
            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);

                List<string> uniqueEmployees = company.Value
                     .Distinct()
                     .ToList();

                foreach (var employee in uniqueEmployees)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
