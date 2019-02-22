using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstVuelingExam
{
    public class DayInvestmentCost
    {
        DateTime Date;
        public decimal CloseValue;
        public decimal OpenValue;
        

        public DayInvestmentCost(DateTime date, decimal closeValue, decimal openValue)
        {
            this.Date = date;
            this.CloseValue = closeValue;
            this.OpenValue = openValue;
            
        }

        public override string ToString()
        {
            return new StringBuilder().Append(Date).Append(" CloseValue: ").
                                    Append(CloseValue).Append(" OpenValue: ").
                                    Append(OpenValue).ToString();
        }

        public override bool Equals(object obj)
        {
            var cost = obj as DayInvestmentCost;
            return cost != null &&
                   Date == cost.Date &&
                   CloseValue == cost.CloseValue &&
                   OpenValue == cost.OpenValue;
        }

        public override int GetHashCode()
        {
            var hashCode = 1101159711;
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + CloseValue.GetHashCode();
            hashCode = hashCode * -1521134295 + OpenValue.GetHashCode();
            return hashCode;
        }
    }
}
