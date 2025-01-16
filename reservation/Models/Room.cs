namespace reservation.Models
{
    public class Room
    {
        public string RoomType { get; set; } = default!;
        public string RoomId { get; set; } = default!;
        public decimal? Total { get; set; } = default!;
    }
}
