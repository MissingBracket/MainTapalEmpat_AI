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
        public Ruch ruch;
        public int ocena = 0;
        public bool min = false;
        public bool max = false;
        public Wezel refkaParenta;


        public Wezel(Plansza pl, Operacje operacje, int suma,Ruch r)
        {
            ruch = new Ruch();
            ruch = r;
            plansza = new Plansza();
            lista_potomkow = new List<Wezel>();
            ocena = suma;
            plansza.uaktualnijStanPlanszy(pl.stan);
        }
        public Wezel(Plansza pl, Operacje operacje, Ruch r)
        {
            ruch = new Ruch();
            ruch = r;
            plansza = new Plansza();
            lista_potomkow = new List<Wezel>();
            //ocena = suma;
            plansza.uaktualnijStanPlanszy(pl.stan);
        }

        public void dodajWezel(Ruch ruch, bool Min, bool Max, int zawodnik, Operacje operacje, int wartosc)
        {
            
            min = Min;
            max = Max;
            Plansza temp = new Plansza();
            temp.uaktualnijStanPlanszy(plansza.stan);
            operacje.wykonajRuchIZmienStanPlanszy(zawodnik, ruch, temp.stan);
            int nowaOcena = this.ocena + wartosc;
            lista_potomkow.Add(new Wezel(temp, operacje,nowaOcena,ruch));
         
           
        }
        public void dodajWezel(Ruch ruch, bool Min, bool Max, int zawodnik, Operacje operacje, Wezel refkaParenta)
        {

            min = Min;
            max = Max;
            Plansza temp = new Plansza();
            temp.uaktualnijStanPlanszy(plansza.stan);
            operacje.wykonajRuchIZmienStanPlanszy(zawodnik, ruch, temp.stan);
            //int nowaOcena = this.ocena + wartosc;
            lista_potomkow.Add(new Wezel(temp, operacje, ruch));
        }
        public void nadajOcene2PoziomyWyzej(int wartosc)
        {
            this.refkaParenta.refkaParenta.ocena = wartosc;
        }


    }
}
