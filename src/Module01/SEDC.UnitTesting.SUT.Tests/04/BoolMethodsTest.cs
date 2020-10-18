using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using NUnit.Framework;

namespace SEDC.UnitTesting.SUT.Tests._04
{
    [TestFixture(Author = "SEDC", Description = "Tests about BoolMethos")]
    public class BoolMethodsTest
    {
        BoolMethods bm;
        [OneTimeSetUp]
        public void Init()
        {
            bm = new BoolMethods();
        }

        [Test]
        [Author("SEDC", "SEDC@in.com")]
        public void Test()
        {
            Assert.IsTrue(true);
        }

        [Test]
        [Author("SEDC")]
        public void BoolMethod_TheYearIsLeap_TheReturnedResultShouldBeTrue()
        {
            //Arrange

            //Act
            var result = bm.IsLeapYear(1996);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        [Author("SEDC")]
        public void BoolMethod_TheYearIsLeap_TheReturnedResultShouldBeTrueCase1()
        {
            //Arrange
            var year = 1996;

            //Act
            var result = bm.IsLeapYear(year);

            //Assert
            Assert.IsTrue(result);
        }

        [Test(Author = "SEDC")]
        public void BoolMethod_TheYeasIsNotLeap_TheReturnedResultShouldBeFalse()
        {
            //Arrange
            var year = 1997;

            //Act
            var result = bm.IsLeapYear(year);

            //Assert
            Assert.IsFalse(result);
        }

        [Test(Author = "SEDC")]
        [Description("")]
        public void BoolMethod_TheYeasIsNegative_ShouldThrowsArgumentException()
        {
            //Arrange
            var year = -1503;

            //Act + Assertsss
            Assert.Throws<ArgumentException>(() => bm.IsLeapYear(year));
        }

        [Test]
        public void BoolMethod_TheYeasIsNegative_ShouldThrowsArgumentExceptionCase1()
        {
            //Arrange
            var expectedExceptionMsg = "Year must be positive number";
            var year = -1503;

            //Act + Assertsss
            var result = Assert.Throws<ArgumentException>(() => bm.IsLeapYear(year));
            Assert.AreEqual(expectedExceptionMsg, result.Message);
        }

        [Test]
        public void BoolMethod_TheYeasIsNegative_ShouldThrowsException()
        {
            //Arrange
            var year = -1503;
            var vm = new BoolMethods();

            //Act + Assertsss
            Assert.Catch<Exception>(() => vm.IsLeapYear(year));
        }

        [Test(Author = "SEDC")]
        public void BoolMethod_TheYeasIsNotLeapWithValues_TheReturnedResultShouldBeFalse([Values(1997, 2001)] int year, [Values(false)] bool expectedResult)
        {
            //Arrange

            //Act
            var result = bm.IsLeapYear(year);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1996 , true)]
        [TestCase(1997, false)]
        [TestCase(1998, false)]
        [TestCase(1999, false)]
        public void BoolMethod_WithGivenTeseCases_TheReturnedResultShouldBeCorrect(int year, bool expectedResult)
        {
            //Arrange

            //Act
            var result = bm.IsLeapYear(year);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1996, ExpectedResult = true)]
        [TestCase(1997, ExpectedResult = false)]
        [TestCase(1998, ExpectedResult = false)]
        [TestCase(1999, ExpectedResult = false)]
        public bool BoolMethod_WithGivenTestCases_TheReturnedResultShouldBeCorrectCase1(int year)
        {
           return bm.IsLeapYear(year);
        }

        [TestCaseSource("TestCase")]
        public void BoolMethod_WithGivenTestCaseSource_TheReturnedResultShouldBeCorrect(int year, bool expectedResult)
        {
            //Arrange

            //Act
            var result = bm.IsLeapYear(year);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCaseSource(typeof(BoolTestCase), "TestCase")]
        public void BoolMethod_WithGivenTestCaseSource_TheReturnedResultShouldBeCorrectCase1(int year, bool expectedResult)
        {
            //Arrange

            //Act
            var result = bm.IsLeapYear(year);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCaseSource("CsvData")]
        public bool BoolMethod_WithGivenCsvTestCases_TheReturnedResultShouldBeCorrectCase(int year)
        {
            return bm.IsLeapYear(year);
        }
        
        public static List<TestCaseData> CsvData
        {
            get
            {
                var testCases = new List<TestCaseData>();
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"04/test.csv");
                using (var fs = File.OpenRead(path))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ',' },
                                StringSplitOptions.None);

                            int year = Convert.ToInt32(split[0]);
                            bool expected = Convert.ToBoolean(split[1]);

                            var testCase = new TestCaseData(year).Returns(expected);
                            testCases.Add(testCase);
                        }
                    }
                }

                return testCases;
            }
        }

        static object[] TestCase =
        {
            new object[] { 1996 , true},
            new object[] { 1999 , false},
            new object[] { 2001 , false},
        };
    }
}
