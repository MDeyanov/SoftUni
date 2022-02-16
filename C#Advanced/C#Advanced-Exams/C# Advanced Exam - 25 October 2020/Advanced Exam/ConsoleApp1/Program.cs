using System;
using System.Linq;
using System.Collections.Generic;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputTasks = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputThreads = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int taskToBeKilled = int.Parse(Console.ReadLine());
            int threadThatKilledTask = 0;

            Stack<int> Tasks = new Stack<int>(inputTasks);
            Queue<int> Threads = new Queue<int>(inputThreads);
            bool isKilled = false;

            while (isKilled == false)
            {
                int firstTask = Tasks.Peek();
                int firstThread = Threads.Peek();
                if (firstTask == taskToBeKilled)
                {
                    isKilled = true;
                    threadThatKilledTask = firstThread;
                    continue;
                }
                if (firstThread >= firstTask)
                {
                    Tasks.Pop();
                    Threads.Dequeue();
                }
                else
                {
                    Threads.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {threadThatKilledTask} killed task {taskToBeKilled}");

            Console.WriteLine(string.Join(' ', Threads));

        }
    }
}