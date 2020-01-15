https://codefights.com/challenge/nvtxYJxqALFrPf3GF/main?utm_source=featuredChallenge&utm_medium=email&utm_campaign=email_notification
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static string alphaChange(string s)
        {
            string num = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsNumber(s[i]))
                {
                    num += s[i];
                }
            }
            int desp = int.Parse(num);

            string min = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";
            string may = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (desp > 26)
            {
                desp = desp % 26;
            }

            string ans = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    if (char.IsLower(s[i]))
                    {
                        //ans += min[min.IndexOf(s[i]) + desp];

                        int indalfab = min.IndexOf(s[i]);
                        ans += min[indalfab + desp].ToString();

                    }
                    else
                    {
                        ans += may[may.IndexOf(s[i]) + desp];
                    }
                }
            }

            //Console.WriteLine(ans);
            return ans;

        }

        static void Main(string[] args)
        {

            string s = "1337Guy";
            Console.WriteLine( alphaChange(s));

            Console.ReadLine();
        }
    }
}
