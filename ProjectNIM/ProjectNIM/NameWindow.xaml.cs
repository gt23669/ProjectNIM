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

        public NameWindow(StartWindow startWindow)
        {
            InitializeComponent();
            this.startWindow = startWindow;
        }

        private void btn_SeconContClicked(object sender, RoutedEventArgs e)
        {

            //Game stuff goes here
            Close();
            startWindow.Close();
            Game open = new Game();
            open.Show();
        }
    }
}
