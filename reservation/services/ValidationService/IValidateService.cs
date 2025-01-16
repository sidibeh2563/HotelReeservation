namespace reservation.services.ValidationService
{
    public interface IValidateService
    {
        bool IsDateRangeValid(DateTime start1, DateTime end1, DateTime arrival, DateTime departure);
        DateTime GetDateFromString(string dateString);
    }
}
