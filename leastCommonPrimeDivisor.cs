https://app.codesignal.com/challenge/no4rPwbXE3pH6ET5E
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {


        public static HashSet<int> primeFactors(int n)
        {
            HashSet<int> lista = new HashSet<int>();
            // Print the number of 2s that divide n 
            while (n % 2 == 0)
            {
                //Console.Write(2 + " ");
                lista.Add(2);
                n /= 2;
            }

            // n must be odd at this point. So we can 
            // skip one element (Note i = i +2) 
            for (int i = 3; i * i <= n; i += 2)
            {
                // While i divides n, print i and divide n 
                while (n % i == 0)
                {
                    //Console.Write(i + " ");
                    lista.Add(i);
                    n /= i;
                }
            }

            // This condition is to handle the case whien 
            // n is a prime number greater than 2 
            if (n > 2)
            {
                //Console.Write(n);
                lista.Add(n);
            }
            return lista;
        }

        static int leastCommonPrimeDivisor(int a, int b)
        {
            HashSet<int> pfa = primeFactors(a);
            HashSet<int> pfb = primeFactors(b);

            foreach(int item in pfa)
            {
                if(pfb.Contains(item) )
                {
                    return item;
                }
            }

            return -1;

        }

        static void Main(string[] args)
        {

            //int t = int.Parse(Console.ReadLine().Trim());

            //while (t-- > 0)
            //{

            //}

            //string[] input =
            //{
            //  "010101010",
            //  "101010101",
            //  "010101010",
            //  "101010101",
            //  "010101010",
            //  "101010101",
            //  "010101010",
            //  "101010101",
            //  "010101010"
            //};

            Console.WriteLine(leastCommonPrimeDivisor(12, 13));


            Console.ReadLine();
        }

    }

}
