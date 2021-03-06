﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectNIM
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private List<Pile> Piles = new List<Pile>();
        public GameLogic logic;
        bool bot;
        public Game(GameLogic gLogic, bool hasBot)
        {
            this.logic = gLogic;
            this.bot = hasBot;
            InitializeComponent();
            foreach (var pile in gLogic.Piles)
            {
                lblGameInfo.Content = $"{gLogic.ActivePlayer}'s turn!";
                Pile temp = new Pile(pile);
                temp.MouseLeftButtonDown += fillCbx;
                temp.MouseLeftButtonDown += SelectColor;
                ugrdGame.Children.Add(temp);
                Piles.Add(temp);
            }
        }

        private void SelectColor(object sender, MouseButtonEventArgs e)
        {
            Pile changeColor = (Pile)sender;
            foreach (var pile in Piles)
            {
                pile.lblItems.BorderBrush = Brushes.Black;
            }
            changeColor.lblItems.BorderBrush = Brushes.Red;
            changeColor.rbtnChoice.IsChecked = true;
            Pile temp = (Pile)sender;
            if ((string)temp.lblItems.Content != "")
                cbxChoice.IsEnabled = true;
        }


        private void fillCbx(object sender, MouseButtonEventArgs e)
        {

            cbxChoice.Items.Clear();
            Pile temp = (Pile)sender;
            string data = (string)temp.lblItems.Content;
            int count = data.Split(' ').Length;
            for (int i = 0; i < count - 1; i++)
            {
                cbxChoice.Items.Add(i + 1);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Piles.Clear();
            List<Pile> piles = new List<Pile>();
            for (int i = 0; i < ugrdGame.Children.Count; i++)
            {
                piles.Add((Pile)ugrdGame.Children[i]);
            }
            for (int i = 0; i < piles.Count; i++)
            {
                if (piles[i].IsChecked() == true)
                {
                    int.TryParse(cbxChoice.SelectedItem.ToString(), out int itemsToRemove);
                    logic.TakeFromPile(i, itemsToRemove);
                }
            }

            cbxChoice.Items.Clear();
            logic.SwitchActivePlayer();
            ugrdGame.Children.Clear();
            lblGameInfo.Content = $"{logic.ActivePlayer}'s turn!";
            foreach (var pile in logic.Piles)
            {
                Pile temp = new Pile(pile);
                temp.MouseLeftButtonDown += fillCbx;
                temp.MouseLeftButtonDown += SelectColor;
                ugrdGame.Children.Add(temp);
                Piles.Add(temp);
            }


            if (bot && logic.ActivePlayer.Equals("Robot Overlord") && !logic.IsGameOver())
            {
                lblGameInfo.Content = $"{logic.ActivePlayer}'s turn!";
                //Thread.Sleep(1000);
                int pile = logic.RobotPileChoice();
                int numberToRemove = logic.RobotPieceChoice(pile);
                MessageBox.Show($"Pile: {pile}\nNumber to remove: {numberToRemove}");
                logic.TakeFromPile(pile, numberToRemove);

                cbxChoice.Items.Clear();
                logic.SwitchActivePlayer();
                ugrdGame.Children.Clear();
                lblGameInfo.Content = $"{logic.ActivePlayer}'s turn!";
                foreach (var pile1 in logic.Piles)
                {
                    Pile temp = new Pile(pile1);
                    temp.MouseLeftButtonDown += fillCbx;
                    temp.MouseLeftButtonDown += SelectColor;
                    ugrdGame.Children.Add(temp);
                }
            }
            if (logic.IsGameOver())
            {
                EndScreen end = new EndScreen(logic);
                end.Show();
                Close();
            }

            btnSubmit.IsEnabled = false;
            cbxChoice.IsEnabled = false;
        }

        private void cbxChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnSubmit.IsEnabled = true;
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgBoxResult = MessageBox.Show("Are you sure you want to restart the game"
                , "Restarting Game!", MessageBoxButton.YesNo);

            if (msgBoxResult == MessageBoxResult.Yes)
            {
                logic.InitializePiles(logic.Difficulty);
                logic.ActivePlayer = logic.Players[0];

                ugrdGame.Children.Clear();

                foreach (var pile in logic.Piles)
                {
                    lblGameInfo.Content = $"{logic.ActivePlayer}'s turn!";
                    Pile temp = new Pile(pile);
                    temp.MouseLeftButtonDown += fillCbx;
                    temp.MouseLeftButtonDown += SelectColor;
                    ugrdGame.Children.Add(temp);
                    Piles.Add(temp);
                }
            }
            
        }
    }
}
