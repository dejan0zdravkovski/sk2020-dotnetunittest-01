using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.UnitTesting.SUT.Tests._03
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


    }
}
