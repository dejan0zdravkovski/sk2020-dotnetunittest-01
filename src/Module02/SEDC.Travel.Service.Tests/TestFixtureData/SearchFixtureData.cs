using System;

using SEDC.Travel.Service.Model;
using SEDC.Travel.Service.Model.ThirdParty;

namespace SEDC.Travel.Service.Tests.TestFixtureData
{
    public class SearchFixtureData
    {
        public SearchRequest RequestCase1 { get; set; }
        public SearchRequest RequestCase2 { get; set; }
        public SearchRequest RequestCase3 { get; set; }
        public SearchRequest RequestCase4 { get; set; }

        public SearchRequest ValidRequestCase1 { get; set; }
        public HotelAvailabilityRequest HotelAvailabilityRequestCase1 { get; set; }

        public SearchFixtureData()
        {
            RequestCase1 = SetRequestCase1();
            RequestCase2 = SetRequestCase2();
            RequestCase3 = SetRequestCase3();
            RequestCase4 = SetRequestCase4();
            ValidRequestCase1 = SetValidRequestCase1();
            HotelAvailabilityRequestCase1 = SetHotelAvailabilityRequestCase1();
        }
        private SearchRequest SetRequestCase1()
        {
            return new SearchRequest
            {
                FromDate = null,
                ToDate = DateTime.Now.AddDays(35),
                Adults = 2,
                Children = 1,
                Rooms = 1,
                HotelCategory = 1,
                Country = 1
            };
        }

        private SearchRequest SetRequestCase2()
        {
            return new SearchRequest
            {
                FromDate = null,
                ToDate = null,
                Adults = 2,
                Children = 1,
                Rooms = 1,
                HotelCategory = 1,
                Country = 1
            };
        }

        private SearchRequest SetRequestCase3()
        {
            return new SearchRequest
            {
                FromDate = DateTime.Now.AddDays(15),
                ToDate = DateTime.Now.AddDays(10),
                Adults = 2,
                Children = 1,
                Rooms = 1,
                HotelCategory = 1,
                Country = 1
            };
        }

        private SearchRequest SetRequestCase4()
        {
            return new SearchRequest
            {
                FromDate = DateTime.Now.AddDays(10),
                ToDate = DateTime.Now.AddDays(15),
                Adults = 1,
                Children = 4,
                Rooms = 2,
                HotelCategory = 1,
                Country = 1
            };
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
                Country = 1
            };
        }


        private HotelAvailabilityRequest SetHotelAvailabilityRequestCase1()
        {
            return new HotelAvailabilityRequest
            {
                CheckIn = DateTime.Now.AddDays(10),
                CheckOut = DateTime.Now.AddDays(15),
                Nights = 5,
                Adults = 2,
                Children = 4,
                Rooms = 2,
                HotelCategory = 1
            };
        }

    }
}
