using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class Plansza
    {
        public int[,] stan = new int[9, 9] {{0,3,0,3,0,3,0,3,0},
                                            {4,6,2,5,4,6,4,5,4},
                                            {0,3,0,3,0,3,0,3,0},
                                            {4,5,4,6,4,5,4,6,4},
                                            {0,3,0,3,0,3,0,3,0},
                                            {4,6,4,5,4,6,4,5,4},
                                            {0,3,0,3,0,3,0,3,0},
                                            {4,5,4,6,4,5,4,6,4},
                                            {0,3,0,3,0,3,0,3,0}};

        public int[,] temp = new int[9, 9];

        public Plansza()
        {
            temp = new int[9, 9];
            Array.Copy(stan, 0, temp, 0, stan.Length);
        }
        public Plansza(int[,] p)
        {
            Array.Copy(p, 0, stan, 0, p.Length);
            temp = new int[9, 9];
            Array.Copy(stan, 0, temp, 0, stan.Length);
        }
        public void dodajOwieczkeDoPlanszy(int x, int y)
        {
            if (x == 0 && y == 0)
            {
                stan[x, y] = 1;
            }
            else if (x == 0)
            {
                stan[x, (y * 2)] = 1;
            }
            else if (y == 0)
            {
                stan[(x*2), y] = 1;
            }
            else
            {
                stan[(x * 2) , (y*2)] = 1;
            }   
        }
    }
}
