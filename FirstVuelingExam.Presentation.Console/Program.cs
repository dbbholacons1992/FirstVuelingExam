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
    using System.IO;

    public class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection
                .MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            

            Repository repository = new Repository();

            try
            {
                Dictionary<DateTime, InvestmentDay> allDays = repository.getAllInvestmentDays();

                List<InvestmentDay> investmentDays = repository.getAllInvestmentDaysInAPeriodOfTime(allDays);

                decimal totalStocks = Calculator.calculateTotalStocks(investmentDays, (decimal)50.0, 2);

                Console.WriteLine(new StringBuilder().Append("Total amount: ")
                   .Append(Calculator.calculateMoneyWhenSellStocks(totalStocks, allDays[allDays.Keys.First()])));

            }
            catch (ArgumentNullException e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }
            catch (CultureNotFoundException e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                log.Error(e);
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException e)
            {
                log.Error(e);
                throw;
            }

        }
    }
}
