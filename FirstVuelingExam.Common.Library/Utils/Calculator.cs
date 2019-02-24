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

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection
                .MethodBase.GetCurrentMethod().DeclaringType);

        public static decimal calculateStocks(decimal price, decimal investment)
        {
            decimal stocks;

            try
            {
                stocks = decimal.Round(investment / price, 3);
            }
            catch (DivideByZeroException e)
            {
                log.Error(e);
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                log.Error(e);
                throw;
            }

            return stocks; 
        }

        public static decimal calculateRealInvestment(decimal investment, decimal commissionPercentage)
        {
            decimal realInvestment;

            try
            {
                realInvestment = investment - decimal.Round((investment * (commissionPercentage / 100)), 3);
            }
            catch (DivideByZeroException e)
            {
                log.Error(e);
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                log.Error(e);
                throw;
            }

            return realInvestment;
        }

        public static decimal calculateTotalStocks(List<InvestmentDay> investmentDates, decimal periodicInvestment, decimal commissionPercentage)
        {
            decimal totalStocks = 0;

            try
            {
                decimal realInvestment = calculateRealInvestment(periodicInvestment, commissionPercentage);

                foreach (InvestmentDay d in investmentDates)
                {
                    totalStocks = totalStocks + calculateStocks(d.OpenValue, realInvestment);

                }
            }
            catch (DivideByZeroException e)
            {
                log.Error(e);
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                log.Error(e);
                throw;
            }

            return totalStocks;
        }

        public static decimal calculateMoneyWhenSellStocks(decimal stocks, InvestmentDay day)
        {
            decimal showMeTheMoney;
            decimal closePrice = day.CloseValue;

            try
            {
                showMeTheMoney = decimal.Round(closePrice * stocks, 3);
            }
            catch (ArgumentOutOfRangeException e)
            {
                log.Error(e);
                throw;
            }

            return showMeTheMoney;
        }

    }
}
