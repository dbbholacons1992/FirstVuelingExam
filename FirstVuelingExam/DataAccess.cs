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


        public static string getLastLineDate()
        {
            var lastLine = File.ReadLines(path).Last();

            return lastLine;
            
        }

        public static string getFirstLineDate()
        {
            var firstLine = from lines in File.ReadLines(path)
                           where lines.Split(';')[0].Split('-').Length > 1
                           select lines;

            return firstLine.First();
        }

        public static DateTime getDateFromLine(string line)
        {

            var cellsValues = line.Split(';');
            var dateValues = cellsValues[0].Split('-');

            

            return new DateTime(Int32.Parse(dateValues[2]),
                        CalendarChecker.getNumOfMonthEsp(dateValues[1]),
                        Int32.Parse(dateValues[0]));
        }

    }
}
