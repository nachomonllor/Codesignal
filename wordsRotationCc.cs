https://codefights.com/challenge/c6TgF2asHrFEN8X3Z?utm_source=emailNotification&utm_medium=email&utm_campaign=featuredChallenge
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {


        static string[] wordsRotationCc(string[] words)
        {
            char[,] rotado = new char[words[0].Length, words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[0].Length; j++)
                {
                    rotado[words[0].Length-1-j , i] = words[i][j];
                }
            }

            //for (int i = 0; i < rotado.GetLength(0); i++)
            //{
            //    for (int j = 0; j < rotado.GetLength(1); j++)
            //    {
            //        Console.Write(rotado[i, j] + "");
            //    }
            //    Console.WriteLine();
            //}
            List<string> res = new List<string>();

            for (int i = 0; i < rotado.GetLength(0); i++)
            {
                string fila = "";
                for (int j = 0; j < rotado.GetLength(1); j++)
                {
                    fila += rotado[i, j];
                }
                res.Add(fila);
            }
            return res.ToArray();
        }

        static void Main(string[] args)
        {
            string[] words = {   "apple", 
                                 "anger", 
                                 "monks", 
                                 "stink"};
                                 //["ersk", 
                                 // "lekn", 
                                 // "pgni", 
                                 // "pnot", 
                                 // "aams"]

            foreach (string elem in wordsRotationCc(words))
            {
                Console.WriteLine(elem);
            }


            Console.ReadLine();
        }
    }
}
