using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = System.IO.File.ReadAllText("D:/SKLAB/SKLAB.Admin.UI/LSY040.cs");
            System.IO.File.WriteAllBytes("D:/1.xml", Encoding.UTF8.GetBytes(str));
            string pattern = Regex.Escape("\"") + "(.*?)\"";
            MatchCollection matches = Regex.Matches(str, pattern);
            int commentNumber = 0;

            System.Text.Encoding originalEncoding = System.Text.Encoding.GetEncoding(1252);
            System.Text.Encoding euckr = System.Text.Encoding.GetEncoding(949);

            foreach (Match match in matches)
            {
                //Console.OutputEncoding = Encoding.GetEncoding("EUC-KR");

                byte[] rawbytes = originalEncoding.GetBytes(match.Value.ToString());
                string s = euckr.GetString(rawbytes);
                Console.WriteLine("   {0}: {1}", ++commentNumber, s);
                
            }
            Console.ReadLine();
        }
    }
}
