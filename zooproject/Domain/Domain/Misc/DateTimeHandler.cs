using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zooproject.Domain.Domain.Misc
{
    public static class DateTimeHandler
    {
        public static DateTime GivenDateWeekMonday(DateTime dt)
        {
            DateTime today = DateTime.Now;
            return new GregorianCalendar().AddDays(dt, -((int)dt.DayOfWeek) + 1);
        }
        public static DateTime GivenDateWeekSunday(DateTime dt)
        {
            DateTime today = DateTime.Now;
            return new GregorianCalendar().AddDays(dt, -((int)dt.DayOfWeek) + 7);
        }
    }
}
