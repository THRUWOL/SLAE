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

        private void Seidel_Unchecked(object sender, RoutedEventArgs e)
        {
            CBGauss_Jordan.IsEnabled = true;
            CBTikhonov.IsEnabled = true;
        }
        // Заполняем матрицу из текстбоксов
        private double[,] CreateMatrix(int numVar)
        {
            double[,] matrx = new double[numVar, numVar + 1];
            matrx[0, 0] = Convert.ToDouble(a11.Text);
            matrx[0, 1] = Convert.ToDouble(a12.Text);
            matrx[0, 2] = Convert.ToDouble(a13.Text);
            matrx[0, 3] = Convert.ToDouble(b1.Text);
            matrx[1, 0] = Convert.ToDouble(a21.Text);
            matrx[1, 1] = Convert.ToDouble(a22.Text);
            matrx[1, 2] = Convert.ToDouble(a23.Text);
            matrx[1, 3] = Convert.ToDouble(b2.Text);
            matrx[2, 0] = Convert.ToDouble(a31.Text);
            matrx[2, 1] = Convert.ToDouble(a32.Text);
            matrx[2, 2] = Convert.ToDouble(a33.Text);
            matrx[2, 3] = Convert.ToDouble(b3.Text);
            return matrx;
        }
        // Заполняем в текстбоксы решённую матрицу
        private void ReturnMatrix(double[,] matrx)
        {
            a11.Text = Convert.ToString(Math.Round(matrx[0, 0], 5));
            a12.Text = Convert.ToString(Math.Round(matrx[0, 1], 5));
            a13.Text = Convert.ToString(Math.Round(matrx[0, 2], 5));
            b1.Text = Convert.ToString(Math.Round(matrx[0, 3],5));
            a21.Text = Convert.ToString(Math.Round(matrx[1, 0], 5));
            a22.Text = Convert.ToString(Math.Round(matrx[1, 1], 5));
            a23.Text = Convert.ToString(Math.Round(matrx[1, 2], 5));
            b2.Text = Convert.ToString(Math.Round(matrx[1, 3], 5));
            a31.Text = Convert.ToString(Math.Round(matrx[2, 0], 5));
            a32.Text = Convert.ToString(Math.Round(matrx[2, 1], 5));
            a33.Text = Convert.ToString(Math.Round(matrx[2, 2], 5));
            b3.Text = Convert.ToString(Math.Round(matrx[2, 3], 5));
        }
        static double[,] EOR1(double[,] A, int renglon, double factor)
        {
            //ВВозвращает кол-во строк
            int col = A.GetLength(1);
            //умножаем строки на коэфициенты
            for (int i = 0; i < col; i++)
            {
                A[renglon, i] *= factor;
            }
            return A;
        }
        static double[,] EOR2(double[,] A, int renglon1, int renglon2, double factor)
        {
            //Возвращает кол-во строк
            int col = A.GetLength(1);
            //Меняем строку
            for (int i = 0; i < col; i++)
            {
                A[renglon2, i] += A[renglon1, i] * factor;
            }
            return A;
        }

        private void BStart_Click(object sender, RoutedEventArgs e)
        {
            if (CBGauss_Jordan.IsChecked == true)
            {
                int numVar = 3;
                double[,] matrix = CreateMatrix(numVar);
                for(int i =0; i < numVar; i++) 
                {
                    matrix = EOR1(matrix, i, 1 / matrix[i, i]);
                    for (int k = 0; k < numVar; k++)
                    {
                        if (i == k)
                        {
                            continue;
                        }
                        matrix = EOR2(matrix, i, k, -matrix[k, i]);
                    }
                }
                ReturnMatrix(matrix);
            }
            else if (CBSeidel.IsChecked == true)
            { 
            
            }
            else if (CBTikhonov.IsChecked == true)
            {

            }
            else
            {

            }
        }

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

        private void BAuto_Click(object sender, RoutedEventArgs e)
        {
            a11.Text = "3";
            a12.Text = "0";
            a13.Text = "-1";
            b1.Text = "-4";
            a21.Text = "2";
            a22.Text = "-5";
            a23.Text = "1";
            b2.Text = "9";
            a31.Text = "2";
            a32.Text = "-2";
            a33.Text = "6";
            b3.Text = "8";
        }

        private void BRandom_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            a11.Text = Convert.ToString(rnd.Next(-100,100));
            a12.Text = Convert.ToString(rnd.Next(-100, 100));
            a13.Text = Convert.ToString(rnd.Next(-100, 100));
            b1.Text = Convert.ToString(rnd.Next(-100, 100));
            a21.Text = Convert.ToString(rnd.Next(-100, 100));
            a22.Text = Convert.ToString(rnd.Next(-100, 100));
            a23.Text = Convert.ToString(rnd.Next(-100, 100));
            b2.Text = Convert.ToString(rnd.Next(-100, 100));
            a31.Text = Convert.ToString(rnd.Next(-100, 100));
            a32.Text = Convert.ToString(rnd.Next(-100, 100));
            a33.Text = Convert.ToString(rnd.Next(-100, 100));
            b3.Text = Convert.ToString(rnd.Next(-100, 100));
        }
    }

}
