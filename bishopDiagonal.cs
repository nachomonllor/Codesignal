
//https://app.codesignal.com/arcade/code-arcade/chess-tavern/wGLCfzpdcA2o9kSpD

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {

        static string[] bishopDiagonal(string bishop1, string bishop2)
        {

            char letrab1 = bishop1[0];
            int numb1 = int.Parse(bishop1[1].ToString());

            char letrab2 = bishop2[0];
            int numb2 = int.Parse(bishop2[1].ToString());

            if (Math.Abs(letrab1 - letrab2) == Math.Abs(numb1 - numb2))
            {
                if (letrab1 > letrab2)
                {
                    char temp = letrab1;
                    letrab1 = letrab2;
                    letrab2 = temp;

                    int tempint = numb1;
                    numb1 = numb2;
                    numb2 = tempint;
                }

                if (numb1 > numb2)
                {
                    while (letrab1 > 'a' && numb1 < 8)
                    {
                        letrab1--;
                        numb1++;
                    }

                    while (letrab2 < 'h' && numb2 > 1)
                    {
                        letrab2++;
                        numb2--;
                    }
                }
                else if (numb2 > numb1)
                {
                    while (letrab1 < 'h' && numb1 < 8)
                    {
                        letrab1++;
                        numb1++;
                    }
                    while (letrab2 > 'a' && numb2 > 1)
                    {
                        letrab2--;
                        numb2--;
                    }

                }

                


            }

            string a = letrab1 + "" + numb1;
            string b = letrab2 + "" + numb2;

            List<string> lista = new List<string>(new string[] { a, b });
            lista.Sort();
            return lista.ToArray();


        }





        static void Main(string[] args)
        {

           // string bishop1 = "d8" ;
           // string bishop2 = "b5";

            //string bishop1 = "d7";
            //string bishop2 = "f5"; //["c8", "h3"]

            //string bishop1 = "b2";
            //string bishop2 = "g7";


            //string bishop1 = "c6";
            //string bishop2 = "f3";


            //string bishop1 = "d4";
            //string bishop2 = "d5";

            //string bishop1 = "c4";
            //string bishop2 = "f4";


            //string bishop1= "h1";
            //string bishop2 = "a1"; //["a1", "h1"]


            //string bishop1 = "b4";
            //string bishop2 = "e7";  //["a3",  "f8"]

            string bishop1 = "g3";
            string bishop2 = "e1"; //["e1",  "h4"]


            string[] r = bishopDiagonal(bishop1, bishop2);

            Console.WriteLine(r[0] + " " + r[1]);



            Console.ReadLine();
        }
    }
}
