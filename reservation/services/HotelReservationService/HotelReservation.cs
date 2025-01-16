using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reservation.services.HotelReservationService
{
    public class HotelReservation : IHotelReservation
    {
        private readonly IValidateService _validateService = new ValidateService();

        public async Task<string> RoomAvailability(string hotelId, string dateRange, string roomType)
        {
            var dates = dateRange.Split('-');
            var startDate = _validateService.GetDateFromString(dates[0].ToString());
            var endDate = dates.Length > 1 ? _validateService.GetDateFromString(dates[1]) : startDate;

            var hotel = HotelData.Hotels?.FirstOrDefault(h => h.Id == hotelId);
            if (hotel == null)
                return "Could not find hotel";
                
            int numberOfRooms = hotel.Rooms.Count(r => r.RoomType == roomType);

            var bookedRooms = HotelData.Bookings?.Count(bk => bk.HotelId == hotelId 
                                                && bk.RoomType == roomType 
                                                && _validateService.IsDateRangeValid(startDate, endDate, _validateService.GetDateFromString(bk.Arrival), _validateService.GetDateFromString(bk.Departure)));

            var numberOfavailableRooms = numberOfRooms - bookedRooms;

            return $"Availability({hotelId}, {dateRange}, {roomType}) = {numberOfavailableRooms})";
        }

        public async Task<string> Search(string hotelId, int days, string roomType)
        {
            var today = DateTime.Today;
            var endDate = today.AddDays(days);
            var hotel = HotelData.Hotels?.FirstOrDefault(h => h.Id == hotelId);
            if (hotel == null)
                return $"Could not find Hotel:{hotelId}";

            var numberOfRooms = hotel?.Rooms.Count(r => r.RoomType == roomType) ?? 0;

            List<string> availablePeriod = new List<string>();

            for (DateTime checkDate = today; checkDate < endDate; checkDate = checkDate.AddDays(1))
            {
                DateTime checkStart = checkDate;
                DateTime checkEnd = checkStart.AddDays(1);

                var numberOfBookedRooms = HotelData.Bookings?.Count(bk => bk.HotelId == hotelId && bk.RoomType == roomType &&
                                                      _validateService.IsDateRangeValid(checkStart, checkEnd,
                                                      _validateService.GetDateFromString(bk.Arrival),
                                                      _validateService.GetDateFromString(bk.Departure)));

                var numberOfAvailableRooms = numberOfRooms - numberOfBookedRooms;

                if (numberOfAvailableRooms > 0)
                {
                    availablePeriod.Add($"({checkStart:yyyyMMdd}-{checkEnd:yyyyMMdd}, {numberOfAvailableRooms})");
                }
            }
            if (availablePeriod != null && availablePeriod.Count > 0)
                return string.Join(", ", availablePeriod);
            else
                return "";
        }
    }
}
