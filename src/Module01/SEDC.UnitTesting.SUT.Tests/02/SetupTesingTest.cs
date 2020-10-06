using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.UnitTesting.SUT.Tests._02
{
    [TestFixture]
    public class SetupTesingTest
    {
        [OneTimeSetUp]
        public void Init()
        {
            var ss = "";
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            var ss = "";
        }

        [SetUp]
        public void Setup()
        {
            var ss = "";
        }


        [TearDown]
        public void TearDown()
        {
            var ss = "";
        }

        [Test]
        public void Test1()
        {
            Assert.IsTrue(true);
        }
        [Test]
        public void Test2()
        {
            Assert.IsTrue(true);
        }

    }
}
