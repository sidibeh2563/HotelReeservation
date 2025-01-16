namespace reservation
{

    public class Program
    {
        // Main method to run the program
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddHotelServices()
                .BuildServiceProvider();

            IHotelReservation reservationService = new HotelReservation();

            Console.WriteLine("Enter --hotels Data file");
            var hoteldata = Console.ReadLine();
            Console.WriteLine("Enter --bookings data file");
            var bookingdata = Console.ReadLine();
            args[0] = $"--hotels={hoteldata}";
            args[1] = $"--bookings={bookingdata}";
           
            var hotelsFile = string.Empty;
            var bookingsFile = string.Empty;
            hotelsFile = args.FirstOrDefault(a => a.StartsWith("--hotels="))?.Substring(9);
            bookingsFile = args.FirstOrDefault(a => a.StartsWith("--bookings="))?.Substring(11);

            if (string.IsNullOrEmpty(hotelsFile) || string.IsNullOrEmpty(bookingsFile))
            {
                Console.WriteLine("Argument paramter not set in visual studio please enter file name...");
                var InputFile = Console.ReadLine()?.Trim();
                Console.WriteLine("Please Enter --hotels.json and --bookings.json file names including paths.");
                return;
            }

            // load JSON files
            HotelData.LoadHotelData(hotelsFile);
            HotelData.LoadBookinglData(bookingsFile);

            while (true)
            {
                Console.Write("Enter command (To Exit, Press Enter on Blank): ");
                var InputCommand = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(InputCommand))
                    break;

                try
                {
                    if (InputCommand.StartsWith("Availability"))
                    {
                        // command to enter at command prompt: Availability(H1, 20240901-20240903, DBL)
                        var hotelArray = InputCommand.Substring("Availability(".Length, InputCommand.Length - "Availability()".Length)
                                             .Split(new[] { ", " }, StringSplitOptions.None);
                        var hotelId = hotelArray[0];
                        var dates = hotelArray[1];
                        var roomType = hotelArray[2];
                        Console.WriteLine(reservationService.RoomAvailability(hotelId, dates, roomType).GetAwaiter().GetResult());
                    }
                    else if (InputCommand.StartsWith("Search"))
                    {
                        // command to enter at command prompt: Search(H1, 365, DBL)
                        var parts = InputCommand.Substring("Search(".Length, InputCommand.Length - "Search()".Length)
                                             .Split(new[] { ", " }, StringSplitOptions.None);
                        string hotelId = parts[0];
                        int Days = int.Parse(parts[1]);
                        string roomType = parts[2];
                        Console.WriteLine(reservationService.Search(hotelId, Days, roomType).GetAwaiter().GetResult());
                    }
                    else
                    {
                        Console.WriteLine("Command is not recognised");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing command: {ex.Message}");
                }
            }
        }
    }

}
