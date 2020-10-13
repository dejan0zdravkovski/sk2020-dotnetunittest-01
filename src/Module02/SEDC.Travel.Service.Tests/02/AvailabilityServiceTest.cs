using Moq;
using SEDC.Travel.Domain.Contract;
using SEDC.Travel.Service.Contract;
using SEDC.Travel.Service.Model.ThirdParty;
using SEDC.Travel.Service.Tests.TestFixtureData;
using SEDC.Travel.Service.ThirdParty;
using System;
using System.Collections.Generic;
using Xunit;

namespace SEDC.Travel.Service.Tests._02
{
    [Collection("HotelCollection")]
    public class AvailabilityServiceTest : IClassFixture<SearchFixtureData>
    {
        HotelFixtureData _hotelFixtureData;
        SearchFixtureData _searchFixtureData;
        Mock<IHotelRepository> _hotelRepository;
        Mock<IHotelAvailability> _hotelAvailability;
        Mock<IPricingService> _pricingService;
        public AvailabilityServiceTest(HotelFixtureData hotelFixtureData, SearchFixtureData searchFixtureData)
        {
            _hotelFixtureData = hotelFixtureData;
            _searchFixtureData = searchFixtureData;
            _pricingService = new Mock<IPricingService>();
            _hotelAvailability = new Mock<IHotelAvailability>();
            _hotelRepository = new Mock<IHotelRepository>();
        }


        [Fact]
        public void ValidateSearchRequest_InvalidDateFromInSearchReqest_ShouldThrowException()
        {
            //Arrange

            //Act
            var availabilityService = new AvailabilityService(_hotelRepository.Object, _hotelAvailability.Object, _pricingService.Object);

            //Assert
            Assert.Throws<Exception>(() => availabilityService.ValidateSearchRequest(_searchFixtureData.RequestCase1));
        }

        [Fact]
        public void ValidateSearchRequest_InvalidDateToInSearchReqest_ShouldThrowException()
        {
            //Arrange

            //Act
            var availabilityService = new AvailabilityService(_hotelRepository.Object, _hotelAvailability.Object, _pricingService.Object);

            //Assert
            Assert.Throws<Exception>(() => availabilityService.ValidateSearchRequest(_searchFixtureData.RequestCase1));
        }

        [Fact]
        public void ValidateSearchRequest_InvalidDateFromIsBiggerThanDateToInSearchReqest_ShouldThrowException()
        {
            //Arrange

            //Act
            var availabilityService = new AvailabilityService(_hotelRepository.Object, _hotelAvailability.Object, _pricingService.Object);

            //Assert
            Assert.Throws<Exception>(() => availabilityService.ValidateSearchRequest(_searchFixtureData.RequestCase3));
        }

        [Fact]
        public void ValidateSearchRequest_InvalidAtLeastOneAdultPerRoomSearchReqest_ShouldThrowException()
        {
            //Arrange

            //Act
            var availabilityService = new AvailabilityService(_hotelRepository.Object, _hotelAvailability.Object, _pricingService.Object);

            //Assert
            Assert.Throws<Exception>(() => availabilityService.ValidateSearchRequest(_searchFixtureData.RequestCase4));
        }

        [Fact]
        public void Request_SearchRequestIsValid_ResultShouldBeOfTypeHotelAvailabilityRequest()
        {
            //Arrange

            //Act
            var availabilityService = new AvailabilityService(_hotelRepository.Object, _hotelAvailability.Object, _pricingService.Object);
            var result = availabilityService.Request(_searchFixtureData.ValidRequestCase1, It.IsAny<List<string>>());

            //Assert
            Assert.IsType<HotelAvailabilityRequest>(result);
        }

        [Fact]
        public void Request_SearchRequestIsValid_ShouldContainCorrectData()
        {
            //Arrange

            //Act
            var availabilityService = new AvailabilityService(_hotelRepository.Object, _hotelAvailability.Object, _pricingService.Object);
            var result = availabilityService.Request(_searchFixtureData.ValidRequestCase1, It.IsAny<List<string>>());

            //Assert
            //Assert.Equal(_searchFixtureData.HotelAvailabilityRequestCase1.CheckIn, result.CheckIn);
            //Assert.Equal(_searchFixtureData.HotelAvailabilityRequestCase1.CheckOut, result.CheckOut);
            Assert.Equal(_searchFixtureData.HotelAvailabilityRequestCase1.Nights, result.Nights);
            Assert.Equal(_searchFixtureData.HotelAvailabilityRequestCase1.Adults, result.Adults);
            Assert.Equal(_searchFixtureData.HotelAvailabilityRequestCase1.Children, result.Children);
            Assert.Equal(_searchFixtureData.HotelAvailabilityRequestCase1.Rooms, result.Rooms);
        }

        [Fact]
        public void CheckAvailability_ValidSearchRequestAndResultIsReturnedWithTwoHotels_ResultShouldContainTwoHotels()
        {
            //Arrange
            _hotelAvailability.Setup(x => x.SearchHotelAvailability(It.IsAny<HotelAvailabilityRequest>())).Returns(_hotelFixtureData.MockedHotelAvailabilityResponse);
            int expectedHotelsCount = 2;

            //Act
            var availabilityService = new AvailabilityService(_hotelRepository.Object, _hotelAvailability.Object, _pricingService.Object);
            var result = availabilityService.CheckAvailability(_searchFixtureData.ValidRequestCase1, It.IsAny<List<string>>());

            //Assert
            Assert.Equal(expectedHotelsCount, result.AvailableHotels.Count);
        }

        [Fact]
        public void CheckAvailability_ValidSearchRequestAndResultIsReturnedWithTwoHotels_NewPriceShouldHaveValue()
        {
            //Arrange
            decimal mockedReturnPrice = 10;

            _hotelAvailability.Setup(x => x.SearchHotelAvailability(It.IsAny<HotelAvailabilityRequest>())).Returns(_hotelFixtureData.MockedHotelAvailabilityResponse);
            _pricingService.Setup(x => x.CalculatePrice(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<decimal>()))
                .Returns(mockedReturnPrice);

            //Act
            var availabilityService = new AvailabilityService(_hotelRepository.Object, _hotelAvailability.Object, _pricingService.Object);
            var result = availabilityService.CheckAvailability(_searchFixtureData.ValidRequestCase1, It.IsAny<List<string>>());

            //Assert
            foreach (var item in result.AvailableHotels)
            {
                foreach (var room in item.AvailableRooms)
                {
                    Assert.True(room.NewPrice>0);
                }
            }
        }

        [Fact]
        public void CheckAvailability_ValidSearchRequestAndResultIsReturnedWithTwoHotels_NewPriceShouldBeBiggerThanPrice()
        {
            //Arrange

            _hotelAvailability.Setup(x => x.SearchHotelAvailability(It.IsAny<HotelAvailabilityRequest>())).Returns(_hotelFixtureData.MockedHotelAvailabilityResponse);
            _pricingService.SetupSequence(x => x.CalculatePrice(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<decimal>()))
                .Returns(120)
                .Returns(170);
            //TODO: Check this
            //_pricingService.SetupSequence(x => 
            //            x.CalculatePrice(_hotelFixtureData.MockedHotelAvailabilityResponse.CheckIn, 
            //                             _hotelFixtureData.MockedHotelAvailabilityResponse.CheckOut, 
            //                             100))
            //    .Returns(120)
            //    .Returns(170);

            //Act
            var availabilityService = new AvailabilityService(_hotelRepository.Object, _hotelAvailability.Object, _pricingService.Object);
            var result = availabilityService.CheckAvailability(_searchFixtureData.ValidRequestCase1, It.IsAny<List<string>>());

            //Assert
            foreach (var item in result.AvailableHotels)
            {
                foreach (var room in item.AvailableRooms)
                {
                    Assert.True(room.NewPrice > room.Price);
                }
            }
        }

    }
}
