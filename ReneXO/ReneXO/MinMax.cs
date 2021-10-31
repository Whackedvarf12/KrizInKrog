using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReneXO
{
    class MinMax
    {
        public static int AiMouve(string[] bord)
        {
            int mouve=0;
            int score = 0;
                int bestScore = -99;
                for (int i = 0; i < bord.Length; i++)
                {
                    if (bord[i] == " ")
                    {
                        bord[i] = "X";
                        score = MiniMax(bord, false);
                        bord[i] = " ";
                        if(score > bestScore)
                    {
                        bestScore = score;
                        mouve = i;
                    }
                    }
                }
            Console.WriteLine("aiMouve "+(mouve+1));
                return mouve+1;
            
        }
        public static int MiniMax(string[] bord, bool playerturn)
        {
            int z = AlgR.Zmaga(bord);
            int score=0;
            if (z == 2)
            {
                return 2;
            }
            else if (z == 1)
            {
                return -2;
            }
            else if (AlgR.Izenačeno(bord))
            {
                return 0;
            }

            if (playerturn == true)
                {
                int bestScore = -99;
                for (int i = 0; i < bord.Length; i++)
                    {
                    if (bord[i] == " ")
                    {
                        bord[i] = "X";
                        score=MiniMax(bord, false);
                        bord[i] = " ";
                        bestScore = Math.Max(score, bestScore);
                    }
                    }
                return bestScore;
                }
            if (playerturn == false)
            {
                int bestScore = 99;
                for (int i = 0; i < bord.Length; i++)
                {
                    if (bord[i] == " ")
                    {
                        bord[i] = "O";
                        score = MiniMax(bord, true);
                        bord[i] = " ";
                        bestScore = Math.Min(score, bestScore);
                    }
                }
                return bestScore;
            }
            return score;
        }

    }
}
