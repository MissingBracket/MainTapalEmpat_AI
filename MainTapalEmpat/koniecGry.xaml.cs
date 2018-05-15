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
using System.Windows.Shapes;

namespace MainTapalEmpat
{
    /// <summary>
    /// Interaction logic for koniecGry.xaml
    /// </summary>
    public partial class koniecGry : Window
    {
        MainWindow main;
        public koniecGry(bool wygrana, MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            if (wygrana == true)
            {
                
                label.Content = "Wygrałeś! Gratulacje!";
            }
            else
            {
                
                label.Content = "Niestety przegrałeś.";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            main.Close();
            this.Close();
            
        }
    }
}
