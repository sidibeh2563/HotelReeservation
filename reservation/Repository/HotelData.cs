using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reservation.Repository
{
    public class HotelData
    {
        public static List<Hotel>? Hotels { get; set; } = new List<Hotel>();
        public static List<Booking>? Bookings { get; set; } = new List<Booking>();

        public static void LoadHotelData(string hotelJsonFile)
        {
            var jsonStringHotels = File.ReadAllText(hotelJsonFile);
            Hotels = JsonConvert.DeserializeObject<List<Hotel>>(jsonStringHotels);

        }
        public static void LoadBookinglData(string bookingJsonFile)
        {
            var jsonStringBookings = File.ReadAllText(bookingJsonFile);
            Bookings = JsonConvert.DeserializeObject<List<Booking>>(jsonStringBookings);
        }
    }
}
