using FirstVuelingExam.Common.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFramework.VuelingLogs;

namespace FirstVuelingExam.Common.Library.Utils
{
    public static class Calculator
    {
        private static readonly IVuelingLogger log = new SerilogLogger();



        /// <summary>
        /// Calculate the stocks given a <paramref name="price"/> and 
        /// a <paramref name="investment"/> import
        /// </summary>
        /// <param name="price">A decimal number</param>
        /// <param name="investment">A decimal number</param>
        /// <returns>The number of stocks result of an investment</returns>
        /// <exception cref="System.DivideByZeroException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static decimal calculateStocks(decimal price, decimal investment)
        {
            decimal stocks;

            try
            {
                stocks = decimal.Round(investment / price, 3);
            }
            catch (DivideByZeroException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                log.Error(e.Message);
                throw;
            }

            return stocks; 
        }

        /// <summary>
        /// Calculate the real investment subtracting the commission percentage
        /// </summary>
        /// <param name="investment">A decimal number</param>
        /// <param name="commissionPercentage">A decimal number bigger than 0 and smaller than 100</param>
        /// <returns>The real invested amount</returns>
        /// <exception cref="DivideByZeroException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static decimal calculateRealInvestment(decimal investment, decimal commissionPercentage)
        {
            decimal realInvestment;

            try
            {
                realInvestment = investment - decimal.Round((investment * (commissionPercentage / 100)), 3);
            }
            catch (DivideByZeroException e)
            {
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                log.Error(e.Message);
                throw;
            }

            return realInvestment;
        }

        /// <summary>
        /// Returns the total amount of stocks given a <paramref name="investmentDates"/>,
        /// a <paramref name="periodicInvestment"/> and the broker <paramref name="commissionPercentage"/>
        /// </summary>
        /// <param name="investmentDates">List of InvestmentDay objects</param>
        /// <param name="periodicInvestment">A decimal number</param>
        /// <param name="commissionPercentage">A decimal number</param>
        /// <returns>The total amount of stocks result of regular investments</returns>
        /// <exception cref="DivideByZeroException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static decimal calculateTotalStocks(List<InvestmentDay> investmentDates, 
            decimal periodicInvestment, decimal commissionPercentage)
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
                log.Error(e.Message);
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                log.Error(e.Message);
                throw;
            }

            return totalStocks;
        }

        /// <summary>
        /// Calculate the total amount of money that results to sell <paramref name="stocks"/>
        /// </summary>
        /// <param name="stocks">A decimal number</param>
        /// <param name="day">The day of the sell</param>
        /// <returns>The amount result of a stocks sell</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
                log.Error(e.Message);
                throw;
            }

            return showMeTheMoney;
        }

    }
}
