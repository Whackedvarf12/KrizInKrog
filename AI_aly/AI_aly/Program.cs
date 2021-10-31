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
            int x = 0; //x koordinata za polje
            int y = 0; //y koordinata za polje
            int gameMoves = 0; //koliko korakov je minilo
            int playerController = 1; // 1 je človek, 2 je računalnik
            int[,] field = { { 2, 0, 2 }, { 0, 0, 0 }, { 0, 0, 0 } }; //novo polje
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
                    Console.Write(field[i, j] + "|");
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
            else if (field[x, y] != 0)
            {
                Console.WriteLine("Cell already used.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void /*int[,]*/ evaluateField(int[,] f)
        {
            int[,] tempField = copyFieldFrom(f);

            List<Poteza> moznePoteze = new List<Poteza>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tempField[i, j] == 0)
                    {
                        tempField[i, j] = 2;
                        //Console.WriteLine("polje "+i+","+j+" je "+field[i,j]);
                        moznePoteze.Add(new Poteza(tempField, 0));
                    }
                    tempField=copyFieldFrom(f);
                }

            }
            moznePoteze=vrednostLastnihPotez(moznePoteze);
            moznePoteze=tockePoteze(moznePoteze);
            int max = 0;
            for (int i=0; i<moznePoteze.Count;i++)
            {
                moznePoteze[i].tocke += nasprotnikovaPoteza(moznePoteze[i].polje);
                Console.WriteLine("koncna vrednost moznoisti "+(i+1)+" je "+moznePoteze[i].tocke);
                if (moznePoteze[i].tocke>max)
                {
                    max = moznePoteze[i].tocke;
                }
            }
            Console.WriteLine("najvec tock "+max);
        }

        public static int checkCorners(int[,] field)
        {
            int cornerScore = 0;

            if (field[0, 0] == 1)
            {
                cornerScore = cornerScore - 1;
            }
            else if (field[0, 0] == 2)
            {
                cornerScore += 1;
            }

            if (field[0, 2] == 1)
            {
                cornerScore = cornerScore - 1;
            }
            else if (field[0, 2] == 2)
            {
                cornerScore += 1;
            }

            if (field[2, 0] == 1)
            {
                cornerScore = cornerScore - 1;
            }
            else if (field[2, 0] == 2)
            {
                cornerScore += 1;
            }

            if (field[2, 2] == 1)
            {
                cornerScore = cornerScore - 1;
            }
            else if (field[2, 2] == 2)
            {
                cornerScore += 1;
            }
            //Console.WriteLine(field[0, 0] + "|" + field[0, 2] + "|" + field[2, 0] + "|" + field[2, 2]);
            return cornerScore;
        }

        public static List<Poteza> vrednostLastnihPotez(List<Poteza> moznePoteze)
        {
            for (int i = 0; i < moznePoteze.Count; i++)
            {
                moznePoteze[i].tocke = checkCorners(moznePoteze[i].polje);
            }
            return moznePoteze;
        }

        public static int[,] copyFieldFrom(int[,] f)
        {
            int[,] tempF = new int[3,3];
            for (int i=0; i<3;i++)
            {
                for (int j=0;j<3;j++)
                {
                    tempF[i, j] = f[i, j];
                }
            }
            return tempF;
        }
        public static List<Poteza> tockePoteze(List<Poteza> moznePoteze)
        {
            int tockeVrstic = 0;
            int stDobrih = 0;
            int stSlabih = 0;
            for (int ji = 0; ji < moznePoteze.Count; ji++)
            {
                for (int i = 0; i < 3; i++)
                {

                    for (int j = 0; j < 3; j++)
                    {
                        if (moznePoteze[ji].polje[i, j] == 2)
                        {
                            stDobrih++;
                        }
                        else if (moznePoteze[ji].polje[i, j] == 1)
                        {
                            stSlabih++;
                        }
                    }
                    if (stDobrih > 0)
                    {
                        switch (stDobrih)
                        {
                            case 1:
                                tockeVrstic += 1;
                                break;
                            case 2:
                                tockeVrstic += 2;
                                break;
                            case 3:
                                tockeVrstic += 10;
                                break;
                        }

                    }
                    if (stSlabih > 0)
                    {

                        switch (stSlabih)
                        {
                            case 1:
                                tockeVrstic -= 1;
                                break;
                            case 2:
                                tockeVrstic -= 2;
                                break;
                            case 3:
                                tockeVrstic -= 20;
                                break;
                        }
                    }
                    stDobrih = 0;
                    stSlabih = 0;
                    moznePoteze[ji].tocke = tockeVrstic;
                    tockeVrstic = 0;
                }
                
            }

            for (int ji = 0; ji < moznePoteze.Count; ji++)
            {
                for (int i = 0; i < 3; i++)
                {

                    for (int j = 0; j < 3; j++)
                    {

                        if (moznePoteze[ji].polje[j, i] == 2)
                        {
                            stDobrih++;
                        }
                        else if (moznePoteze[ji].polje[j, i] == 1)
                        {
                            stSlabih++;
                        }
                    }
                    if (stDobrih > 0)
                    {
                        switch (stDobrih)
                        {
                            case 1:
                                tockeVrstic += 1;
                                break;
                            case 2:
                                tockeVrstic += 2;
                                break;
                            case 3:
                                tockeVrstic += 10;
                                break;
                        }

                    }
                    if (stSlabih > 0)
                    {

                        switch (stSlabih)
                        {
                            case 1:
                                tockeVrstic -= 1;
                                break;
                            case 2:
                                tockeVrstic -= 2;
                                break;
                            case 3:
                                tockeVrstic -= 20;
                                break;
                        }
                    }
                    stDobrih = 0;
                    stSlabih = 0;
                    moznePoteze[ji].tocke = tockeVrstic;
                    tockeVrstic = 0;
                }

            }

            for (int ji = 0; ji < moznePoteze.Count; ji++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (moznePoteze[ji].polje[i, i] == 2)
                    {
                        stDobrih++;
                    }
                    else if (moznePoteze[ji].polje[i, i] == 1)
                    {
                        stSlabih++;
                    }
                }

                if (moznePoteze[ji].polje[0,2]==1)
                {
                    stSlabih++;
                }
                else if (moznePoteze[ji].polje[0, 2] == 2)
                {
                    stDobrih++;
                }
                if (moznePoteze[ji].polje[1, 1] == 1)
                {
                    stSlabih++;
                }
                else if (moznePoteze[ji].polje[1, 1] == 2)
                {
                    stDobrih++;
                }
                if (moznePoteze[ji].polje[2, 0] == 1)
                {
                    stSlabih++;
                }
                else if (moznePoteze[ji].polje[2, 0] == 2)
                {
                    stDobrih++;
                }
                if (stDobrih > 0)
                {
                    switch (stDobrih)
                    {
                        case 1:
                            tockeVrstic += 1;
                            break;
                        case 2:
                            tockeVrstic += 2;
                            break;
                        case 3:
                            tockeVrstic += 10;
                            break;
                    }

                }
                if (stSlabih > 0)
                {

                    switch (stSlabih)
                    {
                        case 1:
                            tockeVrstic -= 1;
                            break;
                        case 2:
                            tockeVrstic -= 2;
                            break;
                        case 3:
                            tockeVrstic -= 20;
                            break;
                    }
                }
                stDobrih = 0;
                stSlabih = 0;
                moznePoteze[ji].tocke = tockeVrstic;
                tockeVrstic = 0;

            }
            return moznePoteze;
        }

        public static int nasprotnikovaPoteza(int[,] f)
        {
            int[,] tempField = copyFieldFrom(f);

            List<Poteza> moznePotezeNas = new List<Poteza>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tempField[i, j] == 0)
                    {
                        tempField[i, j] = 1;
                        //Console.WriteLine("polje "+i+","+j+" je "+field[i,j]);
                        moznePotezeNas.Add(new Poteza(tempField, 0));
                    }
                    tempField = copyFieldFrom(f);
                }
                

            }
            
            moznePotezeNas = vrednostLastnihPotez(moznePotezeNas);
            moznePotezeNas = tockePoteze(moznePotezeNas);
            int min = moznePotezeNas[0].tocke;
            for (int i=0; i<moznePotezeNas.Count;i++)
            {
                if (moznePotezeNas[i].tocke<min)
                {
                    min = moznePotezeNas[i].tocke;
                }
            }
            return min;
        }
    }
}
