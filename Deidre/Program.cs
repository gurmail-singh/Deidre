using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

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
            string inputFile = @"\schedule2.txt";
            StreamReader sr = new StreamReader(inputFile);
            string strLine = "";
            //string sPattern =@"(?i)(MONDAY|TUESDAY|WEDNESDAY|THURSDAY|FRIDAY|SATURDAY|SUNDAY){1}\s\d{1,2}{1}(ND|TH|RD){1}\s(JANUARY|FEBRUARY|MARCH|APRIL|MAY|JUNE|JULY|AUGUST|SEPTEMBER|OCTOBER|NOVEMBER|DECEMBER){1}";
            //string sPattern = @"(?i)(MONDAY|TUESDAY|WEDNESDAY|THURSDAY|FRIDAY|SATURDAY|SUNDAY)";
            string sPattern = @"(?i)(MONDAY|TUESDAY|WEDNESDAY|THURSDAY|FRIDAY|SATURDAY|SUNDAY){1}\s(\d{1,2}){1}(ND|TH|RD){1}\s(JANUARY|FEBRUARY|MARCH|APRIL|MAY|JUNE|JULY|AUGUST|SEPTEMBER|OCTOBER|NOVEMBER|DECEMBER){1}";
            while ((strLine = sr.ReadLine()) != null)
            {
                Match match = Regex.Match(strLine, sPattern);
                if (match.Success)                
                //Console.WriteLine(strLine);
                //if (System.Text.RegularExpressions.Regex.IsMatch(strLine, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    System.Console.WriteLine("Found" + strLine);
                    System.Console.WriteLine("match found {0}'", match.Value);
                    //1Will  help you?			09067 577 162	S20
                    string prnPattern = @"(?i)(\d{5})\(sd{3})\s(d{3})\s(wd{2})";
                    for(int i=0; i<5; i++) 
                    {
                        strLine = sr.ReadLine();
                        Match match = Regex.Match(strLine, prnPattern);
                        if (match.Success)
                        {
                        string prnVlaue = 
                        }
                    }
                

                    break;
                }
                else
                {
                    System.Console.WriteLine("NOT Found" + strLine);
                }
            }
            //(?i)(MONDAY|TUESDAY|WEDNESDAY|THURSDAY|FRIDAY|SATURDAY|SUNDAY){1}\s\d{1,2}{1}(ND|TH|RD){1}\s(JANUARY|FEBRUARY|MARCH|APRIL|MAY|JUNE|JULY|AUGUST|SEPTEMBER|OCTOBER|NOVEMBER|DECEMBER){1}
            //Cleanup
            sr.Close();
        }  
    }
}
