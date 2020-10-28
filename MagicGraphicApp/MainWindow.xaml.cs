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
        Image image;
        Rectangle rectangle;
        Ellipse ellipse;
        Polygon polygon;

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
                image = new Image()
                {
                    Source = source
                };
            }
        }
        private void LoadRectangle()
        {
            rectangle = new Rectangle()
            {
                Stroke = Brushes.Black,
                Width = 300,
                Height = 300
            };
        }
        private void LoadEllipse()
        {
            ellipse = new Ellipse()
            {
                Stroke = Brushes.Black,
                Width = 300,
                Height = 300
            };
        }
        private void LoadPolygon()
        {
            polygon = new Polygon()
            {
                Stroke = Brushes.Black,
            };
        }

        private void ShowImage(object sender, RoutedEventArgs e)
        {
            LoadImage();

            var imageWindow = new WindowWithImage(image);
            imageWindow.Show();
        }
        private void ShowRectangle(object sender, RoutedEventArgs e)
        {
            LoadRectangle();

            var rectangleWindow = new WindowWithRectangle(rectangle);
            rectangleWindow.Show();
        }
        private void ShowEllipse(object sender, RoutedEventArgs e)
        {
            LoadEllipse();

            var rectangleWindow = new WindowWithEllipse(ellipse);
            rectangleWindow.Show();
        }
        private void ShowPolygon(object sender, RoutedEventArgs e)
        {
            LoadPolygon();

            var rectangleWindow = new WindowWithPolygon(polygon);
            rectangleWindow.Show();
        }
    }
}
