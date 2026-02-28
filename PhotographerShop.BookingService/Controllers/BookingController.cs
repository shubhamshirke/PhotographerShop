using Microsoft.AspNetCore.Mvc;
using PhotographerShop.BookingService.Data;
using PhotographerShop.BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace PhotographerShop.BookingService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        private readonly BookingDbContext _context;

        public BookingController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return Ok(booking);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return Ok(bookings);
        }
    }
}
