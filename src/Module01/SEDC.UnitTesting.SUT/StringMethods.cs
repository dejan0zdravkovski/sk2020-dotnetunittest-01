using System;
using System.Threading;

namespace SEDC.UnitTesting.SUT
{
    public class StringMethods
    {
        public string Reverse(string value)
        {
            Thread.Sleep(60000);
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException();

            var arr = value.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
