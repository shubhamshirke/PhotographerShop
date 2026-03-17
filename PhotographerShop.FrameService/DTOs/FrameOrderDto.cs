namespace PhotographerShop.FrameService.DTOs
{
    public class FrameOrderDto
    {
        public Guid Id { get; set; }

        public Guid BookingId { get; set; }

        public Guid FrameId { get; set; }

        public Guid FrameSizeId { get; set; }

        public string PhotoUrl { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
