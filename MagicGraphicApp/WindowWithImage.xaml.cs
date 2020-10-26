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

namespace MagicGraphicApp
{
    /// <summary>
    /// Логика взаимодействия для WindowWithImage.xaml
    /// </summary>
    public partial class WindowWithImage : Window
    {
        public WindowWithImage(Image image)
        {
            InitializeComponent();
            this.image = image;
            image.Width = 1000;
            image.Height = 1000;
            //mainCanvas.Children.Add(image);
        }
    }
}
