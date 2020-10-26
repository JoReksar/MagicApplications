using Microsoft.Win32;
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

namespace MagicGraphicApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadImage() 
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "|*.jpg||*.png"
            };

            if (dialog.ShowDialog() == true)
            {
                Uri URI = new Uri(dialog.FileName, UriKind.Absolute);
                ImageSource source = new BitmapImage(URI);
                Image image = new Image()
                {
                    Source = source
                };

                var imageWindow = new WindowWithImage(image);
                imageWindow.Show();
            }
        }
        private void LoadRectangle()
        {

        }

        private void LoadEllipse()
        {

        }

        private void LoadLine()
        {

        }

        private void LoadPolygon()
        {

        }

        private void ShowImage(object sender, RoutedEventArgs e)
        {
            LoadImage();
        }
    }
}
