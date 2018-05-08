using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        int licznik_tygrysow = 0;
        int licznik_owieczek = 0;
        public bool beginAction = true;
        private Button selectedPiece;
        int toChangeX, toChangeY;
        public MainWindow()
        {
            InitializeComponent();
            plansza = new Plansza();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                
        }
        private void z1Btn_Click(object sender, RoutedEventArgs e)
        {
            Button piece = (Button)sender;
            debugBox.Text = "Btn style: "+piece.Style.ToString();
            //2 tygrysy umieszczane na poczatku gry w srodkowym kwadracie
            if (licznik_tygrysow < 2 )
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
                tura_gracza = true;
            }
            //ruch gracza
            else if( tura_gracza == true && licznik_owieczek >= 18)
            {
                /*debugBox.Text = "Selected piece: " + piece.Name;
                if (!piece.Style.ToString().Contains("sheep"))
                    return;*/
                switch (beginAction)
                {
                    case true:
                        selectedPiece = piece;
                        debugBox.Text = "Selected piece for movement: " + piece.Name + " / " + piece.Style.ToString();

                        beginAction = false;
                        break;
                    case false:
                        debugBox.Text = "Selected field to move: " + piece.Name;
                        int x = Convert.ToInt32(Char.GetNumericValue(piece.Name[3]));
                        int y = Convert.ToInt32(Char.GetNumericValue(piece.Name[4]));
                        selectedPiece.Style = FindResource("emptyField") as Style;
                        licznik_owieczek--;
                        plansza.dodajOwieczkeDoPlanszy(x, y);
                        beginAction = true;
                        break;
                }
                //2 klikniecia = koniec tury
            }
            if(licznik_owieczek == 18 && licznik_tygrysow == 2)
            {
                debugBox.Text = "Pionki rozstawione";
            }
           
        }

        private void umiescTygrysyNaPlanszy(Button piece)
        {
            int x = Convert.ToInt32(Char.GetNumericValue(piece.Name[3]));
            int y = Convert.ToInt32(Char.GetNumericValue(piece.Name[4]));
            if (x >= 1 && x <= 3 && y >= 1 && y <= 3)
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
