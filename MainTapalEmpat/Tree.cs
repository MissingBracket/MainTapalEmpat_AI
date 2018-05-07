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
        public Plansza pl = new Plansza();
        public Operacje op = new Operacje();
        int[,] t = new int[9, 9];//pomocnicza
        int[,] t2 = new int[9, 9];
        int[,] PlPom;

        public void utworzDrzewo()
        {
            root = new Wezel();
            utworzDrzewo2(root, 0, 1, false, true, pl.temp);
        }

        public void utworzDrzewo2(Wezel w, int poziom, int Zawodnik, bool Min, bool Max, int[,] plansza)
        {
            op.tabRu.Clear();
            op.LBic.Clear();
            PlPom = new int[9, 9];
            Array.Copy(plansza, 0, PlPom, 0, plansza.Length);
            int zaw2 = -1;
            bool Min2 = false;
            bool Max2 = true;
            if (Zawodnik == 1) zaw2 = 2;
            else if (Zawodnik == 2) zaw2 = 1;

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

            if (poziom < 3)
            {
                if (poziom == 0)
                {
                    op.generujBiciaWilkow(1, pl);
                    //Console.WriteLine(op.LBic.Count);
                    // dodajemy jako potomkow mozliwe bicia
                    for (int j = 0; j < op.LBic.Count; j++)
                    {
                        Console.WriteLine("poziom "+poziom+" kulka: " + j + ": dodaje wezel bicia: ");
                        w.dodajWezel(op.LBic.ElementAt(j).lRuchBic, false, true, w.ocena);
                    }

                    if (op.LBic.Count == 0) //tylko jeśli nie ma bić to dodajemy jako potomkow mozliwe ruchy
                    {
                        op.generujMozliweRuchyWilkow(1, pl);
                        for (int j = 0; j < op.tabRu.Count; j++)
                        {
                            Console.WriteLine("poziom " + poziom+ " kulka: " + j + ": dodaje wezel ruchu: [" + op.tabRu[j].skad.x + "," + op.tabRu[j].skad.y + "] -->" + "["+ op.tabRu[j].dokad.x + "," + op.tabRu[j].dokad.y + "]");
                            root.dodajWezel(op.tabRu.ElementAt(j), false, true, w.ocena);
                        }
                    }
                    // wywolanie rekurencyjne dla potomkow
                    for (int i = 0; i < w.Lpotomkow.Count; i++)
                        utworzDrzewo2(w.Lpotomkow.ElementAt(i), poziom + 1, zaw2, true, false, PlPom);


                }
                else
                {
                    
                    // wydaje mi sie, ze przesuwamy tutaj stany plansz we wszystkich nowych  wezlach
                    //tylko nie wiem dlaczego w.r to lista???
                    op.wykonajRuchUniwersalny(zaw2, w.r, PlPom);
                    op.tabRu.Clear();
                    Array.Copy(PlPom, 0, pl.temp, 0, PlPom.Length);                   
                    op.LBic.Clear();
                    //tutaj bylo generowanie bic owiec ktore u nas nie bija ale zostawmy
                    op.generujBiciaWilkow(Zawodnik, pl);
                    for (int j = 0; j < op.LBic.Count; j++)
                    {
                        Console.WriteLine("poziom " + poziom + " kulka: " + j + ": dodaje wezel bicia: ");
                        w.dodajWezel(op.LBic.ElementAt(j).lRuchBic, Min, Max, w.ocena);
                    }


                    if (op.LBic.Count == 0)//tylko jeśli nie ma bić to dodajemy jako potomkow mozliwe ruchy
                    {
                        op.generujMozliweRuchyOwiec(Zawodnik, pl);
                        for (int j = 0; j < op.tabRu.Count; j++)
                        {
                            Console.WriteLine("poziom " + poziom +" kulka: "+ j+ ": dodaje wezel ruchu: [" + op.tabRu[j].skad.x + "," + op.tabRu[j].skad.y + "] -->" + "[" + op.tabRu[j].dokad.x + "," + op.tabRu[j].dokad.y + "]");
                            w.dodajWezel(op.tabRu.ElementAt(j), Min, Max, w.ocena);
                        }
                    }
                    for (int i = 0; i < w.Lpotomkow.Count; i++)
                        utworzDrzewo2(w.Lpotomkow.ElementAt(i), poziom + 1, zaw2, Min2, Max2, PlPom);
                    

                }

            }
        }
        public void MinMax(Wezel w)
        {
            if (w.max == true)
            {
                if (w.Lpotomkow.ElementAt(0).Lpotomkow.Count != 0)
                    for (int i = 0; i < w.Lpotomkow.Count; i++)
                        MinMax(w.Lpotomkow.ElementAt(i));
                w.ocena = w.Lpotomkow.Max(x => x.ocena);
            }
            else if (w.min == true)
            {
                if (w.Lpotomkow.ElementAt(0).Lpotomkow.Count != 0)
                    for (int i = 0; i < w.Lpotomkow.Count; i++)
                        MinMax(w.Lpotomkow.ElementAt(i));
                w.ocena = w.Lpotomkow.Min(x => x.ocena);
            }
        }

        public int alfaBeta(Wezel w, int a, int b)
        {
            if (w.Lpotomkow.Count == 0)
                return w.ocena;
            if (w.max == true)
            {
                for (int i = 0; i < w.Lpotomkow.Count; i++)
                {
                    a = Math.Max(a, alfaBeta(w.Lpotomkow.ElementAt(i), a, b));
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
                for (int i = 0; i < w.Lpotomkow.Count; i++)
                {
                    b = Math.Min(b, alfaBeta(w.Lpotomkow.ElementAt(i), a, b));
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

        public List<Ruch> ZwrocRuchKomputera()
        {
            root.r = root.Lpotomkow.Find(x => x.ocena == root.ocena).r;
            return root.r;
        }
        public List<Ruch> ZwrocRuchKomputera2(int z)
        {
            try
            {
                root.r = root.Lpotomkow.Find(x => x.ocena == z).r;
                return root.r;
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
            //root.r = root.Lpotomkow.Find(x => x.ocena == alfaBeta(root)).r;
        }


    }
}

