using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for NameWindow.xaml
    /// </summary>
    public partial class NameWindow : Window
    {
        private StartWindow startWindow;
        GameLogic gameLogic;
        bool hasBot;
        public NameWindow(StartWindow startWindow, GameLogic gLogic, bool hasBot)
        {
            InitializeComponent();
            this.hasBot = hasBot;
            this.startWindow = startWindow;
            if(hasBot)
            {
                tbxp2Name.Text = "Robot Overlord";
            }
            tbxp2Name.Visibility = (hasBot)? Visibility.Hidden : Visibility.Visible ;
            gameLogic = gLogic;
        }

        private void btn_SeconContClicked(object sender, RoutedEventArgs e)
        {
            gameLogic.Players[0] = tbxp1Name.Text;
            gameLogic.Players[1] = tbxp2Name.Text;
            gameLogic.ActivePlayer = gameLogic.Players[0];
            //Game stuff goes here
            startWindow.Close();
            Game open = new Game(gameLogic, hasBot);
            open.Show();
        }
    }
}
