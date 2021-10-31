using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReneXO
{
    class AlgR
    {
        public static bool PraznoPolje(string[] tab)
        {
            foreach(string polje in tab)
            {
                if (polje.Equals(" "))
                {
                    return true;
                }
            }
            return false;
        }
        public static string[] Fill(string[] tab)
        {
            for(int i = 0; i < tab.Length; i++)
            {
                tab[i] = " ";
            }
            return tab;
        }


        public static void Prikaži(string[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                if(tab[i].Equals(" "))
                {
                    Console.Write("_");
                }
                else
                {
                    Console.Write(tab[i]);
                }
                
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine("");
                }
                
                
            }
        }

        public static string[] Postavi(string[] tab, bool naVrsti,int kjeNaBordu)
        {
            if (naVrsti.Equals(false)&&tab[kjeNaBordu-1]==" "){
                tab[kjeNaBordu - 1] = "O";
            }
            else if(naVrsti.Equals(true)&& tab[kjeNaBordu-1] == " ")
            {
                tab[kjeNaBordu - 1] = "X";
            }
            else
            {
                Console.WriteLine("prostor ni prost");
                Postavi(tab, naVrsti, int.Parse(Console.ReadLine()));
            }

            return tab;
        }
        public static int Zmaga(string[] tab)
        {
            for (int i = 0; i < tab.Length; i = i + 3)
            {
                if (tab[i].Equals(tab[i + 1]) && tab[i + 1].Equals(tab[i + 2]) && (tab[i].Equals("O") || tab[i].Equals("X")))
                {
                    
                    if (tab[i] == "O")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
               

            }
            for (int i = 0; i < 3; i++)
            {

                if (tab[i].Equals(tab[i + 3]) && tab[i + 3].Equals(tab[i + 6]) && (tab[i].Equals("O") || tab[i].Equals("X")))
                {
                    
                    if (tab[i] == "O")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                

            }
            if (tab[0].Equals(tab[4]) && tab[4].Equals(tab[8]) && (tab[0].Equals("O") || tab[0].Equals("X")))
            {
                
                if (tab[0] == "O")
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            if (tab[2].Equals(tab[4]) && tab[4].Equals(tab[6]) && (tab[2].Equals("O") || tab[2].Equals("X")))
            {
                
                if (tab[2] == "O")
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            return 0;
            
        }
        public static bool Izenačeno(string[] tab)
        {
            if (PraznoPolje(tab))
            {
                return false;
            }
            else
            {
                
                return true;
            }
        }
        
    }
}
