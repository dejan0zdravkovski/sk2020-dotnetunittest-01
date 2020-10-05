using System;

namespace SEDC.Travel.Domain.Model
{
    public class Pricing
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal Percent { get; set; }
    }
}
