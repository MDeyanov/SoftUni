using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var coffie = new Coffee("Costa", 250);

            Console.WriteLine(coffie.Price);
        }
    }
}