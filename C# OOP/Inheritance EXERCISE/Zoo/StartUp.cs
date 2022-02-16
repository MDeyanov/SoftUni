using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animal = new Snake("Pesho");
            Console.WriteLine(animal.Name);
        }
    }
}