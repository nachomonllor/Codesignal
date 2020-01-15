https://codefights.com/fight/2Le9tkAW7XR9ZgCAf/solutions

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    class Program
    {

        static bool bishopAndPawn(string bishop, string pawn)
        {
            //if (bishop[0] == pawn[0])
            //{
            //    return false;
            //}
            //string letras = "abcdefgh";
            //string num = "12345678";

            char letra_bishop = bishop[0];
            char num_bishop = bishop[1];

            char letra_pawn = pawn[0];
            char num_pawn = pawn[1];

            for( ; letra_bishop <= 'h'; letra_bishop++)
            {
                if(letra_bishop == letra_pawn && num_bishop == num_pawn)
                {
                    return true;
                }
                num_bishop++;
            }

             letra_bishop = bishop[0];
             num_bishop = bishop[1];
            for (; letra_bishop <= 'h'; letra_bishop++)
            {
                if (letra_bishop == letra_pawn && num_bishop == num_pawn)
                {
                    return true;
                }
                num_bishop--;
            }

             letra_bishop = bishop[0];
             num_bishop = bishop[1];
            for (; letra_bishop >= 'a'; letra_bishop--)
            {
                if (letra_bishop == letra_pawn && num_bishop == num_pawn)
                {
                    return true;
                }
                num_bishop++;
            }

             letra_bishop = bishop[0];
             num_bishop = bishop[1];
            for (; letra_bishop >='a'; letra_bishop--)
            {
                if (letra_bishop == letra_pawn && num_bishop == num_pawn)
                {
                    return true;
                }
                num_bishop--;
            }

            
            return false;
                 

        }


        static void Main(string[] args)
        {
            string bishop= "a5";
            string pawn= "c3";
            Console.WriteLine( bishopAndPawn(bishop, pawn) );

            Console.ReadLine();

        }
    }
}
