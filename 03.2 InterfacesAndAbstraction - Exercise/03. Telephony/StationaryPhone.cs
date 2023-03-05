using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    internal class StationaryPhone : ICalling
    {

        public string Call(string number)
        {
            if (number.Any(x => !char.IsDigit(x)))
            {
                return "Invalid number!";
            }
            return $"Dialing... {number}";
        }

    }
}
