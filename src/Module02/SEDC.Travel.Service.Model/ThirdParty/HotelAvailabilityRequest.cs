using System;
using System.Collections.Generic;

namespace SEDC.Travel.Service.Model.ThirdParty
{
    public class HotelAvailabilityRequest
    {
        public IEnumerable<string> HotelList { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Nights { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Infants { get; set; }
        public int Rooms { get; set; }
        public int HotelCategory { get; set; }
        public int Country { get; set; }
    }
}
