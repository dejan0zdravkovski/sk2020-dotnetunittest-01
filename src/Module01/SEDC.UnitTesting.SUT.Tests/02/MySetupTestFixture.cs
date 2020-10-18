using NUnit.Framework;

namespace SEDC.UnitTesting.SUT.Tests._02
{
    [SetUpFixture]
    public class MySetupTestFixture
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTest()
        {
            //
        }

        [OneTimeTearDown]
        public void RunAfterAnyTest()
        {
            //
        }
    }
}
