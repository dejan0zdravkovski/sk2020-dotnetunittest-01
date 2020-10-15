using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.UnitTesting.SUT.Tests._05
{

    [TestFixture]
    public class IntegerMethodsTest
    {
        [Test]
        public void FindNthLargestNumber_ListOfNumbersAndNthLargestNumberAreEnteredCorrectly_TheReturnedResultShouldBeCorrect()
        {
            var im = new IntegerMethods();
            var nthFibonaci = 2;
            var expectedResult = 2;

            var result = im.CalculateNthFibonacciNumber(nthFibonaci);

            //Assert.AreEqual(expectedResult, result);
            result.Should().Equals(expectedResult);
        }

    }
   
}
