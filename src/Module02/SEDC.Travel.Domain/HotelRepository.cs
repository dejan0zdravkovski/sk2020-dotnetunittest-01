using System.Collections.Generic;
using System.Linq;

using SEDC.Travel.Domain.Contract;
using SEDC.Travel.Domain.Model;

namespace SEDC.Travel.Domain
{
    public class HotelRepository : IHotelRepository
    {
        /// <summary>
        /// Get all hotels.
        /// </summary>
        /// <returns></returns>
        public List<Hotel> GetHotels()
        {
            using (var travelContext = new TravelContext())
            {
                var hotels = travelContext.Hotels;

                return hotels.ToList();
            }
        }

        /// <summary>
        /// Get hotel.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Hotel GetHotel(int id)
        {
            using (var travelContext = new TravelContext())
            {
                var hotels = travelContext.Hotels.SingleOrDefault(x => x.Id == id);

                return hotels;
            }
        }


        /// <summary>
        /// Get hotels by category.
        /// </summary>
        /// <param name="hotelCategory"></param>
        /// <returns></returns>
        public List<Hotel> GetHotelsByCategory(int hotelCategory)
        {
            using (var travelContext = new TravelContext())
            {
                var hotels = travelContext.Hotels.Where(x => x.HotelCategoryId == hotelCategory);

                return hotels.ToList();
            }
        }



        /// <summary>
        /// Get hotels by country.
        /// </summary>
        /// <param name="contry"></param>
        /// <returns></returns>
        public List<Hotel> GetHotelsByCountry(int countryId)
        {
            using (var travelContext = new TravelContext())
            {
                var hotels = travelContext.Hotels.Where(x => x.CountryId == countryId);

                return hotels.ToList();
            }
        }

        /// <summary>
        /// Get hotels room.
        /// </summary>
        /// <returns></returns>
        public List<HotelRoom> GetHotelRooms()
        {
            using (var travelContext = new TravelContext())
            {
                var hotelRooms = travelContext.HotelRooms;

                return hotelRooms.ToList();
            }
        }

        /// <summary>
        /// Get hotel rooms.
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public List<HotelRoom> GetHotelRooms(int hotelId)
        {
            using (var travelContext = new TravelContext())
            {
                var hotelRooms = travelContext.HotelRooms.Where(x => x.HotelId == hotelId);

                return hotelRooms.ToList();
            }
        }

        /// <summary>
        /// Get hotel categories.
        /// </summary>
        /// <returns></returns>
        public List<HotelCategory> GetHotelCategories()
        {
            using (var travelContext = new TravelContext())
            {
                var hotelCategories = travelContext.HotelCategories;

                return hotelCategories.ToList();
            }
        }

        public HotelCategory GetHotelCategory(int categoryId)
        {
            using (var travelContext = new TravelContext())
            {
                var hotelCategory = travelContext.HotelCategories.SingleOrDefault(x => x.Id == categoryId);

                return hotelCategory;
            }
        }


        /// <summary>
        /// Get rooms.
        /// </summary>
        /// <returns></returns>
        public List<Room> GetRooms()
        {
            using (var travelContext = new TravelContext())
            {
                var rooms = travelContext.Rooms;

                return rooms.ToList();
            }
        }

    }
}
