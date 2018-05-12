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

        static Drzewo tree = new Drzewo();

        public MainWindow()
        {
            InitializeComponent();
            plansza = new Plansza();
            operacje = new Operacje();

           

            operacje.generujBiciaWilkow(1,plansza);
            operacje.wypiszMozliweBicia(operacje.ListaBic);
            //plansza.pokazStanPlanszy();
            //operacje.wykonajRuchIZmienStanPlanszy(2, operacje.ListaBic.ElementAt(0), plansza.stan);
            //Console.WriteLine();
            //plansza.pokazStanPlanszy();
            Drzewo drzewo = new Drzewo();
            drzewo.utworzDrzewo();

            int z =  drzewo.alfaBeta(drzewo.root, -10, 0);
            Console.WriteLine(z + " zzzzzzzzzz");
            


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
            else if (tura_gracza == true && licznik_owieczek < 18)
            {
                dodajOwieczke(piece);
                licznik_owieczek++;
                tura_gracza = true;
            }
            //ruch komputera 
            else if (tura_gracza == false)
            {
                //komputer robi ruch
            }
            //ruch gracza
            else if (tura_gracza == true && licznik_owieczek >= 18)
            {
                
            }
            if (licznik_owieczek == 18 && licznik_tygrysow == 2)
            {
                debugBox.Text = "Pionki rozstawione";
            }

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
            if (licznik_tygrysow == 2)
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
        }
        private void dodajTygrysa(Button piece)
        {
            int x = Convert.ToInt32(Char.GetNumericValue(piece.Name[3]));
            int y = Convert.ToInt32(Char.GetNumericValue(piece.Name[4]));
            piece.Style = FindResource("tiger") as Style;
            debugBox.Text = "TouchedPiece : " + piece.Name;       
            plansza.dodajOwieczkeDoPlanszy(x, y);
        }

    }
}
