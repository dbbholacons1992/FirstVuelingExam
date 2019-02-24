using FirstVuelingExam.Common.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstVuelingExam.Common.Library.Utils
{
    public static class CalendarChecker
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection
                .MethodBase.GetCurrentMethod().DeclaringType);

        public static DateTime getLastThursday(int month, int year)
        {
            int Thursday = 4;
            int DaysEndOfWeek = 7 - 4;

            DateTime lastThursday;

            try
            {
                //get the number of days in a month
                int Day = DateTime.DaysInMonth(year, month);

                //get the number (0-7) of the last day of the month
                DateTime LastDayOfMonth = new DateTime(year, month, Day);
                int DayOfWeek = (int)LastDayOfMonth.DayOfWeek;

                //Add or Subtract days depending if the last day is after or before Thursday
                lastThursday = LastDayOfMonth.AddDays(-(
                    (DayOfWeek < Thursday) ? (DayOfWeek + DaysEndOfWeek) : (DayOfWeek - Thursday)));
            }
            catch (ArgumentOutOfRangeException e)
            {
                log.Error(e);
                throw;
            }

            return lastThursday;
        }

        public static List<DateTime> getAllInvestmentDaysInAPeriodOfTime(Dictionary<DateTime, InvestmentDay> dates)
        {
            List<DateTime> investmentDays = new List<DateTime>();
            try
            {
                DateTime firstDate = dates.Keys.First();
                DateTime lastDate = dates.Keys.Last();

                for (DateTime i = firstDate; i < lastDate; i = i.AddMonths(1))
                {
                    DateTime investDay = getLastThursday(i.Month, i.Year).AddDays(1);

                    if (investDay < lastDate && investDay > firstDate) investmentDays.Add(investDay);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                log.Error(e);
                throw;
            }
            catch (InvalidOperationException e)
            {
                log.Error(e);
                throw;
            }

            return investmentDays;
        }

     

    }
}
