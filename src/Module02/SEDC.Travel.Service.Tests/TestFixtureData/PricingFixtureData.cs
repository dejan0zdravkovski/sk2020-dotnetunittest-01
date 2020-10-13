using SEDC.Travel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Travel.Service.Tests.TestFixtureData
{
    public class PricingFixtureData
    {
        public List<Pricing> MockedPricings { get; set; }

        public PricingFixtureData()
        {
            MockedPricings = SetMockedPricings();
        }

        private List<Pricing> SetMockedPricings()
        {
            return  new List<Pricing> {
                new Pricing { Id = 1, From = new DateTime(2020, 01, 01), To = new DateTime(2020, 03, 31), Percent = 10 },
                new Pricing { Id = 2, From = new DateTime(2020, 04, 01), To = new DateTime(2020, 06, 30), Percent = 12 },
                new Pricing { Id = 3, From = new DateTime(2020, 07, 01), To = new DateTime(2020, 09, 30), Percent = 15 },
                new Pricing { Id = 4, From = new DateTime(2020, 10, 01), To = new DateTime(2020, 12, 31), Percent = 10 },
            };
        }
    }
}
