namespace reservation.services.HotelReservationService
{
    public interface IHotelReservation
    {
        Task<string> RoomAvailability(string hotelId, string dateRange, string roomType);
        Task<string> Search(string hotelId, int daysAhead, string roomType);
    }
}
