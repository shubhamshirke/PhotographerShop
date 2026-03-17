using Microsoft.EntityFrameworkCore;
using PhotographerShop.FrameService.Models;

namespace PhotographerShop.FrameService.Data
{
    public class FrameDbContext : DbContext
    {
        public FrameDbContext(DbContextOptions<FrameDbContext> options):base(options)
        {
            
        }

        public DbSet<Frame> Frames { get; set; }
        public DbSet<FrameCustomization> FramesCustomization { get; set; }
        public DbSet<FrameOrder> FramesOrder { get; set; }
        public DbSet<FrameSize> FramesSize { get; set; }

    }
}
