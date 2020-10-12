using System;
using System.Collections.Generic;

using SEDC.Travel.Service.Model.ThirdParty;


namespace SEDC.Travel.Service.Tests.TestFixtureData
{
    public class AvailabilityFixtureData
    {
        public HotelAvailabilityResponse MockedHotelAvailabilityResponse { get; set; }

        public AvailabilityFixtureData()
        {
            MockedHotelAvailabilityResponse = SetMockedHotelAvailabilityResponse();
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


    }
}
