using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotographerShop.FrameService.Data;
using PhotographerShop.FrameService.Models;

namespace PhotographerShop.FrameService.Controllers
{

    [ApiController]
    [Route("api/frame-customization")]
    public class FrameCustomizationController : ControllerBase
    {
        private readonly FrameDbContext _context;

        public FrameCustomizationController(FrameDbContext context)
        {
            _context = context;
        }

        // ✅ POST: /api/frame-customization
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FrameCustomization customization)
        {
            if (customization == null)
                return BadRequest();

            // Validate FrameOrder exists
            var orderExists = await _context.FramesOrder
                .AnyAsync(o => o.Id == customization.FrameOrderId);

            if (!orderExists)
                return BadRequest("Invalid FrameOrderId");

            customization.Id = Guid.NewGuid();

            _context.FramesCustomization.Add(customization);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByOrderId),
                new { orderId = customization.FrameOrderId },
                customization);
        }

        // ✅ GET: /api/frame-customization/{orderId}
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetByOrderId(Guid orderId)
        {
            var customizations = await _context.FramesCustomization
                .Where(c => c.FrameOrderId == orderId)
                .ToListAsync();

            if (!customizations.Any())
                return NotFound("No customization found for this order");

            return Ok(customizations);
        }
    }
}
