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
        
        public MainWindow()
        {
            InitializeComponent();
            debugBox.Text = "initialised components";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //  Zarządzanie obiektem klikniętym
            //  Wykonywanie ruchu etc
            Button piece = (Button)sender;
            debugBox.Text = "TouchedPiece : " + piece.Name;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
