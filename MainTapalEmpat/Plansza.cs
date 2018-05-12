using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class Plansza
    {
        public int[,] stan = new int[9, 9]{ {1,3,1,3,1,3,1,3,1},
                                            {4,6,4,5,4,6,4,5,4},
                                            {1,3,1,3,1,3,1,3,1},
                                            {4,5,4,6,4,5,4,6,4},
                                            {0,3,2,3,1,3,2,3,0},
                                            {4,6,4,5,4,6,4,5,4},
                                            {2,3,2,3,2,3,2,3,2},
                                            {4,5,4,6,4,5,4,6,4},
                                            {2,3,2,3,2,3,2,3,2}};

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
        public void uaktualnijStanPlanszy(int[,] nowyStan)
        {
            Array.Copy(nowyStan, 0, stan, 0, stan.Length);
            Array.Copy(nowyStan, 0, temp, 0, stan.Length);
        }
        public void pokazStanPlanszy()
        {
            for (int i =0; i < 9; i++)
            {
                for (int j =0; j<9; j++)
                {
                    Console.Write(stan[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void dodajOwieczkeDoPlanszy(int x, int y)
        {
            if (x == 0 && y == 0)
            {
                stan[x, y] = 1;
            }
            else if (x == 0)
            {
                stan[x, (y )] = 1;
            }
            else if (y == 0)
            {
                stan[(x), y] = 1;
            }
            else
            {
                stan[(x ) , (y)] = 1;
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
                stan[x, (y)] = 2;
            }
            else if (y == 0)
            {
                stan[(x ), y] = 2;
            }
            else
            {
                stan[(x ), (y)] = 2;
            }
        }
    }
}
