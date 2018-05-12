using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class Operacje
    {
        public List<Ruch> ListaRuchow = new List<Ruch>();
        public List<Ruch> ListaBic = new List<Ruch>(); //Lista zawierająca listę możliwych do wykonania bić przez wilka w danym czasie
        public void generujMozliweRuchyOwiec(int Zawodnik, Plansza pl)
        {
            for (int i = 0; i < 9; i = i + 2)
            {
                for (int j = 0; j < 9; j = j + 2)
                {

                    if (pl.temp[i, j] == 0)
                    {
                        if (i - 2 >= 0)
                            if (pl.temp[i - 2, j] == Zawodnik && pl.temp[i - 1, j] == 4)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i - 2; r.skad.y = j;
                                r.dokad.x = i; r.dokad.y = j;
                                ListaRuchow.Add(r);
                            }
                        if (i - 2 >= 0 && j + 2 <= 8)
                            if (pl.temp[i - 2, j + 2] == Zawodnik && pl.temp[i - 1, j + 1] == 5)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i - 2; r.skad.y = j + 2;
                                r.dokad.x = i; r.dokad.y = j;
                                ListaRuchow.Add(r);
                            }
                        if (j + 2 <= 8)
                            if (pl.temp[i, j + 2] == Zawodnik && pl.temp[i, j + 1] == 3)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i; r.skad.y = j + 2;
                                r.dokad.x = i; r.dokad.y = j;
                                ListaRuchow.Add(r);
                            }
                        if (j + 2 <= 8 && i + 2 <= 8)
                            if (pl.temp[i + 2, j + 2] == Zawodnik && pl.temp[i + 1, j + 1] == 6)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i + 2; r.skad.y = j + 2;
                                r.dokad.x = i; r.dokad.y = j;
                                ListaRuchow.Add(r);
                            }
                        if (i + 2 <= 8)
                            if (pl.temp[i + 2, j] == Zawodnik && pl.temp[i + 1, j] == 4)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i + 2; r.skad.y = j;
                                r.dokad.x = i; r.dokad.y = j;
                                ListaRuchow.Add(r);
                            }
                        if (j - 2 >= 0 && i + 2 <= 8)
                            if (pl.temp[i + 2, j - 2] == Zawodnik && pl.temp[i + 1, j - 1] == 5)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i + 2; r.skad.y = j - 2;
                                r.dokad.x = i; r.dokad.y = j;
                                ListaRuchow.Add(r);
                            }
                        if (j - 2 >= 0)
                            if (pl.temp[i, j - 2] == Zawodnik && pl.temp[i, j - 1] == 3)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i; r.skad.y = j - 2;
                                r.dokad.x = i; r.dokad.y = j;
                                ListaRuchow.Add(r);
                            }
                        if (j - 2 >= 0 && i - 2 >= 0)
                            if (pl.temp[i - 2, j - 2] == Zawodnik && pl.temp[i - 1, j - 1] == 6)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i - 2; r.skad.y = j - 2;
                                r.dokad.x = i; r.dokad.y = j;
                                ListaRuchow.Add(r);
                            }
                    }
                }
            }
        }
        public void generujMozliweRuchyWilkow(int Zawodnik, Plansza pl)
        {
            for (int i = 0; i < 9; i = i + 2)
            {
                for (int j = 0; j < 9; j = j + 2)
                {

                    if (pl.temp[i, j] == 0)
                    {
                        //przejscie gora
                        if (i + 2 <= 8)
                            if (pl.temp[i + 2, j] == Zawodnik && pl.temp[i + 1, j] == 4)
                            {
                                int a = i;
                                while (a >= 0)
                                {
                                    if (pl.temp[a, j] == 0 && pl.temp[a + 1, j] == 4)
                                    {
                                        Ruch ri = new Ruch();
                                        ri.skad.x = i + 2; ri.skad.y = j;
                                        ri.dokad.x = a; ri.dokad.y = j;
                                        ListaRuchow.Add(ri);
                                        a -= 2;
                                        // Console.WriteLine("dodatkowy");

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                            }
                        //przejscie dol
                        if (i - 2 >= 0)
                            if (pl.temp[i - 2, j] == Zawodnik && pl.temp[i - 1, j] == 4)
                            {
                                int a = i;
                                while (a <= 8)
                                {
                                    if (pl.temp[a, j] == 0 && pl.temp[a - 1, j] == 4)
                                    {
                                        Ruch ri = new Ruch();
                                        ri.skad.x = i - 2; ri.skad.y = j;
                                        ri.dokad.x = a; ri.dokad.y = j;
                                        ListaRuchow.Add(ri);
                                        a += 2;
                                        // Console.WriteLine("dodatkowy");

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                        //przejscie lewo
                        if (j + 2 <= 8)
                            if (pl.temp[i, j + 2] == Zawodnik && pl.temp[i, j + 1] == 3)
                            {
                                int a = j;
                                while (a >= 0)
                                {
                                    if (pl.temp[i, a] == 0 && pl.temp[i, a + 1] == 3)
                                    {
                                        Ruch ri = new Ruch();
                                        ri.skad.x = i; ri.skad.y = j + 2;
                                        ri.dokad.x = i; ri.dokad.y = a;
                                        ListaRuchow.Add(ri);
                                        a -= 2;
                                        // Console.WriteLine("dodatkowy");

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        //przejscie prawo
                        if (j - 2 >= 0)
                            if (pl.temp[i, j - 2] == Zawodnik && pl.temp[i, j - 1] == 3)
                            {
                                int a = j;
                                while (a <= 8)
                                {
                                    if (pl.temp[i, a] == 0 && pl.temp[i, a - 1] == 3)
                                    {
                                        Ruch ri = new Ruch();
                                        ri.skad.x = i; ri.skad.y = j - 2;
                                        ri.dokad.x = i; ri.dokad.y = a;
                                        ListaRuchow.Add(ri);
                                        a += 2;
                                        // Console.WriteLine("dodatkowy");

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        //przejscie lewo gora
                        if (j + 2 <= 8 && i + 2 <= 8)
                            if (pl.temp[i + 2, j + 2] == Zawodnik && pl.temp[i + 1, j + 1] == 6)
                            {
                                int a = i;
                                int b = j;
                                while (a >= 0 && b >= 0)
                                {
                                    if (pl.temp[a, b] == 0 && pl.temp[a + 1, b + 1] == 6)
                                    {
                                        Ruch ri = new Ruch();
                                        ri.skad.x = i + 2; ri.skad.y = j + 2;
                                        ri.dokad.x = a; ri.dokad.y = b;
                                        ListaRuchow.Add(ri);
                                        a -= 2;
                                        b -= 2;
                                        // Console.WriteLine("dodatkowy");

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                            }
                        //przejscie dol-lewo
                        if (i - 2 >= 0 && j + 2 <= 8)
                            if (pl.temp[i - 2, j + 2] == Zawodnik && pl.temp[i - 1, j + 1] == 5)
                            {
                                int a = i;
                                int b = j;
                                while (a <= 8 && b >= 0)
                                {
                                    if (pl.temp[a, b] == 0 && pl.temp[a - 1, b + 1] == 5)
                                    {
                                        Ruch ri = new Ruch();
                                        ri.skad.x = i - 2; ri.skad.y = j + 2;
                                        ri.dokad.x = a; ri.dokad.y = b;
                                        ListaRuchow.Add(ri);
                                        a += 2;
                                        b -= 2;
                                        // Console.WriteLine("dodatkowy");

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        //przejscie prawo gora
                        if (j - 2 >= 0 && i + 2 <= 8)
                            if (pl.temp[i + 2, j - 2] == Zawodnik && pl.temp[i + 1, j - 1] == 5)
                            {
                                int a = i;
                                int b = j;
                                while (a >= 0 && b <= 8)
                                {
                                    if (pl.temp[a, b] == 0 && pl.temp[a + 1, b - 1] == 5)
                                    {
                                        Ruch ri = new Ruch();
                                        ri.skad.x = i + 2; ri.skad.y = j - 2;
                                        ri.dokad.x = a; ri.dokad.y = b;
                                        ListaRuchow.Add(ri);
                                        a -= 2;
                                        b += 2;
                                        // Console.WriteLine("dodatkowy");

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                        //przejscie prawo dol
                        if (j - 2 >= 0 && i - 2 >= 0)
                            if (pl.temp[i - 2, j - 2] == Zawodnik && pl.temp[i - 1, j - 1] == 6)
                            {
                                int a = i;
                                int b = j;
                                while (a <= 8 && b <= 8)
                                {
                                    if (pl.temp[a, b] == 0 && pl.temp[a - 1, b - 1] == 6)
                                    {
                                        Ruch ri = new Ruch();
                                        ri.skad.x = i - 2; ri.skad.y = j - 2;
                                        ri.dokad.x = a; ri.dokad.y = b;
                                        ListaRuchow.Add(ri);
                                        a += 2;
                                        b += 2;
                                        // Console.WriteLine("dodatkowy");

                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                    }
                }
            }
        }
        public void wypiszMozliweRuchy(List<Ruch> tabRu)
        {
            Console.WriteLine("Mozliwe ruchy:");
            for (int a = 0; a < tabRu.Count(); a++)
            {
                Console.WriteLine("skad: " + tabRu.ElementAt(a).skad.x.ToString() + "," + tabRu.ElementAt(a).skad.y.ToString() + " ==> " +
               "dokad: " + tabRu.ElementAt(a).dokad.x.ToString() + "," + tabRu.ElementAt(a).dokad.y.ToString());
                Console.WriteLine();
            }
        }
        public void wypiszMozliweBicia(List<Ruch> tabRu)
        {
            Console.WriteLine("Mozliwe bicia:");
            for (int a = 0; a < tabRu.Count(); a++)
            {
                Console.WriteLine("skad: " + tabRu.ElementAt(a).skad.x.ToString() + "," + tabRu.ElementAt(a).skad.y.ToString() + " ==> " +
               "dokad: " + tabRu.ElementAt(a).dokad.x.ToString() + "," + tabRu.ElementAt(a).dokad.y.ToString());
                Console.WriteLine();
            }
        }
        public void generujBiciaWilkow(int Zawodnik, Plansza pl)
        {
            for (int i = 0; i < 9; i = i + 2)
            {
                for (int j = 0; j < 9; j = j + 2)
                {
                    if (pl.temp[i, j] == 0)
                    {
                        if (i + 4 <= 8)
                            if (pl.temp[i + 4, j] == Zawodnik && pl.temp[i + 2, j] != Zawodnik && pl.temp[i + 2, j] != 0 && pl.temp[i + 3, j] == 4 && pl.temp[i + 1, j] == 4)
                            {
                                Ruch ri = new Ruch();
                                ri.bicie = true;
                                ri.bityPionek.x = i + 2;
                                ri.bityPionek.y = j;
                                ri.skad.x = i+4; ri.skad.y = j;
                                ri.dokad.x = i; ri.dokad.y = j;
                                ListaBic.Add(ri);
                                //PrzypiszRuch_ZmienStanPlanszy(Zawodnik, i, j, pl, 4, 0);

                            }
                        if (i + 4 <= 8 && j + 4 <= 8)
                            if (pl.temp[i + 4, j + 4] == Zawodnik && pl.temp[i + 2, j + 2] != Zawodnik && pl.temp[i + 2, j + 2] != 0 && pl.temp[i + 3, j + 3] == 6 && pl.temp[i + 1, j + 1] == 6)
                            {
                                Ruch ri = new Ruch();
                                ri.bicie = true;
                                ri.bityPionek.x = i + 2;
                                ri.bityPionek.y = j + 2;
                                ri.skad.x = i + 4; ri.skad.y = j+4;
                                ri.dokad.x = i; ri.dokad.y = j;
                                ListaBic.Add(ri);

                            }
                        if (j + 4 <= 8)
                            if (pl.temp[i, j + 4] == Zawodnik && pl.temp[i, j + 2] != Zawodnik && pl.temp[i, j + 2] != 0 && pl.temp[i, j + 3] == 3 && pl.temp[i, j + 1] == 3)
                            {
                                Ruch ri = new Ruch();
                                ri.bicie = true;
                                ri.bityPionek.x = i ;
                                ri.bityPionek.y = j + 2;
                                ri.skad.x = i; ri.skad.y = j +4;
                                ri.dokad.x = i; ri.dokad.y = j;
                                ListaBic.Add(ri);
                            }
                        if (i - 4 >= 0 && j + 4 <= 8)
                            if (pl.temp[i - 4, j + 4] == Zawodnik && pl.temp[i - 2, j + 2] != Zawodnik && pl.temp[i - 2, j + 2] != 0 && pl.temp[i - 3, j + 3] == 5 && pl.temp[i - 1, j + 1] == 5)
                            {
                                Ruch ri = new Ruch();
                                ri.bicie = true;
                                ri.bityPionek.x = i - 2;
                                ri.bityPionek.y = j + 2;
                                ri.skad.x = i - 4; ri.skad.y = j+4;
                                ri.dokad.x = i; ri.dokad.y = j;
                                ListaBic.Add(ri);
                            }
                        if (i - 4 >= 0)
                            if (pl.temp[i - 4, j] == Zawodnik && pl.temp[i - 2, j] != Zawodnik && pl.temp[i - 2, j] != 0 && pl.temp[i - 3, j] == 4 && pl.temp[i - 1, j] == 4)
                            {
                                Ruch ri = new Ruch();
                                ri.bicie = true;
                                ri.bityPionek.x = i - 2;
                                ri.bityPionek.y = j;
                                ri.skad.x = i -4; ri.skad.y = j;
                                ri.dokad.x = i; ri.dokad.y = j;
                                ListaBic.Add(ri);
                            }
                        if (i - 4 >= 0 && j - 4 >= 0)
                            if (pl.temp[i - 4, j - 4] == Zawodnik && pl.temp[i - 2, j - 2] != Zawodnik && pl.temp[i - 2, j - 2] != 0 && pl.temp[i - 3, j - 3] == 6 && pl.temp[i - 1, j - 1] == 6)
                            {
                                Ruch ri = new Ruch();
                                ri.bicie = true;
                                ri.bityPionek.x = i - 2;
                                ri.bityPionek.y = j - 2;
                                ri.skad.x = i - 4; ri.skad.y = j - 4;
                                ri.dokad.x = i; ri.dokad.y = j;
                                ListaBic.Add(ri);
                            }
                        if (j - 4 >= 0)
                            if (pl.temp[i, j - 4] == Zawodnik && pl.temp[i, j - 2] != Zawodnik && pl.temp[i, j - 2] != 0 && pl.temp[i, j - 3] == 3 && pl.temp[i, j - 1] == 3)
                            {
                                Ruch ri = new Ruch();
                                ri.bicie = true;
                                ri.bityPionek.x = i;
                                ri.bityPionek.y = j - 2;
                                ri.skad.x = i ; ri.skad.y = j -4 ;
                                ri.dokad.x = i; ri.dokad.y = j;
                                ListaBic.Add(ri);
                            }
                        if (i + 4 <= 8 && j - 4 >= 0)
                            if (pl.temp[i + 4, j - 4] == Zawodnik && pl.temp[i + 2, j - 2] != Zawodnik && pl.temp[i + 2, j - 2] != 0 && pl.temp[i + 3, j - 3] == 5 && pl.temp[i + 1, j - 1] == 5)
                            {
                                Ruch ri = new Ruch();
                                ri.bicie = true;
                                ri.bityPionek.x = i + 2;
                                ri.bityPionek.y = j - 2;
                                ri.skad.x = i + 4; ri.skad.y = j - 4;
                                ri.dokad.x = i; ri.dokad.y = j;
                                ListaBic.Add(ri);
                            }
                    }
                }
            }
            //Console.WriteLine(LBic.Count);
        }
       
        public void wykonajRuchIZmienStanPlanszy(int zawodnik, Ruch ruch, int[,] plansza)
        {

            if (ruch.bicie)// jeżeli jest to bicie to w miejscu zbijanego pionka wpisujemy 0
            {
                plansza[ruch.bityPionek.x, ruch.bityPionek.y] = 0;
            }
            plansza[ruch.skad.x, ruch.skad.y] = 0;
            plansza[ruch.dokad.x, ruch.dokad.y] = zawodnik;

        }
        
    }
}
