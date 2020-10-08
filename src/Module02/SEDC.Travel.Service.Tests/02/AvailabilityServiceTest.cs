using Xunit;

namespace SEDC.Travel.Service.Tests._02
{
    [Collection("HotelCollection")]
    public class AvailabilityServiceTest
    {
        HotelFixtureData _hotelFixtureData;
        public AvailabilityServiceTest(HotelFixtureData hotelFixtureData)
        {
            _hotelFixtureData = hotelFixtureData;
        }
    }
}
