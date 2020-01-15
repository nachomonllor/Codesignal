https://codefights.com/challenge/M8cR5yNub3PrwXkkp?utm_source=featuredChallenge&utm_medium=email&utm_campaign=email_notification
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
       static  int betaExor(string s)
        {
            int xor = 0;

            foreach (char ch in s)
            {
                xor ^= ch;
            }
            return xor;
        }

        static void Main(string[] args)
        {

            string s = "AAbbb";

            int xor = 0;

            foreach (char ch in s)
            {
                xor ^= ch;
            }

            Console.WriteLine(xor);

            Console.ReadLine();

        }
    }
}
