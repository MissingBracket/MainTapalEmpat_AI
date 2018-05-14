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
        Plansza plansza;
        Boolean tura_gracza = false;
        Operacje operacje;
        int licznik_tygrysow = 0;
        int licznik_owieczek = 0;
        int aktualna_liczba_owieczek = 0;
        int licznik_poczatkowych_tur = 3;
        private Drzewo drzewo;

        private bool pierwszyKlik = false;

        int a = 0;
        int b = 0;

        public MainWindow()
        {
            InitializeComponent();
            plansza = new Plansza();
            operacje = new Operacje();
            drzewo = new Drzewo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                
        }
        private void z1Btn_Click(object sender, RoutedEventArgs e)
        {
            Button piece = (Button)sender;
            debugBox.Text = "Btn style: " + piece.Style.ToString();
           
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
            }

            //ruch gracza
            else if (tura_gracza == true && licznik_owieczek >= licznik_poczatkowych_tur)
            {
                ruchGracza(piece);
                //nowe drzewo   
            }
        

        }
        private void ruchGracza(Button piece)
        {
            debugBox.Text = "zacznij";


            if (pierwszyKlik == false)
            {
                debugBox.Text = "zacznij1";
                a = Convert.ToInt32(Char.GetNumericValue(piece.Name[3]));
                b = Convert.ToInt32(Char.GetNumericValue(piece.Name[4]));
                if (plansza.stan[a,b] == 2)
                {
                    pierwszyKlik = true;
                    //zakreslona owieczka grafika
                    //piece.Style = FindResource("sheepPointed") as Style;
                }
                return;
            }
            if (pierwszyKlik == true)
            {
                debugBox.Text = "zacznij2";
                int x1 = Convert.ToInt32(Char.GetNumericValue(piece.Name[3]));
                int y1 = Convert.ToInt32(Char.GetNumericValue(piece.Name[4]));
                if (a != x1 || b != y1)
                {
                    Ruch r = new Ruch();
                    r.skad.x = a;
                    r.skad.y = b;
                    r.dokad.x = x1;
                    r.dokad.y = y1;
                    uaktualnijWizualizacjePlanszyOwiec(r);
                    plansza.stan[a, b] = 0;
                    plansza.stan[x1, y1] = 2;
                    plansza.pokazStanPlanszy();
                    pierwszyKlik = false;
                    tura_gracza = false;
                    ruchKomputera2();

                }
                else
                {
                    //normalna owieczka grafika
                    piece.Style = FindResource("sheep") as Style;
                    debugBox.Text = "wybierz pionek";
                    pierwszyKlik = false;
                }
                
            }
        }
        private void ruchKomputera2()
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
            plansza.pokazStanPlanszy();
            drzewo.plansza_poczatkowa.uaktualnijStanPlanszy(plansza.stan);
            drzewo.utworzDrzewo();

            int wartoscAlfaBeta = drzewo.alfaBeta(drzewo.root, 10, -10);
            Ruch r = drzewo.zwrocRuchKomputera(wartoscAlfaBeta);
            if (r.bicie == true)
            {
                aktualna_liczba_owieczek--;
            }
            operacje.wykonajRuchIZmienStanPlanszy(1, r, plansza.stan);
            uaktualnijWizualizacjePlanszyTygrysow(r);
            Console.WriteLine("//////////////////////////");
            //plansza.pokazStanPlanszy();
            tura_gracza = true;

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
            plansza.pokazStanPlanszy();
            drzewo.plansza_poczatkowa.uaktualnijStanPlanszy(plansza.stan);
            drzewo.utworzDrzewo();

            int wartoscAlfaBeta = drzewo.alfaBeta(drzewo.root, 10, -10);
            Ruch r = drzewo.zwrocRuchKomputera(wartoscAlfaBeta);
            if (r.bicie == true)
            {
                aktualna_liczba_owieczek--;
            }
            operacje.wykonajRuchIZmienStanPlanszy(1, r, plansza.stan);
            uaktualnijWizualizacjePlanszyTygrysow(r);
            Console.WriteLine("//////////////////////////");
            //plansza.pokazStanPlanszy();
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
            debugBox.Text = "TouchedPiece : " + piece.Name;
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
            debugBox.Text = "TouchedPiece : " + piece.Name;       
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
