using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IlyaDipl.Models;

namespace IlyaDipl.View
{
    /// <summary>
    /// Логика взаимодействия для BaseToolTip.xaml
    /// </summary>
    public partial class BaseToolTip : UserControl
    {
        public BaseToolTip(Element el)
        {
            InitializeComponent();
            MarkTextBlock.Text = el.Mark;
            PurposeTextBox.Text = el.Purpose;
            if (el.ImageSource.Length < 1) return;
            ElementPictureImage.Source = new BitmapImage(new Uri(new Uri("file://"),
                AppDomain.CurrentDomain.BaseDirectory + "images/" + el.ImageSource));
        }
    }
}
