using System.Collections.Generic;

using SEDC.Travel.Service.Model;
using SEDC.Travel.Service.Model.ThirdParty;

namespace SEDC.Travel.Service.Contract
{
    public interface IAvailabilityService
    {
        AvailabilityResponse CheckAvailability(SearchRequest request, List<string> hotelCodes);

        AvailabilityResponse ProcessAvailability(HotelAvailabilityResponse response);
    }
}
