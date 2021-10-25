using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_aly
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;
            int gameMoves =0;
            int playerController = 1;
            int[,] field = new int[3, 3];
            for (int status = 0; status < 9; status = status)
            {
                Console.WriteLine("Vnesi x");
                x = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Vnesi y");
                y = Int32.Parse(Console.ReadLine());
                if (nextMove(field, x, y, playerController))
                {
                    gameMoves++;
                    if (playerController==1)
                    {
                        playerController = 2;
                    }
                    else
                    {
                        playerController = 1;
                    }
                }
                
            }
            Console.WriteLine(gameMoves);
            Console.Read();
        }
        public static void viewField(int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i,j]+ "|");
                }
                Console.WriteLine();
            }
            Console.Read();
        }
        public static Boolean gameFinished(int[,] field)
        {
            return true;
        }
        public static int[,] crissOrCross(int[,] field, int x, int y)
        {
            if (field[x, y] > 1)
            {
                Console.WriteLine("To polje je že zapolnjeno.");
                return field;
            }
            else
            {
                field[x, y] = 1;
                return field;
            }
        }
        public static bool nextMove(int[,] field, int x, int y, int player)
        {
            if (x < 0 || x >= 3 || y < 0 || y >= 3)
            {
                Console.WriteLine("Cell out of bounds.");
                return false;
            }
            else if (field[x, y] > 0)
            {
                Console.WriteLine("Cell already used.");
                return false;
            }
            else
            {
                field[x, y] = player;
                return true;
            }
        }
    }
}
