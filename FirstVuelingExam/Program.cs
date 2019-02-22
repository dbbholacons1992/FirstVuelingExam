using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstVuelingExam
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess DAcces = new DataAccess();
            Calculator calculator = new Calculator(DAcces);
            

            decimal totalStocks;

            List<DateTime> investmentDays =
                CalendarChecker.getAllInvestmentDaysInAPeriodOfTime(
                DAcces.getDateFromLine(DAcces.getLastLineDate()),
                DAcces.getDateFromLine(DAcces.getFirstLineDate()));

            DAcces.storeAllDayInvestementValues();

      

            totalStocks = calculator.calculateTotalStocks(investmentDays, (decimal)50.0, 2);

            Console.WriteLine(new StringBuilder().Append("Total amount: ")
                .Append(calculator.calculateMoneyWhenSellStocks(totalStocks,
                DAcces.getDateFromLine(DAcces.getFirstLineDate()))));
            
            

            

        }
    }
}
