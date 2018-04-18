using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class Operacje
    {
        public List<Ruch> tabRu = new List<Ruch>();

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
    }
}
