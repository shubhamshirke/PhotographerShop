namespace PhotographerShop.BookingService.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ShootType { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Status { get; set; } = "Pending";
        public decimal Price { get; set; }
    }
}
