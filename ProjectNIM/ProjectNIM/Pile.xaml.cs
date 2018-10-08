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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectNIM
{
    /// <summary>
    /// Interaction logic for Pile.xaml
    /// </summary>
    public partial class Pile : UserControl
    {
        public Pile(int items)
        {
            InitializeComponent();
            string toFill = "";
            for (int i = 0; i < items; i++)
            {
                toFill += "| ";
            }
            lblItems.Content = toFill;
            InitializeComponent();
        }

        public bool IsChecked()
        {
            if (rbtnChoice.IsChecked == true)
            {
                return true;
            }
            else return false;
        }
    }
}
