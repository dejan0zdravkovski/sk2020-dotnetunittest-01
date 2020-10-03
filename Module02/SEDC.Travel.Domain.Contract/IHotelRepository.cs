using System.Collections.Generic;

using SEDC.Travel.Domain.Model;

namespace SEDC.Travel.Domain.Contract
{
    public interface IHotelRepository
    {
        List<Hotel> GetHotels();
        Hotel GetHotel(int id);
        List<Hotel> GetHotelsByCountry(int countryId);
        List<Hotel> GetHotelsByCategory(int hotelCategory);
        List<HotelRoom> GetHotelRooms();
        List<HotelRoom> GetHotelRooms(int hotelId);
        List<HotelCategory> GetHotelCategories();
        HotelCategory GetHotelCategory(int categoryId);
        List<Room> GetRooms();
    }
}
