using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class Wezel
    {
        //public Ruch r;
        public List<Ruch> r;//lista ruchów
        public List<Wezel> Lpotomkow;
        public int ocena = 0;
        public int wartosc = 0;
        public bool min = false;
        public bool max = false;

        public Wezel()
        {
            Lpotomkow = new List<Wezel>();
            r = new List<Ruch>();
        }
        public Wezel(List<Ruch> dr, int wart)//Ruch dr)
        {
            //r = dr;
            ocena = wart;
            r = new List<Ruch>();
            Lpotomkow = new List<Wezel>();
            for (int i = 0; i < dr.Count; i++)
            {
                r.Add(dr.ElementAt(i));
            }
        }

        public void dodajWezel(Ruch dr, bool Min, bool Max, int sum)
        {
            int wart = 0;
            min = Min;
            max = Max;
            wart = sum + 0;
            List<Ruch> lTemp = new List<Ruch>();
            lTemp.Add(dr);
            Lpotomkow.Add(new Wezel(lTemp, wart));//new Wezel(dr));
            lTemp.Clear();
        }
        public void dodajWezel(List<Ruch> lr, bool Min, bool Max, int sum)//przeciążona funkcja 
        {
            int wart = 0;
            min = Min;
            max = Max;
            if (Max == true)
                wart = lr.Count + sum;
            else if (Min == true)
                wart = -1 * lr.Count + sum;
            Lpotomkow.Add(new Wezel(lr, wart));
        }

    }
}
