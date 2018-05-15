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
        public Wezel refkaParenta = null;

        public Wezel()
        {

        }
        public Wezel(Plansza pl, Operacje operacje, int suma,Ruch r)
        {
            refkaParenta = new Wezel();
            ruch = new Ruch();
            ruch = r;
            plansza = new Plansza();
            lista_potomkow = new List<Wezel>();
            ocena = suma;
            plansza.uaktualnijStanPlanszy(pl.stan);
        }
        public Wezel(Plansza pl, Operacje operacje, int suma, Ruch r,Wezel wezel)
        {
            refkaParenta = new Wezel();
            ruch = new Ruch();
            ruch = r;
            plansza = new Plansza();
            lista_potomkow = new List<Wezel>();
            ocena = suma;
            plansza.uaktualnijStanPlanszy(pl.stan);
        }
        public Wezel(Plansza pl, Operacje operacje, Ruch r)
        {
            refkaParenta = new Wezel();
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
        public void dodajWezel(Ruch ruch, bool Min, bool Max, int zawodnik, Operacje operacje, Wezel parent)
        {

            min = Min;
            max = Max;
            Plansza temp = new Plansza();
            temp.uaktualnijStanPlanszy(plansza.stan);
            operacje.wykonajRuchIZmienStanPlanszy(zawodnik, ruch, temp.stan);
            //int nowaOcena = this.ocena + wartosc;
            refkaParenta = parent;
            lista_potomkow.Add(new Wezel(temp, operacje,0, ruch, parent));
        }
        public void nadajOcenePoziomWyzej(int wartosc)
        {
            this.refkaParenta.ocena = wartosc;
        }


    }
}
