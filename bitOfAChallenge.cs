https://codefights.com/challenge/omLLfkTFQYJgpCe4o/solutions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static char bitOfAChallenge(int n)
        {
             return  (char) ( Convert.ToString(n, 2).Sum(e => e-'0') +64);
            
        }

        static void Main(string[] args)
        {

           Console.WriteLine( bitOfAChallenge(115));

            Console.ReadLine();
        }
    }
}
