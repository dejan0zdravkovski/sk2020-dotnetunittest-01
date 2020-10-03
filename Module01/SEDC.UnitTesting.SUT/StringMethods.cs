using System;

namespace SEDC.UnitTesting.SUT
{
    public class StringMethods
    {
        public string Reverse(string value)
        {
            var arr = value.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
