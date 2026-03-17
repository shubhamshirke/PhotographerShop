namespace PhotographerShop.FrameService.Models
{
    public class FrameCustomization
    {
        public Guid Id { get; set; }

        public Guid FrameOrderId { get; set; }

        public string TextOnFrame { get; set; }

        public string GlassType { get; set; }

        public string BorderStyle { get; set; }
    }
}
