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
    /// Логика взаимодействия для WindowWithPolygon.xaml
    /// </summary>
    public partial class WindowWithPolygon : Window
    {
        TransformCollection _transforms = new TransformCollection()
        {
            new RotateTransform(),
            new SkewTransform(),
            new ScaleTransform(),
            new TranslateTransform()
        };
        TransformGroup group;
        Polygon currentPolygon;

        double angle = 0.0,
               skew = 0.0,
               scaleX = 1.0,
               scaleY = 1.0,
               translateX = 0.0,
               translateY = 0.0;

        public WindowWithPolygon(Polygon polygon)
        {
            InitializeComponent();
            currentPolygon = polygon;

            currentPolygon.Width = Width;
            currentPolygon.Height = Height;
            group = new TransformGroup() { Children = new TransformCollection(_transforms) };
            currentPolygon.RenderTransform = group;
            mainCanvas.Children.Add(currentPolygon);
        }

        private void MovePolygon(object sender, KeyEventArgs e)
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
                    scaleX += 1.0;
                    group.Children[2] = new ScaleTransform() { ScaleX = scaleX, ScaleY = scaleY };
                    break;
                case Key.Left:
                    scaleY += 1.0;
                    group.Children[2] = new ScaleTransform() { ScaleX = scaleX, ScaleY = scaleY };
                    break;
                case Key.Right:
                    translateX += 4.0;
                    group.Children[3] = new TranslateTransform() { X = translateX, Y = translateY };
                    break;
                case Key.Down:
                    translateY += 4.0;
                    group.Children[3] = new TranslateTransform() { X = translateX, Y = translateY };
                    break;
                default:
                    group = new TransformGroup() { Children = new TransformCollection(_transforms) };
                    currentPolygon.RenderTransform = group;
                    angle = 0.0; skew = 0.0; scaleX = 1.0; scaleY = 1.0; translateX = 0.0; translateY = 0.0;
                    return;
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            currentPolygon.Points.Add(e.GetPosition(null));
        }
    }
}
