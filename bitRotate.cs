https://codefights.com/challenge/ct2vZTL8N4urXaaSa/solutions/TGRoLBuBeutxbPgq7
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static long bitRotate(long n, long r)
        {

            string bin = Convert.ToString(n, 2);

            for (int i = 0; bin.Length < 31; i++)
            {
                bin = '0' + bin;
            }

            r =   r % 31 ;
             
            //Console.WriteLine(bin.Length);

            string res = "";
           
            if (r >= 0)
            {
                string fin = bin.Substring((int) r);
                string ini = bin.Substring(0, (int) r);
                res = fin + ini;
            }
            else if(r < 0)
            {
                r *= -1;
                string derecha = bin.Substring(bin.Length - (int) r);
                string izq  = bin.Substring(0, bin.Length - (int)r);
                res = derecha + izq;
            }

            

            //Console.WriteLine(res);

            return Convert.ToInt64(res, 2); 
        }



        static void Main(string[] args)
        {

            //int r = -45;
            //Console.WriteLine(r % 31);

            //bitRotate(5, 1);
            //string s = "0000000000000000000000000000101";
            //Console.WriteLine(s.Length);

            //int n = 1073741825;
            //int r = -2;

            int n = 1073741825;
            int r = -2;

            // bitRotate(1073741825, -33) = 805306368
            //int n = 1;
            //int r = -1000000;

            Console.WriteLine(bitRotate(n, r));

            Console.ReadLine();
        }
    }
}

