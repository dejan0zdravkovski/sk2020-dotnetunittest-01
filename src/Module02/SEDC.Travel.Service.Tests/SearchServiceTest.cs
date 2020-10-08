﻿using Moq;
using SEDC.Travel.Domain.Contract;
using SEDC.Travel.Domain.Model;
using SEDC.Travel.Service.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SEDC.Travel.Service.Tests
{
    public class SearchServiceTest
    {

        #region GetHotels
        [Fact]
        public void GetHotels_NoExistingHotels_ReturnResultShouldBeEmpty()
        {
            //Arrange
            var mockCountryRepository = new Mock<ICountryRepository>();
            var mockHotelRepository = new Mock<IHotelRepository>();

            //Act
            var searchService = new SearchService(mockCountryRepository.Object, mockHotelRepository.Object);
            var result = searchService.GetHotels();

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetHotels_NoExistingHotels_ReturnResultShouldBeOfTypeHoteList()
        {
            //Arrange
            var mockCountryRepository = new Mock<ICountryRepository>();
            var mockHotelRepository = new Mock<IHotelRepository>();

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
            var mockCountryRepository = new Mock<ICountryRepository>();
            var mockHotelRepository = new Mock<IHotelRepository>();
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


            var mockCountryRepository = new Mock<ICountryRepository>();
            var mockHotelRepository = new Mock<IHotelRepository>();
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


            var mockCountryRepository = new Mock<ICountryRepository>();
            var mockHotelRepository = new Mock<IHotelRepository>();
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
            var mockedHotels = new List<Hotel>
            {
                new Hotel { Id = 1, Code = "01", Name="Hotel Royal Skopje", Description="Description", City="Skopje", Address="BB", Email="test@in.com", CountryId=1, HotelCategoryId=1, Web="http://rojalsk.mk" },
                new Hotel { Id = 2, Code = "02", Name="Continental", Description="Description", City="Skopje", Address="BB", Email="test@in.com", CountryId=1, HotelCategoryId=1, Web="http://continental.mk" }
            };
            var mockedHotelCategory = new HotelCategory { Id = 1, Code = "03", Description = "4 STARS" };
            var expMsg = "Something went wrong.";

            var mockCountryRepository = new Mock<ICountryRepository>();
            var mockHotelRepository = new Mock<IHotelRepository>();
            var categoryId = 1;

            mockHotelRepository.Setup(x => x.GetHotels()).Returns(mockedHotels);
            mockHotelRepository.Setup(x => x.GetHotelCategory(categoryId)).Returns(mockedHotelCategory);
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
            var mockCountryRepository = new Mock<ICountryRepository>();
            var mockHotelRepository = new Mock<IHotelRepository>();

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

            var expectedHotel = new HotelDto
            {
                Id = 3,
                Code = "03",
                Name = "Diplomat Hotel",
                Description = "Description",
                City = "Ohrid",
                Address = "BB",
                Email = "test@in.com",
                CountryId = 1,
                HotelCategoryId = 1,
                Web = "http://diplomat.mk",
                CountryName = "Macedonia",
                HotelCategory = "4 STARS"
            };
            var hotel = new Hotel { Id = 3, Code = "03", Name = "Diplomat Hotel", Description = "Description", City = "Ohrid", Address = "BB", Email = "test@in.com", CountryId = 1, HotelCategoryId = 1, Web = "http://diplomat.mk" };
            var hotelCategory = new HotelCategory { Id = 1, Code = "03", Description = "4 STARS" };

            var mockCountryRepository = new Mock<ICountryRepository>();
            var mockHotelRepository = new Mock<IHotelRepository>();
            mockHotelRepository.Setup(x => x.GetHotel(hotelId)).Returns(hotel);
            mockHotelRepository.Setup(x => x.GetHotelCategory(hotelCategoryId)).Returns(hotelCategory);
            mockCountryRepository.Setup(x => x.GetCountryName(countryId)).Returns(country);

            //Act
            var searchService = new SearchService(mockCountryRepository.Object, mockHotelRepository.Object);
            var result = searchService.MapHotelData(hotel);

            //Assert
            Assert.Equal(expectedHotel.Id, result.Id);
            Assert.Equal(expectedHotel.Code, result.Code);
            Assert.Equal(expectedHotel.Name, result.Name);
            Assert.Equal(expectedHotel.Description, result.Description);
            Assert.Equal(expectedHotel.City, result.City);
            Assert.Equal(expectedHotel.Address, result.Address);
            Assert.Equal(expectedHotel.Email, result.Email);
            Assert.Equal(expectedHotel.CountryId, result.CountryId);
            Assert.Equal(expectedHotel.HotelCategoryId, result.HotelCategoryId);
            Assert.Equal(expectedHotel.Web, result.Web);
            Assert.Equal(expectedHotel.CountryName, result.CountryName);
            Assert.Equal(expectedHotel.HotelCategory, result.HotelCategory);
        }

        [Fact]
        public void MapHotelData_HotelExist_TheWebPropertyShouldBeEmpty()
        {
            //Arrange
            var hotelId = 1;
            var hotelCategoryId = 1;
            var countryId = 1;
            var country = "Macedonia";

            var expectedHotel = new HotelDto
            {
                Id = 3,
                Code = "03",
                Name = "Diplomat Hotel",
                Description = "Description",
                City = "Ohrid",
                Address = "BB",
                Email = "test@in.com",
                CountryId = 1,
                HotelCategoryId = 1,
                Web = "",
                CountryName = "Macedonia",
                HotelCategory = "4 STARS"
            };
            var hotel = new Hotel { Id = 3, Code = "03", Name = "Diplomat Hotel", Description = "Description", City = "Ohrid", Address = "BB", Email = "test@in.com", CountryId = 1, HotelCategoryId = 1, Web = "https://diplomat" };
            var hotelCategory = new HotelCategory { Id = 1, Code = "03", Description = "4 STARS" };

            var mockCountryRepository = new Mock<ICountryRepository>();
            var mockHotelRepository = new Mock<IHotelRepository>();
            mockHotelRepository.Setup(x => x.GetHotel(hotelId)).Returns(hotel);
            mockHotelRepository.Setup(x => x.GetHotelCategory(hotelCategoryId)).Returns(hotelCategory);
            mockCountryRepository.Setup(x => x.GetCountryName(countryId)).Returns(country);

            //Act
            var searchService = new SearchService(mockCountryRepository.Object, mockHotelRepository.Object);
            var result = searchService.MapHotelData(hotel);

            //Assert
            Assert.Null(result.Web);
        }



        #endregion

    }
}
