using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using SEDC.Travel.Domain.Contract;
using SEDC.Travel.Domain.Model;
using SEDC.Travel.Service.Contract;
using SEDC.Travel.Service.Model;
using SEDC.Travel.Service.Model.DTO;


namespace SEDC.Travel.Service
{
    public class SearchService : ISearchService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IHotelRepository _hotelRepository;

        public SearchService(ICountryRepository countryRepository, IHotelRepository hotelRepository)
        {
            _countryRepository = countryRepository;
            _hotelRepository = hotelRepository;
        }

        public List<HotelDto> GetHotels()
        {
            var hotels = _hotelRepository.GetHotels();

            if (hotels == null)
            {
                return new List<HotelDto>();
            }

            var result = new List<HotelDto>();
            foreach (var item in hotels)
            {
                result.Add(MapHotelData(item));
            }

            return result;

        }

        public HotelDto GetHotel(int id)
        {
            var hotel = _hotelRepository.GetHotel(id);

            return MapHotelData(hotel);
        }

        public HotelDto MapHotelData(Hotel hotel)
        {
            try
            {
                var result = new HotelDto();
                result.Id = hotel.Id;
                result.Code = hotel.Code;
                result.Name = hotel.Name;
                result.Description = hotel.Description;
                result.City = hotel.City;
                result.Address = result.Address;
                result.Email = hotel.Email;

                Regex urlRegex = new Regex(@"(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?");
                if (urlRegex.IsMatch(hotel.Web))
                {
                    result.Web = hotel.Web;
                }

                result.CountryId = hotel.CountryId;
                result.HotelCategoryId = hotel.HotelCategoryId;
                result.CountryName = _countryRepository.GetCountryName(hotel.CountryId);
                result.HotelCategory = _hotelRepository.GetHotelCategory(hotel.HotelCategoryId).Description;

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Something went wrong.");
            }
        }

        public void Autocomplete()
        {
            throw new NotImplementedException();
        }

        public List<CountryDto> GetCountries()
        {
            throw new NotImplementedException();
        }

        public List<HotelCategoryDto> GetHotelCategory()
        {
            throw new NotImplementedException();
        }

        public List<HotelDto> GetHotelsByCategory(int contryId)
        {
            throw new NotImplementedException();
        }

        public List<HotelDto> GetHotelsByCountry(int contryId)
        {
            throw new NotImplementedException();
        }

        public List<RoomDto> GetRooms()
        {
            throw new NotImplementedException();
        }

        public void Search(SearchRequest request)
        {
            if (request.HotelCategory > 0 && request.Country > 0)
            {
                throw new NotImplementedException();
            }
            else if (request.HotelCategory > 0)
            {
                var result = _hotelRepository.GetHotelsByCategory(request.HotelCategory);
            }
            else if (request.Country > 0)
            {
                var result = _hotelRepository.GetHotelsByCountry(request.Country);
            }

            var all = _hotelRepository.GetHotels();
        }


    }
}
