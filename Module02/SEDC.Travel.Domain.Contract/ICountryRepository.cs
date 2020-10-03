using System.Collections.Generic;

using SEDC.Travel.Domain.Model;

namespace SEDC.Travel.Domain.Contract
{
    public interface ICountryRepository
    {
        List<Country> GetCountries();

        string GetCountryName(int id);
    }
}
