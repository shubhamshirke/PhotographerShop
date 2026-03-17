using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotographerShop.FrameService.Data;
using PhotographerShop.FrameService.Models;

[ApiController]
[Route("api/[controller]")]
public class FramesController : ControllerBase
{
    private readonly FrameDbContext _context;

    public FramesController(FrameDbContext context)
    {
        _context = context;
    }

    // ✅ GET: /api/frames
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var frames = await _context.Frames.ToListAsync();
        return Ok(frames);
    }

    // ✅ GET: /api/frames/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var frame = await _context.Frames.FindAsync(id);

        if (frame == null)
            return NotFound();

        return Ok(frame);
    }

    // ✅ POST: /api/frames
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Frame frame)
    {
        if (frame == null)
            return BadRequest();

        _context.Frames.Add(frame);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = frame.Id }, frame);
    }

    // ✅ PUT: /api/frames/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Frame updatedFrame)
    {
        if (id != updatedFrame.Id)
            return BadRequest("ID mismatch");

        var existingFrame = await _context.Frames.FindAsync(id);

        if (existingFrame == null)
            return NotFound();

        // Update fields
        existingFrame.Name = updatedFrame.Name;
        existingFrame.Material = updatedFrame.Material;
        existingFrame.Color = updatedFrame.Color;
        existingFrame.Price = updatedFrame.Price;
        existingFrame.ImageUrl = updatedFrame.ImageUrl;
        existingFrame.IsAvailable = updatedFrame.IsAvailable;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // ✅ DELETE: /api/frames/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var frame = await _context.Frames.FindAsync(id);

        if (frame == null)
            return NotFound();

        _context.Frames.Remove(frame);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}