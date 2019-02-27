using FirstVuelingExam.Common.Library.Models;
using FirstVuelingExam.Common.Library.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFramework.VuelingLogs;


namespace FirstVuelingExam.DataAccess.Repository
{
    public class Repository
    {
        

        private readonly static string path = ConfigurationManager.AppSettings.Get("csvPath");
        private static readonly IVuelingLogger log = new Log4NetLogger();
        

        /// <summary>
        /// Parses a line to obtain a <c>DateTime</c> object
        /// </summary>
        /// <param name="line">A <c>string</c> that defines a date</param>
        /// <returns>A <c>DateTime</c> object</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        public DateTime getDateFromLine(string line)
        {
            DateTime date;

            try
            {
                date = DateTime.ParseExact(line, "dd-MMM-yyyy",
                                            CultureInfo.CreateSpecificCulture("es-US"));
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (FormatException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (CultureNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (NullReferenceException e)
            {
                log.Error(e.Message);
                throw;
            }

            return date;
        }

        /// <summary>
        /// Get from a file a list of <c>InvestmentDay</c> and store them in a <c>Dictionary</c>
        /// </summary>
        /// <returns>A <c>Dictionary</c> with all the stored <c>InvestedDay</c> objects</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="CultureNotFoundException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public Dictionary<DateTime, InvestmentDay> getAllInvestmentDays()
        {
            Dictionary<DateTime, InvestmentDay> allDays = new Dictionary<DateTime, InvestmentDay>();

            try
            {
                var allLines = from lines in File.ReadLines(path)
                               where !lines.Split(';')[0].Equals("Fecha")
                               select lines;

                foreach (string l in allLines)
                {
                    var lineValues = l.Split(';');
                    DateTime d = getDateFromLine(lineValues[0]);

                    allDays.Add(d, new InvestmentDay(d,
                                    decimal.Parse(lineValues[1], CultureInfo.InvariantCulture),
                                    decimal.Parse(lineValues[2], CultureInfo.InvariantCulture)));
                }
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (FormatException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (CultureNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (NullReferenceException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (OverflowException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (UnauthorizedAccessException e)
            {
                log.Error(e.Message);
                throw;
            }

            return allDays;
        }

        /// <summary>
        /// Get a <c>List</c> of investment days given a <paramref name="dates"/> that defines
        /// a range
        /// </summary>
        /// <param name="dates">
        /// A <c>Dictionary</c> with <c>DateTime</c> as Keys and <c>InvestmentDay</c> objects as values
        /// </param>
        /// <returns>A <c>List</c> of <c>InvestmentDay</c> objects</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="IOException"></exception>
        public List<InvestmentDay> getAllInvestmentDaysInAPeriodOfTime(Dictionary<DateTime, InvestmentDay> dates)
        {
            List<InvestmentDay> investmentDays = new List<InvestmentDay>();

            try
            {
                DateTime firstDate = dates.Keys.Last();
                DateTime lastDate = dates.Keys.First();

                for (DateTime i = firstDate; i < lastDate; i = i.AddMonths(1))
                {
                    DateTime investDay = CalendarChecker.getLastThursday(i.Month, i.Year).AddDays(1);

                    while (!dates.ContainsKey(investDay) && investDay < lastDate) investDay = investDay.AddDays(1);

                    if (investDay < lastDate && investDay > firstDate)
                    {
                        investmentDays.Add(dates[investDay]);
                        Console.WriteLine(dates[investDay]);
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (InvalidOperationException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                throw;
            }

            return investmentDays;
        }

    }
}
