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
        TransformCollection _transforms = new TransformCollection()
        {
            new RotateTransform(),
            new SkewTransform(),
            new ScaleTransform(),
            new TranslateTransform()
        };
        TransformCollection transforms = new TransformCollection()
        {
            new RotateTransform(),
            new SkewTransform(),
            new ScaleTransform(),
            new TranslateTransform()
        };

        TransformGroup group;
        Image currentImage;
        double angle, skew, scaleX = 1.0, scaleY = 1.0, translateX, translateY;
        public WindowWithImage(Image image)
        {
            InitializeComponent();
            currentImage = image;

            currentImage.Width = Width / 4.0;
            currentImage.Height = Height / 4.0;
            group = new TransformGroup() { Children = transforms };
            currentImage.RenderTransform = group;
            mainCanvas.Children.Add(currentImage);
        }

        private void MovePicture(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.R:
                    angle += 4.0;
                    group.Children[0] = new RotateTransform() { Angle = angle };
                    break;
                case Key.S:
                    skew += 2.0;
                    group.Children[1] = new SkewTransform() { AngleX = skew, AngleY = skew };
                    break;
                case Key.Up:
                    scaleX += 2.0;
                    group.Children[2] = new ScaleTransform() { ScaleX = scaleX, ScaleY = scaleY };
                    break;
                case Key.Left:
                    scaleY += 2.0;
                    group.Children[2] = new ScaleTransform() { ScaleX = scaleX, ScaleY = scaleY };
                    break;
                case Key.Right:
                    translateX += 2.0;
                    group.Children[3] = new TranslateTransform() { X = translateX, Y = translateY };
                    break;
                case Key.Down:
                    translateY += 2.0;
                    group.Children[3] = new TranslateTransform() { X = translateX, Y = translateY };
                    break;
                default: 
                    group = new TransformGroup() { Children = new TransformCollection(_transforms) };
                    currentImage.RenderTransform = group;
                    angle = 0.0; skew = 0.0; scaleX = 1.0; scaleY = 1.0; translateX = 0.0; translateY = 0.0;
                    return;
            }

            //Matrix m = group.Value;
            //MessageBox.Show($"{m.M11} {m.M12} \n{m.M21} {m.M22}");
        }

        private void StopMovingPicture(object sender, KeyEventArgs e)
        {

        }

    }
}
