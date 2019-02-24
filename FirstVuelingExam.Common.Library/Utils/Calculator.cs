using FirstVuelingExam.Common.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstVuelingExam.Common.Library.Utils
{
    public static class Calculator
    {

        public static decimal calculateStocks(decimal price, decimal investment)
        {
            return decimal.Round(investment / price, 3);
        }

        public static decimal calculateRealInvestment(decimal investment, decimal commissionPercentage)
        {
            return investment - decimal.Round((investment * (commissionPercentage / 100)), 3);
        }

        public static decimal calculateTotalStocks(List<InvestmentDay> investmentDates, decimal periodicInvestment, decimal commissionPercentage)
        {
            decimal totalStocks = 0;
            decimal realInvestment = calculateRealInvestment(periodicInvestment, commissionPercentage);

            foreach(InvestmentDay d in investmentDates)
            {
                totalStocks = totalStocks + calculateStocks(d.OpenValue, realInvestment);

            }

            return totalStocks;
        }

        public static decimal calculateMoneyWhenSellStocks(decimal stocks, InvestmentDay day)
        {
            decimal showMeTheMoney;
            decimal closePrice = day.CloseValue;

            showMeTheMoney = decimal.Round(closePrice * stocks, 3);

            return showMeTheMoney;
        }

    }
}
