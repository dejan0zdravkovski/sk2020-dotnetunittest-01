using System;

namespace SEDC.Travel.Service.Model
{
    public class SearchRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Infants { get; set; }
        public int Rooms { get; set; }
        public int HotelCategory { get; set; }
        public int Country { get; set; }
    }
}
