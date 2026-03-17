namespace PhotographerShop.FrameService.Models
{
    public class FrameSize
    {
        public Guid Id { get; set; }

        public Guid FrameId { get; set; }

        public string SizeName { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal AdditionalPrice { get; set; }
    }
}
