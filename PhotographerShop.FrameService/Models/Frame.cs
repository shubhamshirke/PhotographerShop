namespace PhotographerShop.FrameService.Models
{
    public class Frame
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Material { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public bool IsAvailable { get; set; }
    }
}
