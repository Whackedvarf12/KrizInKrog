﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_aly
{
    class Poteza //Ta razred bo uporabljen za shranjevanje možnih potez
    {
        private int[,] polje { get; set; }
        private int tocke { get; set; }
        public Poteza(int[,] polje, int tocke)
        {
            this.polje = polje;
            this.tocke = tocke;
        }
    }
}
