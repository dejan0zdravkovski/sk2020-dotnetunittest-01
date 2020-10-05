using System.Collections.Generic;

using SEDC.Travel.Domain.Model;

namespace SEDC.Travel.Domain.Contract
{
    public interface IPricingRepository
    {
        List<Pricing> GetPricings();
        Pricing GetPricing(int id);
    }
}
