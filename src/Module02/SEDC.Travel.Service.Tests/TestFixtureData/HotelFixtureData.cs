using System;
using System.Collections.Generic;

using SEDC.Travel.Domain.Model;
using SEDC.Travel.Service.Model;
using SEDC.Travel.Service.Model.DTO;
using SEDC.Travel.Service.Model.ThirdParty;

namespace SEDC.Travel.Service.Tests._02
{
    public class HotelFixtureData
    {
        public Hotel MockedHotel { get; private set; }
        public HotelDto MockedExpectedHotel { get; private set; }
        public List<Hotel> HotelList { get; set; }
        public HotelCategory MockedHotelCategory { get; set; }

        public HotelAvailabilityResponse MockedHotelAvailabilityResponse { get; set; }

        public SearchRequest ValidRequestCase1 { get; set; }

        public HotelFixtureData()
        {
            MockedHotel = SetMockedHotel();
            MockedExpectedHotel = SetMockedExpectedHotel();
            HotelList = SetHotelList();
            MockedHotelCategory = SetHotelCategory();
            MockedHotelAvailabilityResponse = SetMockedHotelAvailabilityResponse();
            ValidRequestCase1 = SetValidRequestCase1();
        }

        private Hotel SetMockedHotel()
        {
            var hotel = new Hotel
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
                Web = "http://diplomat.mk"
            };

            return hotel;
        }

        private HotelDto SetMockedExpectedHotel()
        {
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
            return expectedHotel;
        }

        public List<Hotel> SetHotelList()
        {
            var mockedHotels = new List<Hotel>
            {
                new Hotel { Id = 1, Code = "01", Name="Hotel Royal Skopje", Description="Description", City="Skopje", Address="BB", Email="test@in.com", CountryId=1, HotelCategoryId=1, Web="http://rojalsk.mk" },
                new Hotel { Id = 2, Code = "02", Name="Continental", Description="Description", City="Skopje", Address="BB", Email="test@in.com", CountryId=1, HotelCategoryId=1, Web="http://continental.mk" }
            };
            return mockedHotels;
        }

        public HotelCategory SetHotelCategory()
        {
            return new HotelCategory { Id = 1, Code = "03", Description = "4 STARS" };
        }

        private HotelAvailabilityResponse SetMockedHotelAvailabilityResponse()
        {
            var response = new HotelAvailabilityResponse();
            response.Count = 2;
            response.CheckIn = DateTime.Now.AddDays(30);
            response.CheckOut = DateTime.Now.AddDays(35);

            var availableHotels = new List<HotelResponse>();

            var availableHotelFirst = new HotelResponse();
            availableHotelFirst.Code = "01";
            availableHotelFirst.AvailableRooms = new List<HotelAvailableRoom> {
                 new HotelAvailableRoom { Id = 1, Code = "ROM_01", Price = 100},
            };
            availableHotels.Add(availableHotelFirst);


            var availableHotelSecond = new HotelResponse();
            availableHotelSecond.Code = "02";
            availableHotelSecond.AvailableRooms = new List<HotelAvailableRoom> {
                 new HotelAvailableRoom { Id = 3, Code = "ROM_03", Price = 150},
            };
            availableHotels.Add(availableHotelSecond);


            response.AvailableHotels = availableHotels;
            return response;
        }

        private SearchRequest SetValidRequestCase1()
        {
            return new SearchRequest
            {
                FromDate = DateTime.Now.AddDays(10),
                ToDate = DateTime.Now.AddDays(15),
                Adults = 2,
                Children = 4,
                Rooms = 2,
                HotelCategory = 1,
            };
        }
    }
}
