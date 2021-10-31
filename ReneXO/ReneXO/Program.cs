using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReneXO
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] board = new string[9];
            AlgR.Fill(board);
            bool naVrsti = false;

            while (AlgR.PraznoPolje(board))
            {
                
                AlgR.Prikaži(board);
                if (naVrsti == true)
                {
                    AlgR.Postavi(board, naVrsti, MinMax.AiMouve(board));
                }
                else
                {
                    AlgR.Postavi(board, naVrsti, int.Parse(Console.ReadLine()));
                }
                int z = AlgR.Zmaga(board);
                if(z==1){
                    Console.WriteLine("Zmaga O");
                    AlgR.Prikaži(board);
                    break;
                }
                if (z == 2)
                {
                    Console.WriteLine("Zmaga X");
                    AlgR.Prikaži(board);
                    break;
                }
                if (AlgR.Izenačeno(board))
                {
                    Console.WriteLine("Izenačeno");
                    AlgR.Prikaži(board);
                    break;
                }
                naVrsti = !naVrsti;
 
            }

            Console.ReadLine();
        }
    }
}
