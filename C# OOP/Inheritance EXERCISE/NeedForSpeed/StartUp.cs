namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new SportCar(500, 1000);
            car.Drive(12.5);
            System.Console.WriteLine(car.Fuel);
        }
    }
}
