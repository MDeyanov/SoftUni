using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public class Bread : BakedFood
    {
        private const int InitialBreadPortion = 200;
        public Bread(string name,/* int portion,*/ decimal price) // portion se maha i se vyvehda constantnata stoinost
            : base(name, InitialBreadPortion, price)
        {
        }
    }
}
