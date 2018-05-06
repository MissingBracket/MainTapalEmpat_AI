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
        Boolean tura_gracza = true;

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
            if (tura_gracza == true)
            {
                dodajOwieczke(piece);
                tura_gracza = false;
            }
            else
            {
                dodajTygrysa(piece);
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
