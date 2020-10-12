﻿using System.Collections.Generic;

using SEDC.Travel.Domain.Model;
using SEDC.Travel.Service.Model.DTO;

namespace SEDC.Travel.Service.Tests._02
{
    public class HotelFixtureData
    {
        public Hotel MockedHotel { get; private set; }
        public HotelDto MockedExpectedHotel { get; private set; }
        public List<Hotel> HotelList { get; set; }
        public HotelCategory MockedHotelCategory { get; set; }

        public HotelFixtureData()
        {
            MockedHotel = SetMockedHotel();
            MockedExpectedHotel = SetMockedExpectedHotel();
            HotelList = SetHotelList();
            MockedHotelCategory = SetHotelCategory();
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
    }
}
