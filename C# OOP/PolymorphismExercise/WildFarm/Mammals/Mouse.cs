using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Mammals
{
    public class Mouse : Mammal
    {
        private const double MouseWeightModifier = 0.10;
        private static HashSet<string> MouseAllowedFoods = new HashSet<string>
        {
            nameof(Vegetable)
        };
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, MouseAllowedFoods, MouseWeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
