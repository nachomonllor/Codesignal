https://codefights.com/challenge/4vzGyfNSicYAf75gC/main
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {

        string   Aaga(string s)
        {
            var diccio = new Dictionary<char, int>();

            foreach (char ch in s)
            {
                if (diccio.ContainsKey(ch))
                {
                    diccio[ch]++;
                }
                else
                {
                    diccio[ch] = 1;
                }
            }

            int impares = 0;
            foreach (KeyValuePair<char, int> kvp in diccio)
            {
                if (kvp.Value % 2 != 0)
                {
                    impares++;
                }
            }

            if (impares > 1)
            {
                return "False";
            }
            return "True";

        }


        static void Main(string[] args)
        {
        }
    }
}
