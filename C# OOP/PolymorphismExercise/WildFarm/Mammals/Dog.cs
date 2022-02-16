using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm.Mammals
{
    public class Dog : Mammal
    {
        private const double DogWeightModifier = 0.40;
        private static HashSet<string> DogAllowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, DogAllowedFoods, DogWeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
