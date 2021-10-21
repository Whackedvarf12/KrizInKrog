using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_aly
{
    class Program
    {
        public int gameMoves = 0;
        public int x { set; get; }
        public int y = 0;
        static void Main(string[] args)
        {
            int[,] field = new int[3, 3];
            for (int status = 0; status < 10; status = status)
            {
                Console.WriteLine("Vnesi x");
                Console.ReadLine();
                Console.ReadLine();
            }
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
    }
}
