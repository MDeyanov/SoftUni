using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm.Birds
{
    public class Hen : Bird
    {
        private const double HenWeightModofier = 0.35;

        private static HashSet<string> henAllowedFoods = new HashSet<string>
        {
            nameof(Fruit),
            nameof(Meat),
            nameof(Seeds),
            nameof(Vegetable)
        };
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, henAllowedFoods, HenWeightModofier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
