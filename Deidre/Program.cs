using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Deidre
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime currentDate = DateTime.Now;
            string dateStr = "Monday 18th March " + currentDate.Year;

            dateStr =dateStr.Replace("th", "");
            dateStr =dateStr.Replace("rd", "");

            DateTime dateTimeStr = Convert.ToDateTime(dateStr);
            dateTimeStr.ToString("YYYYMMDD");
            Console.WriteLine(dateTimeStr);
            Console.WriteLine(dateTimeStr.ToString("yyyyMMdd"));
            string inputFile = @"\schedule.txt";
            StreamReader sr = new StreamReader(inputFile);
            string strLine = "";
            while ((strLine = sr.ReadLine()) != null)
            {
                Console.WriteLine(strLine);

            }
            //(?i)(MONDAY|TUESDAY|WEDNESDAY|THURSDAY|FRIDAY|SATURDAY|SUNDAY){1}\s\d{1,2}{1}(ND|TH|RD){1}\s(JANUARY|FEBRUARY|MARCH|APRIL|MAY|JUNE|JULY|AUGUST|SEPTEMBER|OCTOBER|NOVEMBER|DECEMBER){1}
            //Cleanup
            sr.Close();

            *

        }  
    }
}
