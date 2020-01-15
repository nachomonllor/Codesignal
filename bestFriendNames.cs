https://codefights.com/challenge/RTHN8Lgek9PTyPRBX/solutions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {

        static bool bestFriendNames(string name1, string name2)
        {
            name1 = name1.ToLower();
            name2 = name2.ToLower();
            int s1 = 0;
            for (int i = 0; i < name1.Length; i++)
            {
                if (name1[i] != ' ')
                {
                    s1 += name1[i] - 96;
                }
            }
            int s2 = 0;
            for (int i = 0; i < name2.Length; i++)
            {
                if (name2[i] != ' ')
                {
                    s2 += name2[i] - 96;
                }
            }

            return s1 == s2;
        }

        static void Main(string[] args)
        {
            bestFriendNames("diego","juan");


            Console.ReadLine();
        }
    }
}
