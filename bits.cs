https://codefights.com/challenge/BiEcfpJAevtSMXAaQ?utm_source=emailNotification&utm_medium=email&utm_campaign=featuredChallenge
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {

        static long[] bits(long[] numbers)
        {
            List<long> ans = new List<long>();

            foreach (long elem in numbers)
            {
                char[] bin = Convert.ToString( elem,2).ToCharArray();
                //Console.WriteLine(bin);
                int indiceCero = Array.IndexOf(bin, '0');
                int indiceUno = Array.LastIndexOf(bin, '1');

                if (indiceCero != -1 && indiceUno != -1)
                {
                    bin[indiceCero] = '1';
                    bin[indiceUno] = '0';
                }
               ans.Add(Math.Max(elem, Convert.ToInt64(new string(bin),2 )));
            }
            return ans.ToArray();
        }

        static void Main(string[] args)
        {
            //long[] numbers = { 1, 5, 9 };

            long[] numbers = { 1, 5, 6, 9 };

            foreach (long elem in bits(numbers))
            {
                Console.Write(elem + " ");
            }

            Console.ReadLine();
        }
    }
}

