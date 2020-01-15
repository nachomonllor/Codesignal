https://app.codesignal.com/arcade/code-arcade/mirror-lake/BLbGNY3kEcvKjBCFC/solutions
using System;
using System.Collections.Generic;

using System.Text;


namespace ConsoleApp12
{
    class Program
    {

        static string obtenerDivisores(int[] divisores, int n)
        {
            string div = "";
            for (int i = 0; i < divisores.Length; i++)
            {
                if (n % divisores[i] != 0)
                {
                    div += divisores[i].ToString();
                    //return false;
                }
            }
            return div;
        }

        static int numberOfClans(int[] divisors, int k)
        {
            Dictionary<string, int> clanes = new Dictionary<string, int>();
            for (int i = 1; i <= k; i++)
            {
                string divs = obtenerDivisores(divisors,i);

                if (clanes.ContainsKey(divs))
                {
                    clanes[divs]++;
                }
                else
                {
                    clanes[divs] = 1;
                }

            }
            return clanes.Count;
        }

        static void Main(string[] args)
        {

            int[] divisors = {2, 3};
            int k = 6;

            Console.WriteLine(numberOfClans(divisors, k));



            Console.ReadLine();
        }
    }
}
