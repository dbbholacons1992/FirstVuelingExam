using FirstVuelingExam.Common.Library.Utils;
using FirstVuelingExam.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstVuelingExam.Presentation.Console
{
    using FirstVuelingExam.Common.Library.Models;
    using System;
    using System.Globalization;

    public class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            Dictionary<DateTime, InvestmentDay> allDays = repository.getAllInvestmentDays();

            List<InvestmentDay> investmentDays = repository.getAllInvestmentDaysInAPeriodOfTime(allDays);

            decimal totalStocks = Calculator.calculateTotalStocks(investmentDays, (decimal)50.0, 2);

            Console.WriteLine(new StringBuilder().Append("Total amount: ")
               .Append(Calculator.calculateMoneyWhenSellStocks(totalStocks, allDays[allDays.Keys.First()])));


        }
    }
}
