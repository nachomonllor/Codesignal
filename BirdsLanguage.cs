https://codefights.com/challenge/we7jqYhFEKNMmYxpN/main?utm_source=challengeOfTheDay&utm_medium=email&utm_campaign=email_notification
nput:
word: "alex"
Output:
Empty
Expected Output:
"apalepex"
Console Output:
Empty

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {

       static  string BirdsLanguage(string word)
        {
            string vocales = "aeiuoAEIOU";
            string res = "";
            foreach (char ch in word)
            {
                if (vocales.Contains(ch))
                {
                    res += ch.ToString();
                    res += "p" + ch.ToString();
                }
                 else
                {
                    res += ch.ToString();
                }
            }
            return res;
        }

        static void Main(string[] args)
        {
            string res = BirdsLanguage("alex");
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}

