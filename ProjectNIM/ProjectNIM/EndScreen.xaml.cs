using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for EndScreen.xaml
    /// </summary>
    public partial class EndScreen : Window
    {
        public EndScreen(GameLogic game)
        {
            Random rand = new Random();
            //Image image = new Image();
            //imgScreen.Source.Equals();
            InitializeComponent();
            List<String> paths = new List<string>();
            if(game.ActivePlayer == game.Players[0])
            {
                foreach (var directory in Directory.GetFiles("../../WinScreen/"))
                {
                    paths.Add(directory);
                }
            }
            else
            {
                foreach (var directory in Directory.GetFiles("../../GameOverScreen/"))
                {
                    paths.Add(directory);
                }
            }
            imgScreen.Source = new BitmapImage(new Uri/*on ice*/(paths[rand.Next(paths.Count)], UriKind.Relative));
        }

        private string getImage(string path)
        {
            string file = null;
            if (!string.IsNullOrEmpty(path))
            {
                var extensions = new string[] { ".png", ".jpg", ".gif" };
                try
                {
                    var di = new DirectoryInfo(path);
                    var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                }
                // probably should only catch specific exceptions
                // throwable by the above methods.
                catch { }
            }
            return file;
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            StartWindow open = new StartWindow();
            open.Show();
            Close();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow open = new MainWindow();
            open.Show();
            Close();
        }
    }
}
