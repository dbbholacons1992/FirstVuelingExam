using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstVuelingExam
{
    public class Calculator
    {
        DataAccess DAccess;

        public Calculator(DataAccess dAcces)
        {
            this.DAccess = dAcces;
        }

        public decimal calculateStocks(decimal price, decimal investment)
        {
            return decimal.Round(investment / price, 3);
        }

        public decimal calculateTotalStocks(List<DateTime> investmentDates, decimal periodicInvestment, decimal percentageOfCommission)
        {
            decimal totalStocks = 0;
            decimal realInvestment = periodicInvestment - decimal.Round((periodicInvestment * (percentageOfCommission / 100)), 3);

            foreach(DateTime d in investmentDates)
            {
                totalStocks = totalStocks + calculateStocks(DAccess.getOpenValueForInvestment(d), realInvestment);

            }

            return totalStocks;
        }

        public decimal calculateMoneyWhenSellStocks(decimal stocks, DateTime day)
        {
            decimal showMeTheMoney;
            decimal closePrice = DAccess.dayInvestmentCosts[day].CloseValue;

            showMeTheMoney = decimal.Round(closePrice * stocks, 3);

            return showMeTheMoney;
        }

    }
}
