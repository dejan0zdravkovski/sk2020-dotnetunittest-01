using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.UnitTesting.SUT.Tests._02
{
    [TestFixture]
    public class StringMethodsTest
    {
        StringMethods sm;
        [SetUp]
        public void Setup()
        {
            sm = new StringMethods();
        }

        [Test]
        public void Reverse_StringThatIsNotEmptyOrNull_TheReturedResultShouldBeCorrect()
        {
            var str = "SEDC";
            var expStr = "CDES";

            var result = sm.Reverse(str);

            Assert.AreEqual(expStr, result);
        }

        [Test]
        public void Reverse_StringIsNull_ShouldReturnException()
        {
            Assert.Catch<Exception>(() => sm.Reverse(null));
        }
    }
}
