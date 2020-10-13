using Moq;
using SEDC.Travel.Domain.Contract;
using SEDC.Travel.Domain.Model;
using SEDC.Travel.Service.Tests.TestFixtureData;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SEDC.Travel.Service.Tests._03
{
    public class PricingServiceTest : IClassFixture<PricingFixtureData>
    {
        Mock<IPricingRepository> _pricingRepository;
        PricingFixtureData _pricingFixtureData;
        public PricingServiceTest(PricingFixtureData pricingFixtureData)
        {
            _pricingRepository = new Mock<IPricingRepository>();
            _pricingFixtureData = pricingFixtureData;
        }


        [Fact]
        public void GetPricingPercent_PeriodAreNotDefined_ResultShouldBe13()
        {
            var fromDate = DateTime.Now.AddDays(10);
            var toDate = DateTime.Now.AddDays(15);
            var expecterResult = 13;
            _pricingRepository.Setup(x => x.GetPricings()).Returns(new List<Pricing>());


            var pricingService = new PricingService(_pricingRepository.Object);
            var result = pricingService.GetPricingPercent(fromDate, toDate);


            Assert.Equal(expecterResult, result);
        }

        [Fact]
        public void GetPricingPercent_PeriodAreDefined_ResultShouldBeCorrect()
        {
            var fromDate = new DateTime(2020, 01, 15);
            var toDate = new DateTime(2020, 01, 25);
            var expecterResult = 10;
            _pricingRepository.Setup(x => x.GetPricings()).Returns(_pricingFixtureData.MockedPricings);


            var pricingService = new PricingService(_pricingRepository.Object);
            var result = pricingService.GetPricingPercent(fromDate, toDate);


            Assert.Equal(expecterResult, result);
        }

        [Fact]
        public void GetPricingPercent_PeriodAreDefined_ResultShouldBeCorrectCase1()
        {
            var fromDate = new DateTime(2020, 03, 25);
            var toDate = new DateTime(2020, 04, 05);
            var expecterResult = 12;
            _pricingRepository.Setup(x => x.GetPricings()).Returns(_pricingFixtureData.MockedPricings);


            var pricingService = new PricingService(_pricingRepository.Object);
            var result = pricingService.GetPricingPercent(fromDate, toDate);


            Assert.Equal(expecterResult, result);
        }

        [Fact]
        public void GetPricingPercent_PeriodAreDefinedForOneParametar_ResultShouldBeCorrectCase1()
        {
            var fromDate = new DateTime(2020, 12, 25);
            var toDate = new DateTime(2021, 01, 05);
            var expecterResult = 13;
            _pricingRepository.Setup(x => x.GetPricings()).Returns(_pricingFixtureData.MockedPricings);


            var pricingService = new PricingService(_pricingRepository.Object);
            var result = pricingService.GetPricingPercent(fromDate, toDate);


            Assert.Equal(expecterResult, result);
        }

        [Theory]
        [InlineData("2020-01-15", "2020-01-25", 100, 110)]
        [InlineData("2020-03-25", "2020-04-05", 100, 112)]
        [InlineData("2020-12-25", "2021-01-05", 100, 113)]
        public void CalculatePrice_HasValidPeriod_ResultShouldBeCorrect(string checkIn, string checkOut, decimal price, decimal expectedResult)
        {
            //Arrange
            _pricingRepository.Setup(x => x.GetPricings()).Returns(_pricingFixtureData.MockedPricings);

            //Act
            var pricingService = new PricingService(_pricingRepository.Object);
            var result = pricingService.CalculatePrice(DateTime.Parse(checkIn), DateTime.Parse(checkOut), price);

            //Assert
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [ClassData(typeof(PricingTestData))]
        public void CalculatePrice_TestCasesAreDefinedInClassData_ResultShouldBeCorrect(DateTime checkIn, DateTime checkOut, decimal price, decimal expectedResult)
        {
            //Arrange
            _pricingRepository.Setup(x => x.GetPricings()).Returns(_pricingFixtureData.MockedPricings);

            //Act
            var pricingService = new PricingService(_pricingRepository.Object);
            var result = pricingService.CalculatePrice(checkIn,checkOut, price);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(PricingMemberTestCases))]
        public void CalculatePrice_TestCasesAreDefinedAsMemberData_ResultShouldBeCorrect(DateTime checkIn, DateTime checkOut, decimal price, decimal expectedResult)
        {
            //Arrange
            _pricingRepository.Setup(x => x.GetPricings()).Returns(_pricingFixtureData.MockedPricings);

            //Act
            var pricingService = new PricingService(_pricingRepository.Object);
            var result = pricingService.CalculatePrice(checkIn, checkOut, price);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> PricingMemberTestCases => new List<object[]>
        {
            new object[] { new DateTime(2020, 01, 10), new DateTime(2020, 01, 15), 100, 110 },
            new object[] { new DateTime(2020, 03, 27), new DateTime(2020, 04, 15), 100, 112 },
            new object[] { new DateTime(2020, 12, 10), new DateTime(2021, 01, 15), 100, 113 }
        };


    }
}
