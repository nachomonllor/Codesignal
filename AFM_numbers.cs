https://codefights.com/challenge/T6G5FmTpmM6rfd8id?utm_source=emailNotification&utm_medium=email&utm_campaign=featuredChallenge

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {


       static int[] AFM_numbers(int bits)
        {
            string a = "";
            string b = "";

            for (int i = 0; i < bits; i++)
            {
                if (i % 2 == 0)
                {
                    a += '1';
                    b += '0'; 
                }
                else
                {
                    a += '0';
                    b += '1';
                }
            }

            return new int[] { Convert.ToInt32(b,2), Convert.ToInt32(a,2) };

        }


        static void Main(string[] args)
        {

            int n = 3;

            foreach (int elem in AFM_numbers(3))
            {
                Console.Write(elem + " ");
            }

            Console.ReadLine();

        }
    }
}
