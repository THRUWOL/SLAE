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

        /* ЗОНА ПОВЫШЕННОГО БЫДЛОКОДА */

        // Заполняем матрицу из текстбоксов
        private double[,] CreateMatrixAll(int numVar)
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
        // Зполняем матрицу отдельно от свободных членов
        private double[,] CreateMatrix(int numVar)
        {
            double[,] matrx = new double[numVar, numVar];
            matrx[0, 0] = Convert.ToDouble(a11.Text);
            matrx[0, 1] = Convert.ToDouble(a12.Text);
            matrx[0, 2] = Convert.ToDouble(a13.Text);
            matrx[1, 0] = Convert.ToDouble(a21.Text);
            matrx[1, 1] = Convert.ToDouble(a22.Text);
            matrx[1, 2] = Convert.ToDouble(a23.Text);
            matrx[2, 0] = Convert.ToDouble(a31.Text);
            matrx[2, 1] = Convert.ToDouble(a32.Text);
            matrx[2, 2] = Convert.ToDouble(a33.Text);
            return matrx;
        }
        // Добавляем отдельно свободные члены
        private double[] CreateAdditional(int numVar)
        {
            double[] additional = new double[numVar];
            additional[0] = Convert.ToDouble(b1.Text);
            additional[1] = Convert.ToDouble(b2.Text);
            additional[2] = Convert.ToDouble(b3.Text);
            return additional;
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
        // Заполнение текстбокса значениями из 13 варианта
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
        // Заполнение текстбокса рандомными числами
        private void BRandom_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            a11.Text = Convert.ToString(rnd.Next(-100, 100));
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
        // Заполнение текстбокса ответом метода Зейделя
        private void AddAdditional(double[] answer)
        {
            a11.Text = "";
            a12.Text = "";
            a13.Text = "";
            //b1.Text = Convert.ToString(Math.Round(answer[0], 5));
            b1.Text = Convert.ToString(answer[0]);
            a21.Text = "";
            a22.Text = "";
            a23.Text = "";
            //b2.Text = Convert.ToString(Math.Round(answer[1], 5));
            b2.Text = Convert.ToString(answer[1]);
            a31.Text = "";
            a32.Text = "";
            a33.Text = "";
            //b3.Text = Convert.ToString(Math.Round(answer[2], 5));
            b3.Text = Convert.ToString(answer[2]);
        }
        /* ЗОНА ПОВЫШЕННОГО БЫДЛОКОДА ЗАКОНЧЕНА */

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
            // Метод Гаусса-Жордана (1 задание)
            if (CBGauss_Jordan.IsChecked == true)
            {
                int numVar = 3;
                double[,] matrix = CreateMatrixAll(numVar);
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
            // Метод Зейделя (2 задание)
            else if (CBSeidel.IsChecked == true)
            {
                int numVar = 3;
                double[,] matrix = CreateMatrix(numVar);
                double[] addit = CreateAdditional(numVar);
                GaussSeidel gaussSeidel = new GaussSeidel(matrix, addit, 0.001, false);
                double[] answer = gaussSeidel.Answer;
                AddAdditional(answer);

            }
            // Метод Тихонова (бонус)
            else if (CBTikhonov.IsChecked == true)
            {

            }
            else
            {
                // если ничё не выбрал
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

    }
    public class GaussSeidel
    {
        public double Epsilon { get; set; }

        public GaussSeidel(double[,] leftPart, double[] rightPart, double epsilon, bool isParallel)
        {
            if (Epsilon > 0.1)
                throw new ArgumentException("epsilon > 0.1", nameof(epsilon));

            Epsilon = epsilon;
            Answer = new double[rightPart.GetLength(0)];
            if (isParallel)
            {
                TrySolveParallel(leftPart, rightPart);
                return;
            }

            TrySolve(leftPart, rightPart);
        }
        public long Iterations { get; private set; }
        public double[] Answer { get; private set; }

        private static bool IsConverge(
            IReadOnlyList<double> curr,
            IReadOnlyList<double> prev, int n, double eps)
        {
            double norm = 0;
            for (var i = 0; i < n; i++)
            {
                norm += Math.Pow(curr[i] - prev[i], 2);
            }
            return !(Math.Sqrt(norm) >= eps);
        }

        private void TrySolve(double[,] leftPart, IReadOnlyList<double> rightPart)
        {
            var curr = new double[rightPart.Count];
            for (var i = 0; i < curr.Length; i++)
            {
                curr[i] = 0;
            }
            var prev = new double[rightPart.Count];

            var n = leftPart.GetLength(0);
            long counter = 0;
            do
            {
                if (counter > 1000000)
                    return;

                ++counter;

                for (var i = 0; i < n; i++)
                    prev[i] = curr[i];

                for (var i = 0; i < n; i++)
                {
                    double var = 0;
                    for (var j = 0; j < i; j++)
                        var += leftPart[i,j] * curr[j];
                    for (var j = i + 1; j < n; j++)
                        var += leftPart[i,j] * prev[j];
                    curr[i] = (rightPart[i] - var) / leftPart[i,i];
                }
            } while (!IsConverge(curr, prev, n, Epsilon));
            Answer = curr;
            Iterations = counter;
        }

        private void TrySolveParallel(double[,] leftPart, double[] rightPart)
        {
        }
    }
}
