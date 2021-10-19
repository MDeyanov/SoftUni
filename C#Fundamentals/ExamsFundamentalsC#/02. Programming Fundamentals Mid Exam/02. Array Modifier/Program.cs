using System;
using System.Linq;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                string[] commands = command.Split();
                string input = commands[0];
                if (input == "swap")
                {
                    int index1 = int.Parse(commands[1]);
                    int index2 = int.Parse(commands[2]);
                    int save = nums[index1];
                    nums[index1] = nums[index2];
                    nums[index2] = save;
                }
                else if (input == "multiply")
                {
                    int index1 = int.Parse(commands[1]);
                    int index2 = int.Parse(commands[2]);
                    nums[index1] *= nums[index2];
                }
                else if (input == "decrease")
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] -= 1;
                    }
                }
            }
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
