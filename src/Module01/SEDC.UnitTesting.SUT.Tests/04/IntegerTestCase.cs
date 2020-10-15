using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.UnitTesting.SUT.Tests._04
{
    public class IntegerTestCase
    {
        static object[] Combinations =
        {
            new object[] { new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }, 2,  12},
            new object[] { new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2,  9},
        };
    }
}
