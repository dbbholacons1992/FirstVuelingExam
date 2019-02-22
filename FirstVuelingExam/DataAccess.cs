using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstVuelingExam
{
    public class DataAccess
    {
        private readonly static string path = ConfigurationManager.AppSettings.Get("csvPath");

        public Dictionary<DateTime, DayInvestmentCost> dayInvestmentCosts;

        public string getLastLineDate()
        {
            var lastLine = File.ReadLines(path).Last();

            return lastLine;
            
        }

        public string getFirstLineDate()
        {
            var firstLine = from lines in File.ReadLines(path)
                           where lines.Split(';')[0].Split('-').Length > 1
                           select lines;

            return firstLine.First();
        }

        public DateTime getDateFromLine(string line)
        {

            var cellsValues = line.Split(';');
            var dateValues = cellsValues[0].Split('-');

            

            return new DateTime(Int32.Parse(dateValues[2]),
                        CalendarChecker.getNumOfMonthEsp(dateValues[1]),
                        Int32.Parse(dateValues[0]));
        }

        public void storeAllDayInvestementValues()
        {
            dayInvestmentCosts = new Dictionary<DateTime, DayInvestmentCost>();

            var validLines = from lines in File.ReadLines(path)
                            where lines.Split(';')[0].Split('-').Length > 1
                            select lines;

            foreach(string l in validLines)
            {
                DateTime d = getDateFromLine(l);

                var lineValues = l.Split(';');

                dayInvestmentCosts.Add(d, 
                    new DayInvestmentCost(d, 
                                decimal.Parse(lineValues[1].Replace('.', ',')), 
                                decimal.Parse(lineValues[2].Replace('.', ','))));
            }
        }

        public decimal getOpenValueForInvestment(DateTime d)
        {
            decimal openValue;
            try
            {
                DayInvestmentCost dInvestCost = dayInvestmentCosts[d];

               
                openValue = dInvestCost.OpenValue;
                
                
            }
            catch (KeyNotFoundException e)
            {

                openValue = getOpenValueForInvestment(d.AddDays(1));
            }

            return openValue;
        }




    }
}
