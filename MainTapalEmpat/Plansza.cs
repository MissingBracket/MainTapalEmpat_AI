using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class Plansza
    {
        public int[,] stan = new int[9, 9] {{2,3,2,3,0,3,2,3,2},
                                            {4,6,2,5,4,6,2,5,2},
                                            {2,3,2,3,0,3,2,3,2},
                                            {4,5,4,6,4,5,4,6,4},
                                            {2,3,2,3,0,3,1,3,2},
                                            {4,6,4,5,4,6,4,5,4},
                                            {2,3,2,3,1,3,0,3,2},
                                            {4,5,4,6,4,5,4,6,4},
                                            {2,3,2,3,2,3,2,3,0}};

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
    }
}
