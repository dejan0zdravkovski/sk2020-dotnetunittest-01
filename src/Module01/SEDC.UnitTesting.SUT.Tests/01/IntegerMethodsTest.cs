using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.UnitTesting.SUT.Tests
{
    [TestFixture]
    public class IntegerMethodsTest
    {
        [Test]
        public void FindNthLargestNumber_ListOfNumbersAndNthLargestNumberAreEnteredCorrectly_TheReturnedResultShouldBeCorrect()
        {
            var im = new IntegerMethods();
            var listNumbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            int nthLargestNumber = 3;
            int expectedResult = 4;

            var result = im.FindNthLargestNumber(listNumbers, nthLargestNumber);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [Ignore("FindNthLargestNumber method needs to be refactored")]
        public void FindNthLargestNumber_TheListOfNumbersIsEmpty_TheReturnedResultShouldBeCorrect()
        {
            var im = new IntegerMethods();
            var listNumbers = new List<int>();
            int nthLargestNumber = 3;
            int expectedResult = 4;

            var result = im.FindNthLargestNumber(listNumbers, nthLargestNumber);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void FindNthLargestNumber_TheListOfNumbersIsEmpty_ShouldReturnArgumentException()
        {
            var im = new IntegerMethods();
            var listNumbers = new List<int>();
            int nthLargestNumber = 3;

            Assert.Throws<ArgumentException>(() => im.FindNthLargestNumber(listNumbers, nthLargestNumber));
        }

    }
}
