using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class Wezel
    { 
        public Plansza plansza;
        public List<Wezel> lista_potomkow;
        public int ocena = 0;
        public bool min = false;
        public bool max = false;


        public Wezel(Plansza pl, Operacje operacje, int suma)//Ruch dr)
        {
            plansza = new Plansza();
            lista_potomkow = new List<Wezel>();

            plansza.uaktualnijStanPlanszy(pl.stan);
        }

        public void dodajWezel(Ruch ruch, bool Min, bool Max, int zawodnik, Operacje operacje, int wartosc)
        {
            
            min = Min;
            max = Max;
            Plansza temp = new Plansza();
            temp.uaktualnijStanPlanszy(plansza.stan);
            operacje.wykonajRuchIZmienStanPlanszy(zawodnik, ruch, temp.stan);
            if (ruch.bicie == true)
            {
                lista_potomkow.Add(new Wezel(temp, operacje,this.ocena+1));
            }
            else
            {
                lista_potomkow.Add(new Wezel(temp, operacje, this.ocena));
            }
            
           
        }
        public void nadajOceneWezlowi(int wartosc)
        {
           
            this.ocena = wartosc;
        }

    }
}
