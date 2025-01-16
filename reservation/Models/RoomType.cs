namespace reservation.Models
{
    using System.Collections.Generic;
    public class RoomType
    {
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<string> Amenities { get; set; } = default!;
        public List<string> Features { get; set; } = default!;
    }
}
