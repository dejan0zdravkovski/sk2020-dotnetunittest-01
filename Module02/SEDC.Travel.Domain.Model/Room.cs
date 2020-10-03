using System;

namespace SEDC.Travel.Domain.Model
{
    public class Room
    {
        public int Id { get; set; }

        public Nullable<int> MinPax { get; set; }

        public Nullable<int> MaxPax { get; set; }

        public Nullable<int> MaxAdults { get; set; }

        public Nullable<int> MaxChildren { get; set; }

        public Nullable<int> MinAdults { get; set; }

        public string Description { get; set; }

    }
}
