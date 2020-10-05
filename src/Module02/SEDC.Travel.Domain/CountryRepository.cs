using System.Collections.Generic;
using System.Linq;

using SEDC.Travel.Domain.Contract;
using SEDC.Travel.Domain.Model;

namespace SEDC.Travel.Domain
{
    public class CountryRepository : ICountryRepository
    {
        /// <summary>
        /// Get countries.
        /// </summary>
        /// <returns></returns>
        public List<Country> GetCountries()
        {
            using (var travelContext = new TravelContext())
            {
                var countries = travelContext.Countries;

                return countries.ToList();
            }
        }

        /// <summary>
        /// Get country name by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCountryName(int id)
        {
            using (var travelContext = new TravelContext())
            {
                var countryName = travelContext.Countries.SingleOrDefault(x => x.Id == id).CountryName;

                return countryName;
            }
        }
    }
}
