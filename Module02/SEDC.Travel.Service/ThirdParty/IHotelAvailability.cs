using SEDC.Travel.Service.Model.ThirdParty;

namespace SEDC.Travel.Service.ThirdParty
{
    public interface IHotelAvailability
    {
        HotelAvailabilityResponse SearchHotelAvailability(HotelAvailabilityRequest request);
    }
}
