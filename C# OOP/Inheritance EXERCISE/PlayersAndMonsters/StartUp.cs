namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var hero = new BladeKnight("Gosho", 999);

            System.Console.WriteLine(hero);
        }
    }
}