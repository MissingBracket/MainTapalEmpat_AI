using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class Drzewo
    {
        public Wezel root;
        //Wezel aktualny;//uzywany to przemieszczania sie pod drzewie
        public Plansza plansza_poczatkowa = new Plansza();

        public Operacje operacje = new Operacje();



        public void utworzDrzewo()
        {
            root = new Wezel(plansza_poczatkowa,operacje,0);
            utworzDrzewo2(root, 0, 1, false, true);
        }

        public void utworzDrzewo2(Wezel wezel, int poziom, int zawodnik, bool Min, bool Max)
        {
            operacje.ListaRuchow.Clear();
            operacje.ListaBic.Clear();

            int przeciwnik = -1;
            bool Min2 = false;
            bool Max2 = true;
            if (zawodnik == 1) przeciwnik = 2;
            else if (zawodnik == 2) przeciwnik = 1;

            if (Min == false && Max == true && poziom != 0)
            {
                Min2 = true;
                Max2 = false;
            }
            else if (Min == true && Max == false && poziom != 0)
            {
                Min2 = false;
                Max2 = true;
            }

            if (poziom < 5)
            {
                if (poziom == 0)
                {
                    operacje.generujBiciaWilkow(1, this.plansza_poczatkowa);
                    wezel.nadajOceneWezlowi(0);
                    // dodajemy jako potomkow mozliwe bicia
                    for (int j = 0; j < operacje.ListaBic.Count; j++)
                    {
                        Console.WriteLine("poziom "+poziom+" kulka: " + j + ": dodaje wezel bicia: [" + operacje.ListaBic[j].skad.x + "," + operacje.ListaBic[j].skad.y + "] -->" + "[" + operacje.ListaBic[j].dokad.x + "," + operacje.ListaBic[j].dokad.y + "]");
                        wezel.dodajWezel(operacje.ListaBic.ElementAt(j), false, true, zawodnik, operacje,1);
                       
                    }

                    if (operacje.ListaBic.Count == 0) //tylko jeśli nie ma bić to dodajemy jako potomkow mozliwe ruchy
                    {
                        operacje.generujMozliweRuchyWilkow(1, this.plansza_poczatkowa);
                        for (int j = 0; j < operacje.ListaRuchow.Count; j++)
                        {
                            Console.WriteLine("poziom " + poziom+ " kulka: " + j + ": dodaje wezel ruchu: [" + operacje.ListaRuchow[j].skad.x + "," + operacje.ListaRuchow[j].skad.y + "] -->" + "["+ operacje.ListaRuchow[j].dokad.x + "," + operacje.ListaRuchow[j].dokad.y + "]");
                            root.dodajWezel(operacje.ListaRuchow.ElementAt(j), false, true, zawodnik,operacje,0);
                        }
                    }
                    // wywolanie rekurencyjne dla potomkow
                    for (int i = 0; i < wezel.lista_potomkow.Count; i++)
                    {
                        utworzDrzewo2(wezel.lista_potomkow.ElementAt(i), poziom + 1, przeciwnik, true, false);
                    }
                        


                }
                else
                {

                    operacje.ListaRuchow.Clear();
                    operacje.ListaBic.Clear();
                    //dla owiec
                    if (Min == true && Max == false)
                    {
                        wezel.nadajOceneWezlowi(0);
                        Console.WriteLine("poziom " + poziom + " pusty node na owiec");
                        Ruch r = new Ruch();
                        r.skad.x = 1;
                        r.skad.y = 0;
                        r.dokad.x = 1;
                        r.dokad.y = 0;
                        wezel.plansza.pokazStanPlanszy();
                        wezel.dodajWezel(r, Min, Max,2,operacje,0);

                        for (int i = 0; i < wezel.lista_potomkow.Count; i++)
                        {
                            utworzDrzewo2(wezel.lista_potomkow.ElementAt(i), poziom + 1, przeciwnik, Min2, Max2);
                        }
                    }
                    //dla wilkow
                    if (Max == true && Min == false)
                    {

                        operacje.generujBiciaWilkow(zawodnik, wezel.plansza);

                        for (int j = 0; j < operacje.ListaBic.Count; j++)
                        {
                            wezel.nadajOceneWezlowi(1);
                            Console.WriteLine("poziom " + poziom + " kulka: " + j + ": dodaje wezel bicia: [" + operacje.ListaBic[j].skad.x + "," + operacje.ListaBic[j].skad.y + "] -->" + "[" + operacje.ListaBic[j].dokad.x + "," + operacje.ListaBic[j].dokad.y + "]");
                            wezel.dodajWezel(operacje.ListaBic.ElementAt(j), Min, Max, 1,operacje,1);
                        }

                        if (operacje.ListaBic.Count == 0)//tylko jeśli nie ma bić to dodajemy jako potomkow mozliwe ruchy
                        {
                            wezel.nadajOceneWezlowi(0);
                            operacje.generujMozliweRuchyOwiec(zawodnik, wezel.plansza);
                            for (int j = 0; j < operacje.ListaRuchow.Count; j++)
                            {
                                Console.WriteLine("poziom " + poziom + " kulka: " + j + ": dodaje wezel ruchu: [" + operacje.ListaRuchow[j].skad.x + "," + operacje.ListaRuchow[j].skad.y + "] -->" + "[" + operacje.ListaRuchow[j].dokad.x + "," + operacje.ListaRuchow[j].dokad.y + "]");
                                wezel.dodajWezel(operacje.ListaRuchow.ElementAt(j), Min, Max, 1,operacje,0);
                            }
                        }
                        for (int i = 0; i < wezel.lista_potomkow.Count; i++)
                        {
                            utworzDrzewo2(wezel.lista_potomkow.ElementAt(i), poziom + 1, przeciwnik, Min2, Max2);
                        }
                           
                    }
                    
                    

                }

            }
        }
        public void MinMax(Wezel w)
        {
            if (w.max == true)
            {
                if (w.lista_potomkow.ElementAt(0).lista_potomkow.Count != 0)
                    for (int i = 0; i < w.lista_potomkow.Count; i++)
                        MinMax(w.lista_potomkow.ElementAt(i));
                w.ocena = w.lista_potomkow.Max(x => x.ocena);
            }
            else if (w.min == true)
            {
                if (w.lista_potomkow.ElementAt(0).lista_potomkow.Count != 0)
                    for (int i = 0; i < w.lista_potomkow.Count; i++)
                        MinMax(w.lista_potomkow.ElementAt(i));
                w.ocena = w.lista_potomkow.Min(x => x.ocena);
            }
        }

        public int alfaBeta(Wezel w, int a, int b)
        {
            if (w.lista_potomkow.Count == 0)
                return w.ocena;
            if (w.max == true)
            {
                for (int i = 0; i < w.lista_potomkow.Count; i++)
                {
                    a = Math.Max(a, alfaBeta(w.lista_potomkow.ElementAt(i), a, b));
                    if (a >= b)
                    {
                        w.ocena = b;
                        return b;
                    }
                }
                w.ocena = a;
                return a;
            }

            else if (w.min == true)
            {
                for (int i = 0; i < w.lista_potomkow.Count; i++)
                {
                    b = Math.Min(b, alfaBeta(w.lista_potomkow.ElementAt(i), a, b));
                    if (a >= b)
                    {
                        w.ocena = a;
                        return a;
                    }
                }
                w.ocena = b;
                return b;
            }

            return 0;
        }

        public Ruch zwrocRuchKomputera()
        {

            return new Ruch();
        }
        //public List<Ruch> ZwrocRuchKomputera2(int z)
        //{
        //    try
        //    {
        //        root.lista_ruchow_wezla = root.lista_potomkow.Find(x => x.ocena == z).lista_ruchow_wezla;
        //        return root.lista_ruchow_wezla;
        //    }
        //    catch (NullReferenceException ex)
        //    {
        //        return null;
        //    }
        //    //root.r = root.Lpotomkow.Find(x => x.ocena == alfaBeta(root)).r;
        //}


    }
}

