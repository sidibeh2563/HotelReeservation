namespace reservation.Models
{
    public class Booking
    {
        public string HotelId { get; set; } = default!;
        public string Arrival { get; set; } = default!;
        public string Departure { get; set; } = default!;
        public string RoomType { get; set; } = default!;
        public string RoomRate { get; set; } = default!;
    }
}
