namespace PhotographerShop.FrameService.DTOs
{
    public class FrameCustomizationDto
    {
        public Guid Id { get; set; }

        public Guid FrameOrderId { get; set; }

        public string TextOnFrame { get; set; }

        public string GlassType { get; set; }

        public string BorderStyle { get; set; }
    }
}
