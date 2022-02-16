using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassroomProject
{
    public class Classroom
    {
        private readonly List<Student> students;

        public int Capacity { get; private set; }

        public int Count => students.Count;

        public Classroom(int capacity)
        {
            students = new List<Student>();
            Capacity = capacity;
        }

         

        public string RegisterStudent(Student student)
        {
            if (Capacity > Count)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return $"No seats in the classroom";
            }
             
        }
        public string DismissStudent(string firstName, string lastName)
        {
            if (students.Any(x => x.FirstName == firstName && x.LastName == lastName))
            {
                Student toRemove = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
                students.Remove(toRemove);
                return  $"Dismissed student {toRemove.FirstName} {toRemove.LastName}";
            }
            else
            {
                return $"Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            int counter = 0;
            foreach (Student student in students)
            {
                if (student.Subject == subject)
                {
                    counter++;
                    break;
                }
            }

            if (counter > 0)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var student in students.Where(x => x.Subject == subject))
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
            else
            {
                return "No students enrolled for the subject";
            }
            
        }
        public string GetStudentsCount()
        {
            return $"{students.Count}";
        }
        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return student;
        }
    }
}
