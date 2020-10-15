using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.UnitTesting.SUT.Tests
{
    [TestFixture]
    public class BoolMethodsTest
    {
        [Test]
        public void Test()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void BoolMethod_TheYearIsLeap_TheReturnedResultShouldBeTrue()
        {
            //Arrange
            var vm = new BoolMethods();

            //Act
            var result = vm.IsLeapYear(1996);

            //Assert
            //Assert.IsTrue(result);
            result.Should().BeTrue();
        }

        [Test]
        public void BoolMethod_TheYearIsLeap_TheReturnedResultShouldBeTrueCase1()
        {
            //Arrange
            var year = 1996;
            var vm = new BoolMethods();

            //Act
            var result = vm.IsLeapYear(year);

            //Assert
            //Assert.IsTrue(result);
            result.Should().BeTrue();
        }

        [Test]
        public void BoolMethod_TheYeasIsNotLeap_TheReturnedResultShouldBeFalse()
        {
            //Arrange
            var year = 1997;
            var vm = new BoolMethods();

            //Act
            var result = vm.IsLeapYear(year);

            //Assert
            //Assert.IsFalse(result);
            result.Should().BeFalse();
        }

        [Test]
        public void BoolMethod_TheYeasIsNegative_ShouldThrowsArgumentException()
        {
            //Arrange
            var year = -1503;
            var vm = new BoolMethods();

            //Act + Assertsss
            //Assert.Throws<ArgumentException>(() => vm.IsLeapYear(year));
            Action result = () => vm.IsLeapYear(year);
            result.Should().Throw<ArgumentException>();

        }

        [Test]
        public void BoolMethod_TheYeasIsNegative_ShouldThrowsArgumentExceptionCase1()
        {
            //Arrange
            var expectedExceptionMsg = "Year must be positive number";
            var year = -1503;
            var vm = new BoolMethods();

            //Act + Assertsss
            //var result = Assert.Throws<ArgumentException>(() => vm.IsLeapYear(year));
            //Assert.AreEqual(expectedExceptionMsg, result.Message);
            Action result = () => vm.IsLeapYear(year);
            result.Should().Throw<ArgumentException>().WithMessage(expectedExceptionMsg);
            //result.Should().Throw<ArgumentException>().WithInnerException<xx>().WithMessage(expectedExceptionMsg);

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
