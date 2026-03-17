using Microsoft.AspNetCore.Mvc;
using PhotographerShop.FrameService.Data;
using PhotographerShop.FrameService.Models;
using Microsoft.EntityFrameworkCore;

namespace PhotographerShop.FrameService.Controllers
{
    [ApiController]
    [Route("api/frames")]
    public class FrameSizesController : ControllerBase
    {
        private readonly FrameDbContext _context;

        public FrameSizesController(FrameDbContext context)
        {
            _context = context;
        }

        // ✅ GET: /api/frames/{frameId}/sizes
        [HttpGet("{frameId}/sizes")]
        public async Task<IActionResult> GetSizesByFrame(Guid frameId)
        {
            var sizes = await _context.FramesSize
                .Where(s => s.FrameId == frameId)
                .ToListAsync();

            if (!sizes.Any())
                return NotFound("No sizes found for this frame");

            return Ok(sizes);
        }

        // ✅ POST: /api/frames/sizes
        [HttpPost("sizes")]
        public async Task<IActionResult> Create([FromBody] FrameSize frameSize)
        {
            if (frameSize == null)
                return BadRequest();

            // Optional: validate Frame exists
            var frameExists = await _context.Frames
                .AnyAsync(f => f.Id == frameSize.FrameId);

            if (!frameExists)
                return BadRequest("Invalid FrameId");

            _context.FramesSize.Add(frameSize);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSizesByFrame),
                new { frameId = frameSize.FrameId },
                frameSize);
        }

        // ✅ PUT: /api/frames/sizes/{id}
        [HttpPut("sizes/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] FrameSize updatedSize)
        {
            if (id != updatedSize.Id)
                return BadRequest("ID mismatch");

            var existingSize = await _context.FramesSize.FindAsync(id);

            if (existingSize == null)
                return NotFound();

            // Update fields
            existingSize.SizeName = updatedSize.SizeName;
            existingSize.Width = updatedSize.Width;
            existingSize.Height = updatedSize.Height;
            existingSize.AdditionalPrice = updatedSize.AdditionalPrice;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ DELETE: /api/frames/sizes/{id}
        [HttpDelete("sizes/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var size = await _context.FramesSize.FindAsync(id);

            if (size == null)
                return NotFound();

            _context.FramesSize.Remove(size);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}