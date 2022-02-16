using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double TigerWeightModifier = 1.00;
        private static HashSet<string> TigerAllowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, TigerAllowedFoods, TigerWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

    }
}
