using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public Game(GameLogic gLogic, bool hasBot)
        {
            InitializeComponent();
            foreach (var pile in gLogic.Piles)
            {
                lblGameInfo.Content = $"{gLogic.Players[0].ToString()}'s turn!";
                Pile temp = new Pile(pile);
                temp.MouseLeftButtonDown += fillCbx;
                ugrdGame.Children.Add(temp);
            }
        }

        private void fillCbx(object sender, MouseButtonEventArgs e)
        {
            Pile temp = (Pile)sender;
            string data = (string)temp.lblItems.Content;
            int count = data.Split(' ').Length;
            for (int i = 0; i < count - 1; i++)
            {
                cbxChoice.Items.Add(i + 1);
            }
        }

        private void cbxChoice_Selected(object sender, RoutedEventArgs e)
        {
            btnSubmit.IsEnabled = true;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            List<Pile> piles = new List<Pile>();
            for (int i = 0; i < ugrdGame.Children.Count; i++)
            {
                piles.Add((Pile)ugrdGame.Children[i]);
            }
            for (int i = 0; i < piles.Count; i++)
            {
                if(piles[i].IsChecked() == true)
                {
                    
                }
            }
        }
    }
}
