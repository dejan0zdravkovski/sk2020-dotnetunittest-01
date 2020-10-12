using System;

namespace SEDC.Travel.Service.Contract
{
    public interface IPricingService
    {
        decimal GetPricingPercent(DateTime from, DateTime to);
        decimal CalculatePrice(DateTime checkIn, DateTime checkOut, decimal price);
    }
}
