using System;
using System.Linq;

namespace FunctionalPrograming
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadStudents(PrintStudentSoftUni);// silata na tova func e 4e tuka moje da slagame vseki edin ot metodite i da go polzvame dinamichno
            // ako primerno e console.readLine moga da si reshvam koi metod da se polzva
        }
        static void ReadStudents(Func<string,int,string> printer)
        {
            int age = 0;
            do
            {
                Console.WriteLine("Student name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Student age: ");
                age = int.Parse(Console.ReadLine());
                Console.WriteLine(printer(name,age));

            } while (age != -1);

         }
        static string PrintStudentDvoikajiq(string name, int age)
        {
            return $"2";
        }
        static string PrintStudentBulgarian(string name, int age)
        {
            return $"Bulgarian student is {age} and named {name}";
        }
        static string PrintStudentSoftUni(string name, int age)
        {
            return $"SoftUni student is {age} and named {name}";
        }
    }
}
