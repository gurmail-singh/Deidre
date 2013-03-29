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
            //string inputFile = @"C:\Users\Urban\Documents\schedule2.txt";
            string inputFile = @"C:\Users\Urban\Downloads\Deidre's Helplines - 14-20 March 2013.txt";
            StreamReader sr = new StreamReader(inputFile);
            string strLine = "";
            //string sPattern =@"(?i)(MONDAY|TUESDAY|WEDNESDAY|THURSDAY|FRIDAY|SATURDAY|SUNDAY){1}\s\d{1,2}{1}(ND|TH|RD){1}\s(JANUARY|FEBRUARY|MARCH|APRIL|MAY|JUNE|JULY|AUGUST|SEPTEMBER|OCTOBER|NOVEMBER|DECEMBER){1}";
            //string sPattern = @"(?i)(MONDAY|TUESDAY|WEDNESDAY|THURSDAY|FRIDAY|SATURDAY|SUNDAY)";
            string sPattern = @"(?i)(MONDAY|TUESDAY|WEDNESDAY|THURSDAY|FRIDAY|SATURDAY|SUNDAY){1}\s(\d{1,2}){1}(ND|TH|RD){1}\s(JANUARY|FEBRUARY|MARCH|APRIL|MAY|JUNE|JULY|AUGUST|SEPTEMBER|OCTOBER|NOVEMBER|DECEMBER){1}";
            while ((strLine = sr.ReadLine()) != null)
            {
                Match dateMatch = Regex.Match(strLine, sPattern);
                if (dateMatch.Success)             
                {
                    //we got a date match, so convert the date into a useaable form - remove "th" or "rd" and then convert
                   
                    string dateStr = dateMatch.Groups[1].Value + " " + dateMatch.Groups[2].Value + " " + dateMatch.Groups[4].Value;
                    
                  
                    System.Console.WriteLine(dateStr);
                    DateTime dateTimeStr;

                    dateTimeStr = Convert.ToDateTime(dateStr);
                    dateStr = dateTimeStr.ToString("YYYYMMDD");
            

                    System.Console.WriteLine("Found" + strLine);
                    System.Console.WriteLine("match found {0}'", dateMatch.Value);
                    //1Will  help you?			09067 577 162	S20
                    string prnPattern = @"(?i)(\d{5})\s+(\d{3})\s+(\d{3})\s+(\w\d{2})";
                    //string prnPattern = @"(?i)(\d{5})";
                    for(int i=0; i<5; i++) 
                    {
                        strLine = sr.ReadLine();
                        System.Console.WriteLine("nextline= " + strLine);                        
                        Match match = Regex.Match(strLine, prnPattern);
                        System.Console.WriteLine("Match= " + match.Value);
                        
                        if (match.Success)
                        {
                           string PRN = match.Groups[1].Value + match.Groups[2].Value + match.Groups[3].Value;
                           string promptToPlay = match.Groups[4].Value;
                           System.Console.WriteLine(dateStr);
                           System.Console.WriteLine("PRN = " + PRN);
                           System.Console.WriteLine("Prompt = " + promptToPlay); 
                        }
                    }                
                }
                else
                {
                    System.Console.WriteLine("NOT Found" + strLine);
                }
            }
            //(?i)(MONDAY|TUESDAY|WEDNESDAY|THURSDAY|FRIDAY|SATURDAY|SUNDAY){1}\s\d{1,2}{1}(ND|TH|RD){1}\s(JANUARY|FEBRUARY|MARCH|APRIL|MAY|JUNE|JULY|AUGUST|SEPTEMBER|OCTOBER|NOVEMBER|DECEMBER){1}
            //Cleanup
            sr.Close();
            System.Console.ReadLine();

        }  
    }
}
