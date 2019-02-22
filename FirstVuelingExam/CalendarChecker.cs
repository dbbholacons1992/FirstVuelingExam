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

        public static List<DateTime> getAllInvestmentDaysInAPeriodOfTime(DateTime firstDate, DateTime lastDate)
        {
            List<DateTime> investmentDays = new List<DateTime>();

            for (DateTime i = firstDate; i < lastDate; i = i.AddMonths(1))
            {
                DateTime investDay = getLastThursday(i.Month, i.Year).AddDays(1);

                if(investDay < lastDate && investDay > firstDate)investmentDays.Add(investDay);
            }

            return investmentDays;
        }

        public static int getNumOfMonthEsp(string month)
        {
            switch (month)
            {
                case "ene":
                    return 1;
                case "feb":
                    return 2;
                case "mar":
                    return 3;
                case "abr":
                    return 4;
                case "may":
                    return 5;
                case "jun":
                    return 6;
                case "jul":
                    return 7;
                case "ago":
                    return 8;
                case "sep":
                    return 9;
                case "oct":
                    return 10;
                case "nov":
                    return 11;
                case "dic":
                    return 12;
                default:
                    return 0;

            }
        }

    }
}
