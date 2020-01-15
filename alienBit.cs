https://codefights.com/challenge/aEPJbWzkSjEuuH3cH?utm_source=emailNotification&utm_medium=email&utm_campaign=featuredChallenge
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {

        static string alienBit(string abit)
        {
            string s = abit.Substring(abit.IndexOf('.') + 1);

            string res = "";
            for (int i = 0; i < s.Length; i += 3)
            {
                string bit = s.Substring(i, 3);
                //Console.WriteLine(bit);
                res += (char) int.Parse(bit);
            }

            return res;
        }

        static void Main(string[] args)
        {
            string abit = "0.116101115116035049";

            Console.WriteLine( alienBit(abit));

            Console.ReadLine();
        }

    }
}


