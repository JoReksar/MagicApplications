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
    /// Логика взаимодействия для WindowwWithRectangle.xaml
    /// </summary>
    public partial class WindowWithRectangle : Window
    {
        TransformCollection _transforms = new TransformCollection()
        {
            new RotateTransform(),
            new SkewTransform(),
            new ScaleTransform(),
            new TranslateTransform()
        };
        TransformGroup group;
        Rectangle currentRectangle;

        double angle = 0.0,
               skew = 0.0,
               scaleX = 1.0,
               scaleY = 1.0,
               translateX = 0.0,
               translateY = 0.0;

        public WindowWithRectangle(Rectangle rectangle)
        {
            InitializeComponent();
            currentRectangle = rectangle;

            currentRectangle.Width = Width / 4.0;
            currentRectangle.Height = Height / 4.0;
            group = new TransformGroup() { Children = new TransformCollection(_transforms) };
            currentRectangle.RenderTransform = group;
            mainCanvas.Children.Add(currentRectangle);
        }

        private void MoveRectangle(object sender, KeyEventArgs e)
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
                    currentRectangle.RenderTransform = group;
                    angle = 0.0; skew = 0.0; scaleX = 1.0; scaleY = 1.0; translateX = 0.0; translateY = 0.0;
                    return;
            }
        }
    }
}
