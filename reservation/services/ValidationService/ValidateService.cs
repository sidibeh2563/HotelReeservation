using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
