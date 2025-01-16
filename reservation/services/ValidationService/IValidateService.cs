using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reservation.services.ValidationService
{
    public interface IValidateService
    {
        bool IsDateRangeValid(DateTime start1, DateTime end1, DateTime arrival, DateTime departure);
        DateTime GetDateFromString(string dateString);
    }
}
