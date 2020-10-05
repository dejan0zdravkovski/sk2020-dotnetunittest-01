using System;
using System.Collections.Generic;

namespace SEDC.Travel.Service.Model
{
    public class AvailabilityResponse
    {
        public int Count { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public List<AvailableHotel> AvailableHotels { get; set; }
    }

    public class AvailableHotel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public List<RoomCombination> RoomCombinations { get; set; }
    }

    public class RoomCombination
    {
        public decimal FullPrice { get; set; }
        public List<AvailableRoom> AvailableRooms { get; set; }
    }

    public class AvailableRoom
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public decimal NewPrice { get; set; }
    }
}
