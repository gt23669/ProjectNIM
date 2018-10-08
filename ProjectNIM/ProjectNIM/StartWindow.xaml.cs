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
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }
        private void btn_FirstContClicked(object sender, RoutedEventArgs e)
        {
            GameLogic gLogic = new GameLogic();
            List<int> piles = new List<int>();
            if(difEasy.IsChecked == true)
            {
                
            }
            NameWindow open = new NameWindow(this);
            open.Show();
        }

        private void btn_MainMenuClicked(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void difEasy_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton check = (RadioButton)sender;
            string currentGroup = check.GroupName;
            if(currentGroup.Equals("Difficulty"))
            {

            }
        }
    }
}
