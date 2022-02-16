using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int MinValue;
        private readonly int MaxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            int number = (int)obj;
            return number >= this.MinValue && number <= this.MaxValue;
        }
    }
}
