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

namespace SLAE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        private void Window_MouseLeftButtonDown(object sender, RoutedEventArgs e) => this.DragMove();

        private void BClose_Click(object sender, RoutedEventArgs e) => this.Close();

        private void BMinimize_Click(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        private void Gauss_Jordan_Checked(object sender, RoutedEventArgs e)
        {
            CBSeidel.IsEnabled = false;
            CBTikhonov.IsEnabled = false;
        }
        private void Seidel_Checked(object sender, RoutedEventArgs e)
        {
            CBGauss_Jordan.IsEnabled = false;
            CBTikhonov.IsEnabled = false;
        }
        private void Tikhonov_Checked(object sender, RoutedEventArgs e)
        {
            CBGauss_Jordan.IsEnabled = false;
            CBSeidel.IsEnabled = false;
        }
        private void Gauss_Jordan_Unchecked(object sender, RoutedEventArgs e)
        {
            CBSeidel.IsEnabled = true;
            CBTikhonov.IsEnabled = true;
        }
        private void Tikhonov_Unchecked(object sender, RoutedEventArgs e)
        {
            CBGauss_Jordan.IsEnabled = true;
            CBSeidel.IsEnabled = true;
        }
        private void Seidel_Unchecked(object sender, RoutedEventArgs e)
        {
            CBGauss_Jordan.IsEnabled = true;
            CBTikhonov.IsEnabled = true;
        }

        private void BStart_Click(object sender, RoutedEventArgs e)
        {
            if (CBGauss_Jordan.IsChecked == true)
            {

            }
            else if (CBSeidel.IsChecked == true)
            { 
            
            }
            else if (CBTikhonov.IsChecked == true)
            {

            }

        }
    }
}
