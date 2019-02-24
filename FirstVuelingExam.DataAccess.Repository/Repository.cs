﻿using FirstVuelingExam.Common.Library.Models;
using FirstVuelingExam.Common.Library.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstVuelingExam.DataAccess.Repository
{
    public class Repository
    {
        private readonly static string path = ConfigurationManager.AppSettings.Get("csvPath");


        public DateTime getDateFromLine(string line)
        {
            return DateTime.ParseExact(line, "dd-MMM-yyyy", 
                                    CultureInfo.CreateSpecificCulture("es-US"));
        }

        public Dictionary<DateTime, InvestmentDay> getAllInvestmentDays()
        {
            Dictionary<DateTime, InvestmentDay> allDays = new Dictionary<DateTime, InvestmentDay>();

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

            return allDays;
        }

        public List<InvestmentDay> getAllInvestmentDaysInAPeriodOfTime(Dictionary<DateTime, InvestmentDay> dates)
        {
            List<InvestmentDay> investmentDays = new List<InvestmentDay>();
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

            return investmentDays;
        }

    }
}
