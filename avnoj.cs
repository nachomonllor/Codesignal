https://codefights.com/challenge/W6T3GMzsmYcy3FrBL/main
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {

        public static bool nextPermutation(char[] array)
        {
            // Find non-increasing suffix
            int i = array.Length - 1;
            while (i > 0 && array[i - 1] >= array[i])
                i--;
            if (i <= 0)
                return false;

            // Find successor to pivot
            int j = array.Length - 1;
            while (array[j] <= array[i - 1])
                j--;
            char temp = array[i - 1];
            array[i - 1] = array[j];
            array[j] = temp;

            // Reverse suffix
            j = array.Length - 1;


            while (i < j)
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
            return true;
        }


        static int avnoj(int n)
        {
            char[] num = n.ToString().ToCharArray();
            Array.Sort(num);

            int max = -1;

            while (nextPermutation(num))
            {
                //Console.WriteLine(new string(num));
                if (int.Parse(new string(num)) % 30 == 0)
                {
                    max = Math.Max(max, int.Parse(new string(num)));
                }
            }
 

            return max;
        }

        static void Main(string[] args)
        {

            Console.WriteLine(avnoj(1011));

            Console.ReadLine();

        }
    }
}
