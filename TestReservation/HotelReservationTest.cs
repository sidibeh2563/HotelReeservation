using reservation.services.HotelReservationService;
using reservation.services.ValidationService;

namespace TestReservation
{
    [TestFixture]
    public class HotelReservationTest
    {
        private readonly IHotelReservation hotelReservation = new HotelReservation();
        private readonly IValidateService validateService = new ValidateService();
        [TestCase("H1", "20240901", "SGL")]
        [TestCase("H1", "20240901-20240903", "DBL")]
        public void Check_Room_Availability_In_The_Hotel(string hotel, string dates, string roomType)
        {
            Assert.IsNotNull(hotelReservation.RoomAvailability(hotel, dates, roomType).GetAwaiter().GetResult());
        }
        [TestCase("H1",365, "SGL")]
        [TestCase("H1", 90, "SGL")]
        public void Search_Booking_Availability_Days_In_The_Future(string hotel, int days, string roomType)
        {
            Assert.IsNotNull(hotelReservation.Search(hotel, days, roomType).GetAwaiter().GetResult());
        }

        [TestCase("20250117", "20250128", "20250131", "20250903")]
        public void Check_The_Date_Given_Is_Valid_Date_Range(string start1, string end1, string arrival, string departure)
        {
            Assert.IsFalse(validateService.IsDateRangeValid(validateService.GetDateFromString(start1),
                                                           validateService.GetDateFromString(end1), 
                                                           validateService.GetDateFromString(arrival), 
                                                           validateService.GetDateFromString(departure)));
        }
    }
}