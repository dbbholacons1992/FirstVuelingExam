using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstVuelingExam
{
    public class DataAccess
    {
        private readonly static string path = ConfigurationManager.AppSettings.Get("csvPath");


        public static void readFile()
        {
            using(StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    var fileLine = sr.ReadLine();
                    var cellsValues = fileLine.Split(';');




                }
            }
        }

    }
}
