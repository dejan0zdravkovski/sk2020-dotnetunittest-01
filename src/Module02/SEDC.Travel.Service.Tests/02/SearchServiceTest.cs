using System;
using System.Collections.Generic;

using Xunit;
using Moq;
using SEDC.Travel.Domain.Contract;
using SEDC.Travel.Domain.Model;
using SEDC.Travel.Service.Model.DTO;


namespace SEDC.Travel.Service.Tests._02
{
    [Collection("HotelCollection")]
    public class SearchServiceTest //: IClassFixture<HotelFixtureData>
    {
        Mock<ICountryRepository> mockCountryRepository;
        Mock<IHotelRepository> mockHotelRepository;
        HotelFixtureData _hotelFixtureData;

        public SearchServiceTest(HotelFixtureData hotelFixtureData)
        {
            mockCountryRepository = new Mock<ICountryRepository>();
            mockHotelRepository = new Mock<IHotelRepository>();
            _hotelFixtureData = hotelFixtureData;
        }

        #region GetHotels
        [Fact]
        [Trait("GetHotels", "SEDC-001")]
        public void GetHotels_NoExistingHotels_ReturnResultShouldBeEmpty()
        {
            //Arrange

            //Act
            var searchService = new SearchService(mockCountryRepository.Object, mockHotelRepository.Object);
            var result = searchService.GetHotels();

            //Assert
            Assert.Empty(result);
        }

        [Fact(Skip = "Add reason.")]
        public void GetHotels_NoExistingHotels_Ignored()
        {
            //Arrange

            //Act
            var searchService = new SearchService(mockCountryRepository.Object, mockHotelRepository.Object);
            var result = searchService.GetHotels();

            //Assert
            Assert.Empty(result);
        }

        [Fact(DisplayName = "GetHotels_NoExistingHotels_ReturnResultShouldBeOfTypeHoteList")]
        [Trait("GetHotels", "SEDC-001")]
        public void GetHotels_NoExistingHotels_ReturnResultShouldBeOfTypeHoteList()
        {
            //Arrange

            //Act
            var searchService = new SearchService(mockCountryRepository.Object, mockHotelRepository.Object);
            var result = searchService.GetHotels();

            //Assert
            Assert.IsType<List<HotelDto>>(result);
        }

        [Fact]
        public void GetHotels_NoExistingHotels_ReturnResultShouldBeOfTypeHoteListCase1()
        {
            //Arrange
            var expected = typeof(List<HotelDto>);

            //Act
            var searchService = new SearchService(mockCountryRepository.Object, mockHotelRepository.Object);
            var result = searchService.GetHotels();

            //Assert
            Assert.IsType(expected, result);
        }

        [Fact]
        public void GetHotels_TwoExistingHotels_ReturnResultShouldBeOfTwo()
        {
            //Arrange
            var mockedHotels = new List<Hotel>
            {
                new Hotel { Id = 1, Code = "01", Name="Hotel Royal Skopje", Description="Description", City="Skopje", Address="BB", Email="test@in.com", CountryId=1, HotelCategoryId=1, Web="http://rojalsk.mk" },
                new Hotel { Id = 2, Code = "02", Name="Continental", Description="Description", City="Skopje", Address="BB", Email="test@in.com", CountryId=1, HotelCategoryId=1, Web="http://continental.mk" }
            };
            var mockedHotelCategory = new HotelCategory { Id = 1, Code = "03", Description = "4 STARS" };


            var categoryId = 1;

            mockHotelRepository.Setup(x => x.GetHotels()).Returns(mockedHotels);
            mockHotelRepository.Setup(x => x.GetHotelCategory(categoryId)).Returns(mockedHotelCategory);

            //Act
            var searchService = new SearchService(mockCountryRepository.Object, mockHotelRepository.Object);
            var result = searchService.GetHotels();

            //Assert
            Assert.Equal(mockedHotels.Count, result.Count);

        }

        [Fact]
        public void GetHotels_TwoExistingHotels_ShouldThrowExceptionBecouseOfTheGetCountrNameMethod()
        {
            //Arrange
            var mockedHotels = new List<Hotel>
            {
                new Hotel { Id = 1, Code = "01", Name="Hotel Royal Skopje", Description="Description", City="Skopje", Address="BB", Email="test@in.com", CountryId=1, HotelCategoryId=1, Web="http://rojalsk.mk" },
                new Hotel { Id = 2, Code = "02", Name="Continental", Description="Description", City="Skopje", Address="BB", Email="test@in.com", CountryId=1, HotelCategoryId=1, Web="http://continental.mk" }
            };
            var mockedHotelCategory = new HotelCategory { Id = 1, Code = "03", Description = "4 STARS" };

            var categoryId = 1;

            mockHotelRepository.Setup(x => x.GetHotels()).Returns(mockedHotels);
            mockHotelRepository.Setup(x => x.GetHotelCategory(categoryId)).Returns(mockedHotelCategory);
            mockCountryRepository.Setup(x => x.GetCountryName(1)).Throws(new Exception());

            //Act
            var searchService = new SearchService(mockCountryRepository.Object, mockHotelRepository.Object);

            //Assert
            Assert.Throws<Exception>(() => searchService.GetHotels());

        }

        [Fact]
        public void GetHotels_TwoExistingHotels_ShouldThrowExactErrorMsgBecouseOfTheGetCountrNameMethod()
        {
            //Arrange
            var expMsg = "Something went wrong.";
            var categoryId = 1;

            mockHotelRepository.Setup(x => x.GetHotels()).Returns(_hotelFixtureData.HotelList);
            mockHotelRepository.Setup(x => x.GetHotelCategory(categoryId)).Returns(_hotelFixtureData.MockedHotelCategory);
            mockCountryRepository.Setup(x => x.GetCountryName(1)).Throws(new Exception());

            //Act
            var searchService = new SearchService(mockCountryRepository.Object, mockHotelRepository.Object);

            //Assert
            var result = Assert.Throws<Exception>(() => searchService.GetHotels());
            Assert.Equal(expMsg, result.Message);
        }

        #endregion

        #region GetHotel

        [Fact]
        public void GetHotel_NoExistingHotel_ShouldThrowException()
        {
            //Arrange
            var hotelId = 1;

            //Act
            var searchService = new SearchService(mockCountryRepository.Object, mockHotelRepository.Object);

            //Assert
            Assert.Throws<Exception>(() => searchService.GetHotel(hotelId));
        }

        #endregion

        #region GetHotel

        [Fact]
        public void MapHotelData_HotelExist_AllDataMustBeCorrect()
        {
            //Arrange
            var hotelId = 1;
            var hotelCategoryId = 1;
            var countryId = 1;
            var country = "Macedonia";
            

            mockHotelRepository.Setup(x => x.GetHotel(hotelId)).Returns(_hotelFixtureData.MockedHotel);
            mockHotelRepository.Setup(x => x.GetHotelCategory(hotelCategoryId)).Returns(_hotelFixtureData.MockedHotelCategory);
            mockCountryRepository.Setup(x => x.GetCountryName(countryId)).Returns(country);

            //Act
            var searchService = new SearchService(mockCountryRepository.Object, mockHotelRepository.Object);
            var result = searchService.MapHotelData(_hotelFixtureData.MockedHotel);

            //Assert
            Assert.Equal(_hotelFixtureData.MockedExpectedHotel.Id, result.Id);
            Assert.Equal(_hotelFixtureData.MockedExpectedHotel.Code, result.Code);
            Assert.Equal(_hotelFixtureData.MockedExpectedHotel.Name, result.Name);
            Assert.Equal(_hotelFixtureData.MockedExpectedHotel.Description, result.Description);
            Assert.Equal(_hotelFixtureData.MockedExpectedHotel.City, result.City);
            Assert.Equal(_hotelFixtureData.MockedExpectedHotel.Address, result.Address);
            Assert.Equal(_hotelFixtureData.MockedExpectedHotel.Email, result.Email);
            Assert.Equal(_hotelFixtureData.MockedExpectedHotel.CountryId, result.CountryId);
            Assert.Equal(_hotelFixtureData.MockedExpectedHotel.HotelCategoryId, result.HotelCategoryId);
            Assert.Equal(_hotelFixtureData.MockedExpectedHotel.Web, result.Web);
            Assert.Equal(_hotelFixtureData.MockedExpectedHotel.CountryName, result.CountryName);
            Assert.Equal(_hotelFixtureData.MockedExpectedHotel.HotelCategory, result.HotelCategory);
        }

        [Fact]
        public void MapHotelData_HotelExist_TheWebPropertyShouldBeEmpty()
        {
            //Arrange
            var hotelId = 1;
            var hotelCategoryId = 1;
            var countryId = 1;
            var country = "Macedonia";
           
            var hotel = new Hotel { Id = 3, Code = "03", Name = "Diplomat Hotel", Description = "Description", City = "Ohrid", Address = "BB", Email = "test@in.com", CountryId = 1, HotelCategoryId = 1, Web = "https://diplomat" };
            var hotelCategory = new HotelCategory { Id = 1, Code = "03", Description = "4 STARS" };

            mockHotelRepository.Setup(x => x.GetHotel(hotelId)).Returns(hotel);
            mockHotelRepository.Setup(x => x.GetHotelCategory(hotelCategoryId)).Returns(hotelCategory);
            mockCountryRepository.Setup(x => x.GetCountryName(countryId)).Returns(country);

            //Act
            var searchService = new SearchService(mockCountryRepository.Object, mockHotelRepository.Object);
            var result = searchService.MapHotelData(hotel);

            //Assert
            Assert.Null(result.Web);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }



        #endregion

    }
}
