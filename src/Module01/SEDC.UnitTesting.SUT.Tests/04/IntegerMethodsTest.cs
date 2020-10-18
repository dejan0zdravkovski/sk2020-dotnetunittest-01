using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace SEDC.UnitTesting.SUT.Tests._04
{
    [TestFixture]
    [Order(1)]
    public class IntegerMethodsTest
    {
        IntegerMethods im;
        List<int> listNumbers;

        [OneTimeSetUp]
        public void Init()
        {
            im = new IntegerMethods();
            listNumbers = new List<int>();
        }

        [TearDown]
        public void TearDown()
        {
            listNumbers.Clear();
        }

        [Test]
        [Order(3)]
        [Retry(2)]
        public void FindNthLargestNumber_ListOfNumbersAndNthLargestNumberAreEnteredCorrectly_TheReturnedResultShouldBeCorrect()
        {
            listNumbers.Add(1); listNumbers.Add(2); listNumbers.Add(3); listNumbers.Add(4); listNumbers.Add(5); listNumbers.Add(6);
            int nthLargestNumber = 3;
            int expectedResult = 4;

            var result = im.FindNthLargestNumber(listNumbers, nthLargestNumber);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [Order(2)]
        [Ignore("FindNthLargestNumber method needs to be refactored")]
        public void FindNthLargestNumber_TheListOfNumbersIsEmpty_TheReturnedResultShouldBeCorrect()
        {
            int nthLargestNumber = 3;
            int expectedResult = 4;

            var result = im.FindNthLargestNumber(listNumbers, nthLargestNumber);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [Order(1)]
        [Repeat(2)]
        public void FindNthLargestNumber_TheListOfNumbersIsEmpty_ShouldReturnArgumentException()
        {
            int nthLargestNumber = 3;

            Assert.Throws<ArgumentException>(() => im.FindNthLargestNumber(listNumbers, nthLargestNumber));
        }

        [TestCaseSource(typeof(IntegerTestCase), "Combinations")]
        public void FindNthLargestNumber_TestCaseSource_TheReturnedResultShouldBeCorrect(List<int> listNumbers, int nthLargestNumber, int expectedResult)
        {
            var result = im.FindNthLargestNumber(listNumbers, nthLargestNumber);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
