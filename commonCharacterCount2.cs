//https://app.codesignal.com/challenge/6XfqSQgXsWDct3fuE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication17
{
    class Program
    {
        static int commonCharacterCount2(string[] s)
        {
            List<int[]> lista_frecuencias = new List<int[]>();

            for (int i = 0; i < s.Length; i++)
            {
                int[] frec = new int[26];
                for (int j = 0; j < s[i].Length; j++)
                {
                    frec[s[i][j] - 'a']++;
                }

                lista_frecuencias.Add(frec);
            }


            int ans = 0; 
            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                int min_actual = int.MaxValue;
                foreach (int[] f in lista_frecuencias)
                {
                    

                    min_actual = Math.Min(min_actual, f[ch - 'a']);
                }
                ans += min_actual;
            }
            return ans;
        }

        static void Main(string[] args)
        {
            string[] s =
             new  string[] {"aabcc", 
                 "adcaa", 
                 "acdba"};


            Console.WriteLine(commonCharacterCount2(s));

            Console.ReadLine();
        }

    }
}
