using Microsoft.AspNetCore.Mvc;
using PhotographerShop.FrameService.Data;
using PhotographerShop.FrameService.Models;
using Microsoft.EntityFrameworkCore;

namespace PhotographerShop.FrameService.Controllers
{
    [ApiController]
    [Route("api/frame-orders")]
    public class FrameOrdersController : ControllerBase
    {
        private readonly FrameDbContext _context;

        public FrameOrdersController(FrameDbContext context)
        {
            _context = context;
        }

        // ✅ POST: /api/frame-orders
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FrameOrder order)
        {
            if (order == null)
                return BadRequest();

            // Optional validations
            var frameExists = await _context.Frames.AnyAsync(f => f.Id == order.FrameId);
            var sizeExists = await _context.FramesSize.AnyAsync(s => s.Id == order.FrameSizeId);

            if (!frameExists || !sizeExists)
                return BadRequest("Invalid FrameId or FrameSizeId");

            order.Id = Guid.NewGuid();
            order.OrderDate = DateTime.UtcNow;

            _context.FramesOrder.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByBookingId),
                new { bookingId = order.BookingId },
                order);
        }

        // ✅ GET: /api/frame-orders/{bookingId}
        [HttpGet("{bookingId}")]
        public async Task<IActionResult> GetByBookingId(Guid bookingId)
        {
            var orders = await _context.FramesOrder
                .Where(o => o.BookingId == bookingId)
                .ToListAsync();

            if (!orders.Any())
                return NotFound("No orders found for this booking");

            return Ok(orders);
        }

        // ✅ GET: /api/frame-orders
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _context.FramesOrder.ToListAsync();
            return Ok(orders);
        }
    }
}
