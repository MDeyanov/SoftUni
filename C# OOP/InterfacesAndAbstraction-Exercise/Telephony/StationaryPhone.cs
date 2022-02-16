using System;
using System.Linq;

namespace Telephony
{
    class StationaryPhone : Phone
    {
        public override string Call(string number)
        {
            if (number.Any(x => !char.IsDigit(x)))
            {
                throw new InvalidOperationException("Invalid number!");
            }
            return $"Dialing... {number}";
        }
    }
}
