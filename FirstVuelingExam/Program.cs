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
            DataAccess dacces = new DataAccess();

            Console.WriteLine(DataAccess.getDateFromLine(DataAccess.getFirstLineDate()));
            Console.WriteLine(DataAccess.getDateFromLine(DataAccess.getLastLineDate()));

        }
    }
}
