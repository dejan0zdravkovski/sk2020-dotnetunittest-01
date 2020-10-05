using System;
using System.Collections.Generic;

namespace SEDC.Travel.Service.Model.ThirdParty
{
    public class HotelAvailabilityResponse
    {
        public int Count { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public List<HotelResponse> AvailableHotels { get; set; }
    }

    public class HotelResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public List<HotelRoomCombination> RoomCombinations { get; set; }
    }

    public class HotelRoomCombination
    {
        public int RoomsRequested { get; set; }
        public List<HotelAvailableRoom> AvailableRooms { get; set; }
    }

    public class HotelAvailableRoom
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
    }
}
