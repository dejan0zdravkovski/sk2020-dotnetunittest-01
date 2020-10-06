using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.UnitTesting.SUT.Tests
{
    [TestFixture]
    public class StringMethodsTest
    {
        [Test]
        public void Reverse_StringThatIsNotEmptyOrNull_TheReturedResultShouldBeCorrect()
        {
            var sm = new StringMethods();
            var str = "SEDC";
            var expStr = "CDES";

            var result = sm.Reverse(str);

            Assert.AreEqual(expStr, result);
        }

        [Test]
        public void Reverse_StringIsNull_ShouldReturnException()
        {
            var sm = new StringMethods();

            Assert.Catch<Exception>(() => sm.Reverse(null));
        }

    }
}
