https://codefights.com/challenge/voGgdjsd3nepQfyR5/main
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static int bigSmall(int[] nums)
        {
            Array.Sort(nums);

            for (int i = 1; i < nums.Length; i++)
            {
                string a = nums[i-1].ToString();
                string b = nums[i].ToString();

                int lena = a.Length;
                int lenb = b.Length;

                if (a[0] == '-')
                {
                    lena--;
                }
                if (b[0] == '-')
                {
                    lenb--;
                }

                if (lenb > lena)
                {
                    return int.Parse(a);
                     
                }
            }
            return nums[nums.Length - 1];
        }



int bigSmall(int[] nums)
        {
            int minmax = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int lena=Math.Abs(nums[i]).ToString().Length ;
                int lenb = Math.Abs(minmax).ToString().Length;
                if (lena < lenb)
                {
                    minmax = nums[i];
                }
                else if (lena == lenb)
                {
                    if (nums[i] > minmax)
                    {
                        minmax = nums[i];
                    }
                }
            }

            return minmax;
        }



        static void Main(string[] args)
        {

            int[] nums = {6456, 5193, 2883, -1173, 2904, 547, -991, -1453, -1803, 8898, 2626, 6982, -9131, 7032, -5333, 4743, 7989, 4348, -9595, -248, -81, 8454, 2957, 8597, 2869, 7751, 8015, -7558, 3129, -6461, 7789, -2383, -1905, -884, -2632, -2740, 4010, -6884, -8254, 9403, 9315, -5745, -2742, 667, 2745, 7962, 6550, 1308, 6098, -6772, -1281, -5396, 6687, 1919, -7162, -1499, 5181, 9019, -6076, -2736, -3336, -888, -480, 5141, 1546, -915, 6073, -8511, -5375, -2038, -2749, -1167, -7617, -1266, -7633, 3105, 731, 7830, 2146, 1004, 4580, -9533, -1241, -2497, 1510, -3626, 9857, -5954, 9733, 9483, -5159, -686, -3386, 6800, -4298, -8146, 7150, 9888, 3274, 8029};

            Console.WriteLine(bigSmall(nums));


            //Console.WriteLine(a.Length);

            Console.ReadLine();

        }
    }
}
