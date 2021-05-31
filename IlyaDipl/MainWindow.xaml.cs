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

namespace IlyaDipl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeComponent();
            BaseDataStore.LoadData();
            BasePicture.CreateCanvas();
            BasePicture.ClearAllSelected();
            BaseCanvas.Children.Add(BasePicture.MainCanvas);
        }

        private void MainWindow_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //BasePicture.ClearAllSelected();
        }

        private void Zoom_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //int dx = e.Delta / 5;
            //int dy = (int) (dx * BaseView.Height / BaseView.Width);

            //BaseView.Width += dx;
            //BaseView.Height += dy;
        }





        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BasePicture.SearchElement(SearchTextBox.Text);
        }

        private Point _locateCursor;

        private void AddElementMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            BasePicture.AddElement(_locateCursor);
            // new AddElementWindow(_locateCursor).ShowDialog();
            //BasePicture.CreateCanvas();
        }

        private void BaseCanvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _locateCursor = e.GetPosition(BaseCanvas);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            BaseDataStore.SaveData();
        }

        private bool hiddenPictureFone;
        private Brush ib;
        private void HidePicture_OnClick(object sender, RoutedEventArgs e)
        {

            hiddenPictureFone = !hiddenPictureFone;
            if (hiddenPictureFone)
            {
                ib = BaseCanvas.Background;

                BaseCanvas.Background = Brushes.Transparent;
                HidePicture.Header = "Показать фон";
            }
            else
            {
                BaseCanvas.Background = ib;
                HidePicture.Header = "Скрыть фон";
            }
        }

        private void ShowAllElements_OnClick(object sender, RoutedEventArgs e)
        {
            BasePicture.ShowAllElements();
        }

        private void ClearSearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";
        }
    }
}
