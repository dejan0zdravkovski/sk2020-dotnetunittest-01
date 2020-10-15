using System;
using System.Threading;

namespace SEDC.UnitTesting.SUT
{
    public class StringMethods
    {
        public string Reverse(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException();

            var arr = value.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
