﻿using System;
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
            int x = 0; //x koordinata za polje
            int y = 0; //y koordinata za polje
            int gameMoves =0; //koliko korakov je minilo
            int playerController = 1; // 1 je človek, 2 je računalnik
            int[,] field = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }; //novo polje
            /*for (int status = 0; status < 9; status = status)
            {
                Console.WriteLine("Vnesi x");
                x = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Vnesi y");
                y = Int32.Parse(Console.ReadLine());
                if (nextMove(field, x, y, playerController))
                {
                    gameMoves++;
                    evaluateField(field);
                    if (playerController==1)
                    {
                        playerController = 2;
                    }
                    else
                    {
                        //field = ;
                        playerController = 1;
                    }
                }
                
            }*/
            //Console.WriteLine(gameMoves);
            evaluateField(field);
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
            else if (field[x, y]!=0)
            {
                Console.WriteLine("Cell already used.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void /*int[,]*/ evaluateField(int[,] field)
        {
            List<Poteza> moznePoteze = new List<Poteza>();
            for (int i=0;i<3;i++)
            {
                for (int j=0;j<3;j++)
                {
                    Console.WriteLine("st polja je=" + field[i, j]);
                    if (field[i,j]==0)
                    {
                        field[i, j] = 2;
                        moznePoteze.Add(new Poteza(field, 0));
                        field[i, j] = 0;
                    }
                }
                Console.Write("st vrstice je=" + field[i, 0]);

            }
            Console.WriteLine("mozne poteze="+moznePoteze.Count);
            for (int i=0;i>moznePoteze.Count;i++)
            {
                Console.WriteLine("|"+moznePoteze[i]);
            }
        }

        public static int checkCorners(int[,] field)
        {
            int cornerScore = 0;
            if (field[0, 0] == 1)
            {
                cornerScore -= 1;
            }
            if (field[0, 2] == 1)
            {
                cornerScore -= 1;
            }
            if (field[2, 0] == 1)
            {
                cornerScore -= 1;
            }
            if (field[2, 2] == 1)
            {
                cornerScore -= 1;
            }
            return cornerScore;
        }
        //public static Poteza 
    }
}
