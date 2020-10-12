using System;

using SEDC.Travel.Service.Model;

namespace SEDC.Travel.Service.Tests.TestFixtureData
{
    public class SearchFixtureData
    {
        public SearchRequest RequestCase1 { get; set; }

        public SearchFixtureData()
        {
            RequestCase1 = SetRequestCase1();
        }
        private SearchRequest SetRequestCase1()
        {
            return new SearchRequest
            {
                FromDate = DateTime.Now.AddDays(30),
                ToDate = DateTime.Now.AddDays(35),
                Adults = 2,
                Children = 1,
                Rooms = 1,
                HotelCategory = 1,
                Country = 1
            };
        }
        
    }
}
