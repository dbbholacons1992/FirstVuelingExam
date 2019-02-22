using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstVuelingExam
{
    public static class CalendarChecker
    {

        public static DateTime getLastThursday(int month, int year)
        {
            int Thursday = 4;
            int DaysEndOfWeek = 7 - 4;

            //get the number of days in a month
            int Day = DateTime.DaysInMonth(year, month);

            //get the number (0-7) of the last day of the month
            DateTime LastDayOfMonth = new DateTime(year, month, Day);
            int DayOfWeek = (int)LastDayOfMonth.DayOfWeek;

            //Add or Subtract days depending if the last day is after or before Thursday
            DateTime lastThursday = LastDayOfMonth.AddDays(-(
                (DayOfWeek < Thursday) ? (DayOfWeek + DaysEndOfWeek) : (DayOfWeek - Thursday)));

            return lastThursday;
        }

    }
}
