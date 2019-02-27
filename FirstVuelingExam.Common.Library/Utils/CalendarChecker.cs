using FirstVuelingExam.Common.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFramework.VuelingLogs;

namespace FirstVuelingExam.Common.Library.Utils
{
    public static class CalendarChecker
    {
        private static readonly IVuelingLogger log = new Log4NetLogger();


        /// <summary>
        /// Obtains the <c>DateTime</c> that corresponds to the last Thursday 
        /// of a particular <paramref name="month"/> in a particular <paramref name="month"/>
        /// </summary>
        /// <param name="month">Integer number defines a month</param>
        /// <param name="year">Integer number defines a year</param>
        /// <returns>A date that corresponds to the last Thursday of the month</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
                log.Error(e.Message);
                throw;
            }

            return lastThursday;
        }

        /// <summary>
        /// Obtains a list of <c>DateTime</c> objects from <paramref name="dates"/>,
        /// if some day there's no openValue information, the invesment is tried the next day
        /// </summary>
        /// <param name="dates">A <c>Dictionary</c> with a range of dates</param>
        /// <returns>A list of <c>DateTime</c> objects</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
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
                log.Error(e.Message);
                throw;
            }
            catch (InvalidOperationException e)
            {
                log.Error(e.Message);
                throw;
            }

            return investmentDays;
        }

     

    }
}
