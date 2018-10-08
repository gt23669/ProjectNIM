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
            int diff = 0;
            if (difEasy.IsChecked == true)
            {
                diff = 0;
            }
            else if (difMed.IsChecked == true)
            {
                diff = 1;
            }
            else if (difHard.IsChecked == true)
            {
                diff = 2;
            }

            gLogic.InitializePiles(diff);

            NameWindow open = new NameWindow(this, gLogic, (bool)plOne.IsChecked);
            open.Show();
        }

        private void btn_MainMenuClicked(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void btn_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton check = (RadioButton)sender;
            string currentGroup = check.GroupName;
            bool contEnable = false;
            if(currentGroup.Equals("Difficulty"))
            {
                List<RadioButton> players = new List<RadioButton>();
                players.Add(plOne);
                players.Add(plTwo);
                foreach (var button in players)
                {
                    if (button.IsChecked == true)
                        contEnable = true;
                }
            }
            else if(currentGroup.Equals("Player"))
            {
                List<RadioButton> diffs = new List<RadioButton>();
                diffs.Add(difEasy);
                diffs.Add(difMed);
                diffs.Add(difHard);
                foreach (var button in diffs)
                {
                    if (button.IsChecked == true)
                        contEnable = true;
                }
            }
            btnContinue.IsEnabled = contEnable;
        }
    }
}
