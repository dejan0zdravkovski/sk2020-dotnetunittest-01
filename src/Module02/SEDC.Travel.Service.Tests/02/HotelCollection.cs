using Xunit;

namespace SEDC.Travel.Service.Tests._02
{
    [CollectionDefinition("HotelCollection")]
    public class HotelCollection : ICollectionFixture<HotelFixtureData>
    {
    }
}
