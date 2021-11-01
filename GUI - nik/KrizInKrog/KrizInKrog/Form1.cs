using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KrizInKrog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[,] plošča =
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 0 },
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            izberi_polje(1, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            izberi_polje(2, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            izberi_polje(3, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            izberi_polje(1, 2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            izberi_polje(2, 2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            izberi_polje(3, 2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            izberi_polje(1, 3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            izberi_polje(2, 3);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            izberi_polje(3,3);
        }

        private void izberi_polje(int x, int y)
        {
            //napisi kodo ki vnaša podatke v tabelo tako da tvoja koda prepozna


        }

        private void zakleni_gumb(int x, int y)
        {
            // primer za x = 1, y = 2     (y je 2) * 3 = 6   ->   6-3 = 3   ->  3+(x je 1) = 4   ->   gumb 4 
            int st_gumba = y * 3 - 3 + x;


            //ne bom se jebu z iskanjem funkcij ker nimamo časa vendar bo delalo
            switch (st_gumba)
            {
                case 1:
                    button1.Enabled = false;
                    break;
                case 2:
                    button2.Enabled = false;
                    break;
                case 3:
                    button3.Enabled = false;
                    break;
                case 4:
                    button4.Enabled = false;
                    break;
                case 5:
                    button5.Enabled = false;
                    break;
                case 6:
                    button6.Enabled = false;
                    break;
                case 7:
                    button7.Enabled = false;
                    break;
                case 8:
                    button8.Enabled = false;
                    break;
                case 9:
                    button9.Enabled = false;
                    break;

            }
        }
    }
}
