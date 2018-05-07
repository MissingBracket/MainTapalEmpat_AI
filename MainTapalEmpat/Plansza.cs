using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class Plansza
    {
        public int[,] stan = new int[9, 9] {{1,3,1,3,1,3,1,3,1},
                                            {4,6,2,5,4,6,4,5,4},
                                            {1,3,1,3,1,3,1,3,1},
                                            {4,5,4,6,4,5,4,6,4},
                                            {1,3,1,3,1,3,1,3,1},
                                            {4,6,4,5,4,6,4,5,4},
                                            {1,3,1,3,1,3,1,3,2},
                                            {4,5,4,6,4,5,4,6,4},
                                            {1,3,1,3,1,3,1,3,0}};

        public int[,] temp = new int[9, 9];

        public Plansza zmien(Plansza pl, Ruch lr)
        {
            Plansza toret = pl;
            // zmiana planszy na podst tabl ruchow
            return toret;
        }

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
        public void dodajTygrysaDoPlanszy(int x, int y)
        {
            if (x == 0 && y == 0)
            {
                stan[x, y] = 2;
            }
            else if (x == 0)
            {
                stan[x, (y * 2)] = 2;
            }
            else if (y == 0)
            {
                stan[(x * 2), y] = 2;
            }
            else
            {
                stan[(x * 2), (y * 2)] = 2;
            }
        }
    }
}
