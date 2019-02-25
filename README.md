# FirstVuelingExam

This code reads a cvs file with the Zara stock prices between 23/05/2001

![FirstVuelingExam Result](https://github.com/dbbholacons1992/FirstVuelingExam/blob/master/FirstVuelingExam%20Result.gif)

To solve the problem I divided the project in 5 classes:

### Calculator (CommonTier)

This is a static class that contains methods to calculate stocks and values of investments. There are used by the Main class to do calculations and get the final value for the stocks sell.

![CalculateMoneyWhenSellStocks](https://github.com/dbbholacons1992/FirstVuelingExam/blob/master/README%20images/CalculateMoneyWhenSellStocks.JPG)

![CalculateRealInvestment](https://github.com/dbbholacons1992/FirstVuelingExam/blob/master/README%20images/CalculateRealInvestment%20Method.JPG)

![CalculateStocks](https://github.com/dbbholacons1992/FirstVuelingExam/blob/master/README%20images/CalculateStocksMethod.JPG)

![CalculateTotalStocks](https://github.com/dbbholacons1992/FirstVuelingExam/blob/master/README%20images/CalculateTotalStocks%20Method.JPG)


### CalendarChecker (CommonTier)

This is a static class that works for get the last Thursday of a month and get all the investment days given a range of days.

### InvestmentDay (CommonTier)

This class have only three variables, a DateTime object and two decimal values that correspond to the openValue and the closeValue for the day of the DateTime object. We use objects of this class to store all the days we read from de cvs file in a Diccionary, using de DateTime as a Key.

### Repository (DataAccesTier)

Resultado Final: 36585,568
