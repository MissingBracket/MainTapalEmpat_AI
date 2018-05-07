﻿using System;
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
        Operacje operacje;
        int licznik_tygrysow = 0;
        int licznik_owieczek = 0;

        public MainWindow()
        {
            InitializeComponent();
            plansza = new Plansza();
            operacje = new Operacje();



            //komputer robi ruch

            Tree tree = new Tree(0);
            //dwa wilki
            tree.root.children.Add(new Tree_Node(0));
            tree.root.children.Add(new Tree_Node(0));

            operacje.generujMozliweRuchyWilkow(2, plansza);
            operacje.wypiszMozliweRuchy();
            //operacje.generujBiciaWilkow(1, plansza);
            List<List<List<Ruch>>> doDodania = new List<List<List<Ruch>>>();
            List<List<Ruch>> naWezel = new List<List<Ruch>>();
            for (int i = 0; i < 25; i++) ;
                naWezel.Add(operacje.tabRu);
            doDodania.Add(naWezel);
            for (int i=0; i<25; i++)
            {
                tree.insertMoves(tree.root.children[0], doDodania);
            }
            tree.traverse(tree.root);



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                
        }
        private void z1Btn_Click(object sender, RoutedEventArgs e)
        {
            Button piece = (Button)sender;
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
                

            }
            //ruch gracza
            else if( tura_gracza == true && licznik_owieczek >= 18)
            {
                //2 klikniecia = koniec tury
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
