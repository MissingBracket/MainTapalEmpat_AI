using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class Operacje
    {
        public List<Ruch> tabRu = new List<Ruch>();
        public List<Bicie> LBic = new List<Bicie>(); //Lista zawierająca listę możliwych do wykonania bić przez wilka w danym czasie
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
                                tabRu.Add(r);
                            }
                        if (i - 2 >= 0 && j + 2 <= 8)
                            if (pl.temp[i - 2, j + 2] == Zawodnik && pl.temp[i - 1, j + 1] == 5)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i - 2; r.skad.y = j + 2;
                                r.dokad.x = i; r.dokad.y = j;
                                tabRu.Add(r);
                            }
                        if (j + 2 <= 8)
                            if (pl.temp[i, j + 2] == Zawodnik && pl.temp[i, j + 1] == 3)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i; r.skad.y = j + 2;
                                r.dokad.x = i; r.dokad.y = j;
                                tabRu.Add(r);
                            }
                        if (j + 2 <= 8 && i + 2 <= 8)
                            if (pl.temp[i + 2, j + 2] == Zawodnik && pl.temp[i + 1, j + 1] == 6)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i + 2; r.skad.y = j + 2;
                                r.dokad.x = i; r.dokad.y = j;
                                tabRu.Add(r);
                            }
                        if (i + 2 <= 8)
                            if (pl.temp[i + 2, j] == Zawodnik && pl.temp[i + 1, j] == 4)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i + 2; r.skad.y = j;
                                r.dokad.x = i; r.dokad.y = j;
                                tabRu.Add(r);
                            }
                        if (j - 2 >= 0 && i + 2 <= 8)
                            if (pl.temp[i + 2, j - 2] == Zawodnik && pl.temp[i + 1, j - 1] == 5)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i + 2; r.skad.y = j - 2;
                                r.dokad.x = i; r.dokad.y = j;
                                tabRu.Add(r);
                            }
                        if (j - 2 >= 0)
                            if (pl.temp[i, j - 2] == Zawodnik && pl.temp[i, j - 1] == 3)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i; r.skad.y = j - 2;
                                r.dokad.x = i; r.dokad.y = j;
                                tabRu.Add(r);
                            }
                        if (j - 2 >= 0 && i - 2 >= 0)
                            if (pl.temp[i - 2, j - 2] == Zawodnik && pl.temp[i - 1, j - 1] == 6)
                            {
                                Ruch r = new Ruch();
                                r.skad.x = i - 2; r.skad.y = j - 2;
                                r.dokad.x = i; r.dokad.y = j;
                                tabRu.Add(r);
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
                                        tabRu.Add(ri);
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
                                        tabRu.Add(ri);
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
                                        tabRu.Add(ri);
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
                                        tabRu.Add(ri);
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
                                        tabRu.Add(ri);
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
                                        tabRu.Add(ri);
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
                                        tabRu.Add(ri);
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
                                        tabRu.Add(ri);
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
        public void wypiszMozliweRuchy()
        {
            Console.WriteLine("Mozliwe ruchy:");
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
                                PrzypiszRuch_ZmienStanPlanszy(Zawodnik, i, j, pl, 4, 0);

                            }
                        if (i + 4 <= 8 && j + 4 <= 8)
                            if (pl.temp[i + 4, j + 4] == Zawodnik && pl.temp[i + 2, j + 2] != Zawodnik && pl.temp[i + 2, j + 2] != 0 && pl.temp[i + 3, j + 3] == 6 && pl.temp[i + 1, j + 1] == 6)
                            {
                                PrzypiszRuch_ZmienStanPlanszy(Zawodnik, i, j, pl, 4, 4);

                            }
                        if (j + 4 <= 8)
                            if (pl.temp[i, j + 4] == Zawodnik && pl.temp[i, j + 2] != Zawodnik && pl.temp[i, j + 2] != 0 && pl.temp[i, j + 3] == 3 && pl.temp[i, j + 1] == 3)
                            {
                                PrzypiszRuch_ZmienStanPlanszy(Zawodnik, i, j, pl, 0, 4);
                            }
                        if (i - 4 >= 0 && j + 4 <= 8)
                            if (pl.temp[i - 4, j + 4] == Zawodnik && pl.temp[i - 2, j + 2] != Zawodnik && pl.temp[i - 2, j + 2] != 0 && pl.temp[i - 3, j + 3] == 5 && pl.temp[i - 1, j + 1] == 5)
                            {
                                PrzypiszRuch_ZmienStanPlanszy(Zawodnik, i, j, pl, -4, 4);
                            }
                        if (i - 4 >= 0)
                            if (pl.temp[i - 4, j] == Zawodnik && pl.temp[i - 2, j] != Zawodnik && pl.temp[i - 2, j] != 0 && pl.temp[i - 3, j] == 4 && pl.temp[i - 1, j] == 4)
                            {
                                PrzypiszRuch_ZmienStanPlanszy(Zawodnik, i, j, pl, -4, 0);
                            }
                        if (i - 4 >= 0 && j - 4 >= 0)
                            if (pl.temp[i - 4, j - 4] == Zawodnik && pl.temp[i - 2, j - 2] != Zawodnik && pl.temp[i - 2, j - 2] != 0 && pl.temp[i - 3, j - 3] == 6 && pl.temp[i - 1, j - 1] == 6)
                            {
                                PrzypiszRuch_ZmienStanPlanszy(Zawodnik, i, j, pl, -4, -4);
                            }
                        if (j - 4 >= 0)
                            if (pl.temp[i, j - 4] == Zawodnik && pl.temp[i, j - 2] != Zawodnik && pl.temp[i, j - 2] != 0 && pl.temp[i, j - 3] == 3 && pl.temp[i, j - 1] == 3)
                            {
                                PrzypiszRuch_ZmienStanPlanszy(Zawodnik, i, j, pl, 0, -4);
                            }
                        if (i + 4 <= 8 && j - 4 >= 0)
                            if (pl.temp[i + 4, j - 4] == Zawodnik && pl.temp[i + 2, j - 2] != Zawodnik && pl.temp[i + 2, j - 2] != 0 && pl.temp[i + 3, j - 3] == 5 && pl.temp[i + 1, j - 1] == 5)
                            {
                                PrzypiszRuch_ZmienStanPlanszy(Zawodnik, i, j, pl, 4, -4);
                            }
                    }
                }
            }
        }
        private void PrzypiszRuch_ZmienStanPlanszy(int Zawodnik, int i, int j, Plansza pl, int x, int y) //funkcja pomocnicza mająca na celu zmienić stan planszy po wykonaniu możliwego bicia
        {
            Ruch r = new Ruch();
            r.skad.x = i + x; r.skad.y = j + y;
            r.dokad.x = i; r.dokad.y = j;
            r.bityPionek.x = i + x / 2;
            r.bityPionek.y = j + y / 2;
            r.bicie = true;
            Bicie b = new Bicie();
            b.lRuchBic.Add(r);
            pl.temp[i, j] = Zawodnik;
            pl.temp[i + x, j + y] = 0;
            pl.temp[i + x / 2, j + y / 2] = 0;
            RozbijListe2(b);
            LBic.Add(b);
            Array.Copy(pl.stan, 0, pl.temp, 0, pl.stan.Length);
        }
        private void RozbijListe2(Bicie b)
        {
            for (int i = 1; i < b.lRuchBic.Count + 1; i++)
            {
                Bicie b1 = new Bicie();
                if (i == b.lRuchBic.Count)
                {
                    b1.lRuchBic.Add(b.lRuchBic.ElementAt(i - 1));
                    int x = b.lRuchBic.ElementAt(i - 1).poziom;
                    int j = i - 2;
                    while (j >= 0)
                    {
                        if (x - 1 == b.lRuchBic.ElementAt(j).poziom)
                        {
                            x--;
                            b1.lRuchBic.Add(b.lRuchBic.ElementAt(j));
                        }
                        j--;
                    }
                    b1.lRuchBic.Reverse(0, b1.lRuchBic.Count);
                    LBic.Add(b1);
                }
                else
                {
                    if (b.lRuchBic.ElementAt(i - 1).poziom >= b.lRuchBic.ElementAt(i).poziom)
                    {
                        b1.lRuchBic.Add(b.lRuchBic.ElementAt(i - 1));
                        int x = b.lRuchBic.ElementAt(i - 1).poziom;
                        int j = i - 2;
                        while (j >= 0)
                        {
                            if (x - 1 == b.lRuchBic.ElementAt(j).poziom)
                            {
                                x--;
                                b1.lRuchBic.Add(b.lRuchBic.ElementAt(j));
                            }
                            j--;
                        }
                        b1.lRuchBic.Reverse(0, b1.lRuchBic.Count);
                        LBic.Add(b1);
                    }
                }
            }
        } 
    }
}
