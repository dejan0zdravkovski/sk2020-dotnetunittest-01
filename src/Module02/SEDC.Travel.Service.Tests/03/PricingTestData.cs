using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Travel.Service.Tests._03
{
    public class PricingTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new DateTime(2020, 01, 10), new DateTime(2020, 01, 15), 100, 110 };
            yield return new object[] { new DateTime(2020, 03, 27), new DateTime(2020, 04, 15), 100, 112 };
            yield return new object[] { new DateTime(2020, 12, 10), new DateTime(2021, 01, 15), 100, 113 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        
    }
}
