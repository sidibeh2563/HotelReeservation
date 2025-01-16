namespace reservation.Models
{
    using System.Collections.Generic;

    public class Hotel
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public List<RoomType> RoomTypes { get; set; } = default!;
        public List<Room> Rooms { get; set; } = default!;
    }

}
