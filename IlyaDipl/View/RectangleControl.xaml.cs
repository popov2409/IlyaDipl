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
using IlyaDipl.Services;

namespace IlyaDipl.View
{
    /// <summary>
    /// Логика взаимодействия для RectangleControl.xaml
    /// </summary>
    public partial class RectangleControl : UserControl,IControlInterface
    {
        public RectangleControl(Element el)
        {
            InitializeComponent();
            Element = el;
            NameTextBlock.Text = Element.Mark;
            this.Margin = new Thickness(el.Location.X, el.Location.Y, 0, 0);
            this.ToolTip = new BaseToolTip(Element);
            this.Width = Element.Size.Width;
            this.Height = Element.Size.Height;
            NameTextBlock.MaxWidth = this.Width - 8;
            NameTextBlock.MaxHeight = this.Height - 10;
        }

        public void Selected()
        {
            IsSelected = true;
            this.Visibility = Visibility.Visible;
        }

        public void UnSelected()
        {
            IsSelected = false;
            this.Visibility = Visibility.Hidden;
        }

        public void Move(Point p)
        {
            this.Margin = new Thickness(p.X, p.Y, 0, 0);
            Element.Location = p;
        }

        
        private void Base_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Selected();
            p2 = e.GetPosition(this);
        }


        public string Mark { get; set; }
        //{
        //    //get => NameTextBlock.Text;
        //    //set => NameTextBlock.Text = value;
        //}


        private Point p2;
        private void Base_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed || !IsSelected) return;
            Point p1 = e.GetPosition(this.Parent as Canvas);
            Point p = new Point(p1.X - p2.X, p1.Y - p2.Y);
            this.Move(p);
        }

        private void DeleteElement_OnClick(object sender, RoutedEventArgs e)
        {
            BasePicture.RemoveElement(this);
        }

        public bool IsSelected { get; set; }
        public Element Element { get; set; }
    }
}
