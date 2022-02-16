using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputIngredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputFreshness = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> ingredients = new Queue<int>(inputIngredients);
            Stack<int> freshness = new Stack<int>(inputFreshness);
            Dictionary<string, int> dishes = new Dictionary<string, int>();
            dishes.Add("Dipping sauce", 0);
            dishes.Add("Green salad", 0);
            dishes.Add("Chocolate cake", 0);
            dishes.Add("Lobster", 0);
            while (true)
            {
                if (ingredients.Count == 0 || freshness.Count == 0)
                {
                    break;
                }
                if (ingredients.Peek()==0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                if (ingredients.Peek() *  freshness.Peek() == 150)
                {
                    dishes["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (ingredients.Peek() * freshness.Peek() == 250)
                {
                    dishes["Green salad"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (ingredients.Peek() * freshness.Peek() == 300)
                {
                    dishes["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (ingredients.Peek() * freshness.Peek() == 400)
                {
                    dishes["Lobster"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    int plusFive = ingredients.Dequeue() + 5;
                    ingredients.Enqueue(plusFive);
                    freshness.Pop();
                }
            }
            if (dishes["Dipping sauce"] > 0 && dishes["Green salad"] > 0 && dishes["Chocolate cake"] > 0 && dishes["Lobster"] > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!"); 
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            foreach (var dish in dishes.OrderBy(x => x.Key))
            {
                if (dish.Value>0)
                {
                    Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                }                
            }
        }
    }
}
