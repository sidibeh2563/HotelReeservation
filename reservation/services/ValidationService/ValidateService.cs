namespace reservation.services.ValidationService
{
    public class ValidateService : IValidateService
    {
        public  DateTime GetDateFromString(string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
            {
                return DateTime.ParseExact(dateString, "yyyyMMdd", CultureInfo.InvariantCulture);
            }
            return DateTime.MinValue;
        }

        public bool IsDateRangeValid(DateTime start1, DateTime end1, DateTime arrival, DateTime departure)
        {
            return start1 < departure && arrival < end1;
        }
    }
}
