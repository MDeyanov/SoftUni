using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double CatWeightModifier = 0.30;
        private static HashSet<string> CatAllowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Meat)
        };
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, CatAllowedFoods, CatWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
