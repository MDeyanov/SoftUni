using System;

namespace TupleProblem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();
            var fullName = $"{personInfo[0]} {personInfo[1]}";
            var street = $"{personInfo[2]}";
            string city = string.Empty;
            if (personInfo.Length>4)
            {
                city = $"{personInfo[3]} {personInfo[4]}";
            }
            else
            {
                city = $"{personInfo[3]}";

            }

            var nameAndBeer = Console.ReadLine().Split();
            var name = nameAndBeer[0];
            var numberOfLitters = int.Parse(nameAndBeer[1]);
            bool isDrunk = false;
            if (nameAndBeer[2] == "drunk")
            {
                isDrunk = true;
            }

            var numbersInput = Console.ReadLine().Split();
            var oneName = numbersInput[0];
            var doubleNum = double.Parse(numbersInput[1]);
            var bank = numbersInput[2];

            Tuple<string, string,string> firstTuple = new Tuple<string, string,string>(fullName,street,city);
            Tuple<string, int,bool> secondTuple = new Tuple<string, int,bool>(name,numberOfLitters,isDrunk);
            Tuple<string, double, string> thirdTuple = new Tuple<string, double,string>(oneName,doubleNum,bank);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
