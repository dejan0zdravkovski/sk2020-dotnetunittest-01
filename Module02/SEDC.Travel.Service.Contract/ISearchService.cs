using System.Collections.Generic;

using SEDC.Travel.Domain.Model;
using SEDC.Travel.Service.Model;
using SEDC.Travel.Service.Model.DTO;

namespace SEDC.Travel.Service.Contract
{
    public interface ISearchService
    {
        List<HotelDto> GetHotels();
        HotelDto GetHotel(int id);
        List<HotelDto> GetHotelsByCountry(int contryId);
        List<HotelDto> GetHotelsByCategory(int contryId);
        HotelDto MapHotelData(Hotel hotel);
        List<RoomDto> GetRooms();
        List<HotelCategoryDto> GetHotelCategory();
        List<CountryDto> GetCountries();
        void Autocomplete();
        void Search(SearchRequest request);
    }
}
