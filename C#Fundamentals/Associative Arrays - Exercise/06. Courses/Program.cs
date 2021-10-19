using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> studentsByCourse = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                string[] parts = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string course = parts[0];
                string students = parts[1];

                if (!studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse.Add(course, new List<string>());
                }

                studentsByCourse[course].Add(students); 
                 
            }
            Dictionary<string, List<string>> sortedCourses = studentsByCourse
                .OrderByDescending(c => c.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedCourses)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                kvp.Value.Sort();
                foreach (var student in kvp.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
