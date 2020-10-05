using System;

using SEDC.Travel.Service.Model;
using SEDC.Travel.Service.Model.ThirdParty;

namespace SEDC.Travel.Service.Contract
{
    public interface IPricingService
    {
        decimal GetPricingPercent(DateTime from, DateTime to);
        RoomCombination CalculatePrice(DateTime checkIn, DateTime checkOut, HotelRoomCombination roomCombination);
    }
}
