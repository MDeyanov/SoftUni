using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Birthday_Celebration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] eatingCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] platesCap = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int wastedFood = 0;
            bool isGuests = false;
            bool isPlates = false;
            Queue<int> guests = new Queue<int>(eatingCapacity);
            Stack<int> plates = new Stack<int>(platesCap);

            while (true)
            {
                if (guests.Count == 0)
                {
                    isGuests = true;
                    break;
                }
                if (plates.Count == 0)
                {
                    isPlates = true;
                    break;
                }
                int guest = guests.Peek();
                int plate = plates.Peek();

                if (guest == plate)
                {
                    guests.Dequeue();
                    plates.Pop();
                }
                else if (guest > plate)
                {
                    guest -= plate;
                    plates.Pop();
                    while (guest > 0)
                    {
                        if (plates.Count==0)
                        {
                            break;
                        }
                        int newPlate = plates.Peek();
                        if (newPlate > guest)
                        {
                            wastedFood += newPlate - guest;
                            plates.Pop();
                            guests.Dequeue();
                            break;
                        }
                        guest -= plates.Pop();
                        if (guest==0)
                        {
                            guests.Dequeue();
                        }
                    }
                }
                else if (plate > guest)
                {
                    wastedFood += plate - guest;
                    plates.Pop();
                    guests.Dequeue();
                }
            }
            if (isGuests)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else if (isPlates)
            {
                Console.WriteLine($"Guests: {string.Join(" ",guests)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
