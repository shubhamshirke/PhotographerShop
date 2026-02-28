using Microsoft.EntityFrameworkCore;
using PhotographerShop.BookingService.Models;

namespace PhotographerShop.BookingService.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
    : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
    }
}
