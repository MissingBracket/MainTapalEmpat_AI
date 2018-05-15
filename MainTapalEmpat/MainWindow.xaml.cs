using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainTapalEmpat
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] insults;
        private string[] remarks;
        Plansza plansza;
        Boolean tura_gracza = false;
        Operacje operacje;
        int licznik_tygrysow = 0;
        int licznik_owieczek = 0;
        int aktualna_liczba_owieczek = 0;
        int licznik_poczatkowych_tur = 30;
        private Drzewo drzewo;
        private Boolean phase1 = true;
        private bool pierwszyKlik = false;

        int a = 0;
        int b = 0;
        Random rand;


        public MainWindow()
        {
            InitializeComponent();
            plansza = new Plansza();
            operacje = new Operacje();
            drzewo = new Drzewo();
            rand = new Random();
            generateInsults();
            losujRozmieszczenieTygrysow();
            //debugBox.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //debugBox.set

        }
        private void generateInsults()
        {
            this.insults = new string[10];
           insults[0] = "Gdyby Polska stawiała budynki,\n jak Ty pionki, byłaby pustkowiem";
           insults[1] = "Dobry ruch, Chodakowska\npewnie jest dumna";
            insults[2] = "Czy to było przemyślane?";
            insults[3] = "Jak prawdziwa owieczka, niewinna\ni słaba";
            insults[4] = "Już jesteś martwy";
            insults[5] = "I have the eye of the tiger";
            insults[6] = "Another one bites the dust";
           insults[7] = "Wracaj do kolorowanek,\nwróć jak się podszkolisz";
            insults[8] = "Widzisz ten czerwony krzyżyk? Wciśnij go";
            insults[9] = "Get #Rekt Scrub";
            this.remarks = new string[10];
            remarks[0] = "Ciekawe, ciekawe";
            remarks[1] = "No nie uciekaj już";
            remarks[2] = "Jeszcze Cię dopadnę";
            remarks[3] = "kici kici";
            remarks[4] = "Give it to me baby";
            remarks[5] = "Zaczynam tracić cierpliwość";
            remarks[6] = "I'll be back";
            remarks[7] = "Opór jest bezcelowy";
            remarks[8] = "pssst. Stań obok, zaufaj mi";
            remarks[9] = "Czasami mnie zaskakujesz";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartWindow sw = new StartWindow();
            sw.Show();
            this.Close();
        }
        private void z1Btn_Click(object sender, RoutedEventArgs e)
        {
           
            Button piece = (Button)sender;
            //debugBox.Text = "Btn style: " + piece.Style.ToString();
            
            //2 tygrysy umieszczane na poczatku gry w srodkowym kwadracie
            if (licznik_tygrysow < 2)
            {
                umiescTygrysyNaPlanszy(piece);

            }
            //gracz rozmieszcza owieczki
            else if (tura_gracza == true && licznik_owieczek < licznik_poczatkowych_tur)
            {
                dodajOwieczke(piece);
                tura_gracza = false;
                
                ruchKomputera();
                if (licznik_owieczek == 18)
                {
                    if (aktualna_liczba_owieczek == 0)
                    {
                        koniecGry kg = new koniecGry(false, this);
                        kg.Show();
                    }
                }
            }

            //ruch gracza
            else if (tura_gracza == true && licznik_owieczek >= licznik_poczatkowych_tur)
            {
                ruchGracza(piece);
  
                MyFadingText.Text = "Pokonaj Wilki!";
                //nowe drzewo  
                //Console.WriteLine("#rekt");
                label.Content = insults[rand.Next(1,10)];
                if (aktualna_liczba_owieczek == 0)
                {
                    koniecGry kg = new koniecGry(false,this);
                    kg.Show();
                    //this.Close();
                }
            }


        }
        private void ruchGracza(Button piece)
        {
            //debugBox.Text = "zacznij";


            if (pierwszyKlik == false)
            {
                //debugBox.Text = "zacznij1";
                a = Convert.ToInt32(Char.GetNumericValue(piece.Name[3]));
                b = Convert.ToInt32(Char.GetNumericValue(piece.Name[4]));
                if (plansza.stan[a, b] == 2)
                {
                    pierwszyKlik = true;
                    //zakreslona owieczka grafika
                    //piece.Style = FindResource("sheepPointed") as Style;
                }
                return;
            }
            if (pierwszyKlik == true)
            {

                plansza.uaktualnijTempPlanszy(plansza.stan);
                operacje.generujMozliweRuchyOwiec(2, this.plansza);
               // debugBox.Text = "zacznij2";
                int x1 = Convert.ToInt32(Char.GetNumericValue(piece.Name[3]));
                int y1 = Convert.ToInt32(Char.GetNumericValue(piece.Name[4]));
                if (a != x1 || b != y1)
                {
                    Ruch r = new Ruch();
                    r.skad.x = a;
                    r.skad.y = b;
                    r.dokad.x = x1;
                    r.dokad.y = y1;
                    if (ruchJestMozliwy(r))
                    {
                        uaktualnijWizualizacjePlanszyOwiec(r);
                        plansza.stan[a, b] = 0;
                        plansza.stan[x1, y1] = 2;
                        //plansza.pokazStanPlanszy();
                        pierwszyKlik = false;
                        tura_gracza = false;
                        ruchKomputera2();
                    }
                    else
                    {
//debugBox.Text = "zly ruch!";
                        pierwszyKlik = false;
                    }


                }
                else
                {
                    //normalna owieczka grafika
                    piece.Style = FindResource("sheep") as Style;
                    //debugBox.Text = "wybierz pionek";
                    pierwszyKlik = false;
                }

            }
            sprawdzWygrana();
        }
        private void ruchKomputera2()
        {
            if (aktualna_liczba_owieczek < 6)
            {
                drzewo.ilePoziomow = 4;
            }
            else if (aktualna_liczba_owieczek >= 6 && aktualna_liczba_owieczek < 12)
            {
                drzewo.ilePoziomow = 5;
            }
            else if (aktualna_liczba_owieczek >= 12 && aktualna_liczba_owieczek <= 18)
            {
                drzewo.ilePoziomow = 6;
            }
            // plansza.pokazStanPlanszy();
            drzewo.plansza_poczatkowa.uaktualnijStanPlanszy(plansza.stan);
            drzewo.utworzDrzewoPo18();

            int wartoscAlfaBeta = drzewo.alfaBeta(drzewo.root, 10, -10);
            Ruch r = drzewo.zwrocRuchKomputera(wartoscAlfaBeta);
            if (r.bicie == true)
            {
                aktualna_liczba_owieczek--;
            }
            operacje.wykonajRuchIZmienStanPlanszy(1, r, plansza.stan);
            

            uaktualnijWizualizacjePlanszyTygrysow(r);
            //Console.WriteLine("//////////////////////////");
            //plansza.pokazStanPlanszy();
            
            tura_gracza = true;

        }
        private void sprawdzWygrana()
        {
            plansza.uaktualnijTempPlanszy(plansza.stan);
            operacje.generujBiciaWilkow(1, plansza);
            operacje.generujMozliweRuchyWilkow(1, plansza);
            if (operacje.ListaBic.Count == 0 && operacje.ListaRuchow.Count == 0)
            {
                koniecGry kg = new koniecGry(true, this);
                kg.Show();
                this.Close();
            }
           
        }
        private bool ruchJestMozliwy(Ruch ruch)
        {
            foreach (Ruch r in operacje.ListaRuchow)
            {
                if (r.skad.x == ruch.skad.x && r.skad.y == ruch.skad.y && r.dokad.x == ruch.dokad.x && r.dokad.y == ruch.dokad.y)
                {
                    return true;
                }
            }
            return false;
        }
        private void ruchKomputera()
        {
           
            if (aktualna_liczba_owieczek < 6)
            {
                drzewo.ilePoziomow = 4;
            }
            else if (aktualna_liczba_owieczek >= 6 && aktualna_liczba_owieczek < 12)
            {
                drzewo.ilePoziomow = 8;
            }
            else if (aktualna_liczba_owieczek >= 12 && aktualna_liczba_owieczek <= 18)
            {
                drzewo.ilePoziomow = 10;
            }
            //plansza.pokazStanPlanszy();
            drzewo.plansza_poczatkowa.uaktualnijStanPlanszy(plansza.stan);
            drzewo.utworzDrzewo();

            int wartoscAlfaBeta = drzewo.alfaBeta(drzewo.root, 10, -10);
            Ruch r = drzewo.zwrocRuchKomputera(wartoscAlfaBeta);
            if (r != null)
            {
                if (r.bicie == true)
                {
                    InsultBox.Source = new BitmapImage(new Uri("pack://application:,,,/resources/insult (" + rand.Next(1, 8) + ").jpg"));
                    //debugBox.Text = insults[rand.Next(1, 10)];
                    aktualna_liczba_owieczek--;
                }
                else
                {
                    InsultBox.Source = new BitmapImage(new Uri("pack://application:,,,/resources/hmm.jpg"));
                    //debugBox.Text = remarks[rand.Next(1, 10)];
                }

                operacje.wykonajRuchIZmienStanPlanszy(1, r, plansza.stan);
                uaktualnijWizualizacjePlanszyTygrysow(r);
                //Console.WriteLine("//////////////////////////");
                //plansza.pokazStanPlanszy();
                tura_gracza = true;
            }
            else
            {
                sprawdzWygrana();
            }
           
        }
        private void losujRozmieszczenieTygrysow()
        {
            Random rnd = new Random();
            int x = 2*rnd.Next(2/2, 6/2);
            int y = 2 * rnd.Next(2 / 2, 6 / 2);

            Button szukany = (Button)FindName("btn" + x + y);
            dodajTygrysa(szukany);
            licznik_tygrysow++;
            int x1 = 2 * rnd.Next(2 / 2, 6 / 2);
            int y1 = 2 * rnd.Next(2 / 2, 6 / 2);
            while (x == x1 && y1 == y)
            {
                x1 = 2 * rnd.Next(2 / 2, 6 / 2);
                y1 = 2 * rnd.Next(2 / 2, 6 / 2);
            }
            Button szukany2 = (Button)FindName("btn" + x1 + y1);
            dodajTygrysa(szukany2);
            licznik_tygrysow++;
            tura_gracza = true;

        }
        private void umiescTygrysyNaPlanszy(Button piece)
        {
            int x = Convert.ToInt32(Char.GetNumericValue(piece.Name[3]));
            int y = Convert.ToInt32(Char.GetNumericValue(piece.Name[4]));
            if (x >= 2 && x <= 6 && y >= 2 && y <= 6)
            {
                dodajTygrysa(piece);
                licznik_tygrysow++;
            }
            if (licznik_tygrysow == 1)
            {
                tura_gracza = true;
            }
        }
        private void dodajOwieczke(Button piece)
        {
            piece.Style = FindResource("sheep") as Style;
            //debugBox.Text = "TouchedPiece : " + piece.Name;
            int x = Convert.ToInt32(Char.GetNumericValue(piece.Name[3]));
            int y = Convert.ToInt32(Char.GetNumericValue(piece.Name[4]));
            plansza.dodajOwieczkeDoPlanszy(x, y);
            aktualna_liczba_owieczek++;
            licznik_owieczek++;
        }
        private void dodajTygrysa(Button piece)
        {
            int x = Convert.ToInt32(Char.GetNumericValue(piece.Name[3]));
            int y = Convert.ToInt32(Char.GetNumericValue(piece.Name[4]));
            piece.Style = FindResource("tiger") as Style;
            //debugBox.Text = "TouchedPiece : " + piece.Name;
            plansza.dodajTygrysaDoPlanszy(x, y);
        }
        private void uaktualnijWizualizacjePlanszyTygrysow(Ruch ruch)
        {
            Button szukany = (Button)FindName("btn" + ruch.skad.x + ruch.skad.y);
            szukany.Style = FindResource("emptyField") as Style;
            if (ruch.bicie == false)
            {
                szukany = (Button)FindName("btn" + ruch.dokad.x + ruch.dokad.y);
                szukany.Style = FindResource("tiger") as Style;
            }
            else
            {
                szukany = (Button)FindName("btn" + ruch.bityPionek.x + ruch.bityPionek.y);
                szukany.Style = FindResource("emptyField") as Style;

                szukany = (Button)FindName("btn" + ruch.dokad.x + ruch.dokad.y);
                szukany.Style = FindResource("tiger") as Style;
            }



        }

        private void uaktualnijWizualizacjePlanszyOwiec(Ruch ruch)
        {
            Button szukany = (Button)FindName("btn" + ruch.skad.x + ruch.skad.y);
            szukany.Style = FindResource("emptyField") as Style;
            szukany = (Button)FindName("btn" + ruch.dokad.x + ruch.dokad.y);
            szukany.Style = FindResource("sheep") as Style;
        }

       

    }
}
