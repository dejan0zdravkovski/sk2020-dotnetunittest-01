using Microsoft.EntityFrameworkCore;
using SEDC.Travel.Domain.Model;

namespace SEDC.Travel.Domain
{
    public class TravelContext : DbContext
    {
        public TravelContext()
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelCategory> HotelCategories { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Pricing> Pricings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Hotel>().HasKey(x => x.Id);
            modelbuilder.Entity<HotelCategory>().HasKey(x => x.Id);
            modelbuilder.Entity<HotelRoom>().HasKey(x => x.Id);
            modelbuilder.Entity<Room>().HasKey(x => x.Id);
            modelbuilder.Entity<Country>().HasKey(x => x.Id);
            modelbuilder.Entity<Pricing>().HasKey(x => x.Id);
        }
    }
}
