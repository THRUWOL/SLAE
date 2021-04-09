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
        //
        private void ReturnSeidel(double[] current)
        {
            b1.Text = Convert.ToString(Math.Round(current[0], 5));
            b2.Text = Convert.ToString(Math.Round(current[1], 5));
            b3.Text = Convert.ToString(Math.Round(current[2], 5));
        }
        private void ReturnSeidel2(double[,] matrx)
        {
            a11.Text = Convert.ToString(Math.Round(matrx[0, 0], 5));
            a12.Text = Convert.ToString(Math.Round(matrx[0, 1], 5));
            a13.Text = Convert.ToString(Math.Round(matrx[0, 2], 5));
            a21.Text = Convert.ToString(Math.Round(matrx[1, 0], 5));
            a22.Text = Convert.ToString(Math.Round(matrx[1, 1], 5));
            a23.Text = Convert.ToString(Math.Round(matrx[1, 2], 5));
            a31.Text = Convert.ToString(Math.Round(matrx[2, 0], 5));
            a32.Text = Convert.ToString(Math.Round(matrx[2, 1], 5));
            a33.Text = Convert.ToString(Math.Round(matrx[2, 2], 5));
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
                double[] addtional = CreateAdditional(numVar);
                double accuracy = 0.01;

                // общий вид:
                // [x1]   [ b1/a11 ]   / 0 x x \ 
                // [x2] = [ b2/a22 ] - | x 0 x |
                // [x3]   [ b3/a33 ]   \ x x 0 /
                // где x - делится на диагональый элемент первоначальной матрицы.
                // где b - эелементы из свободных членов
                // где а - элементы из матрицы

                // матрица коеффициентов + столбец свободных членов.
                double[,] a = new double[matrix.GetLength(0), matrix.GetLength(1) + 1];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1) - 1; j++)
                        a[i, j] = matrix[i, j];

                for (int i = 0; i < a.GetLength(0); i++)
                    a[i, a.GetLength(1) - 1] = addtional[i];
                //---------------
                // Метод Зейделя.
                //---------------

                // Введем вектор значений неизвестных на предыдущей итерации,
                // размер которого равен числу строк в матрице, т.е. size,
                // причем согласно методу изначально заполняем его нулями
                double[] previousValues = new double[matrix.GetLength(0)];
                for (int i = 0; i < previousValues.GetLength(0); i++)
                {
                    previousValues[i] = 0.0;
                }
                // Будем выполнять итерационный процесс до тех пор,
                // пока не будет достигнута необходимая точность
                while (true)
                {
                    // Введем вектор значений неизвестных на текущем шаге
                    double[] currentValues = new double[a.GetLength(0)];

                    // Посчитаем значения неизвестных на текущей итерации
                    // в соответствии с теоретическими формулами
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        // Инициализируем i-ую неизвестную значением
                        // свободного члена i-ой строки матрицы
                        currentValues[i] = a[i, a.GetLength(0)];

                        // Вычитаем сумму по всем отличным от i-ой неизвестным
                        for (int j = 0; j < a.GetLength(0); j++)
                        {
                            // При j < i можем использовать уже посчитанные
                            // на этой итерации значения неизвестных
                            if (j < i)
                            {
                                currentValues[i] -= a[i, j] * currentValues[j];
                            }

                            // При j > i используем значения с прошлой итерации
                            if (j > i)
                            {
                                currentValues[i] -= a[i, j] * previousValues[j];
                            }
                        }

                        // Делим на коэффициент при i-ой неизвестной
                        currentValues[i] /= a[i, i];
                    }

                    // Посчитаем текущую погрешность относительно предыдущей итерации
                    double differency = 0.0;

                    for (int i = 0; i < a.GetLength(0); i++)
                        differency += Math.Abs(currentValues[i] - previousValues[i]);

                    // Если необходимая точность достигнута, то завершаем процесс
                    if (differency < accuracy)
                        break;

                    // Переходим к следующей итерации, так
                    // что текущие значения неизвестных
                    // становятся значениями на предыдущей итерации
                    ;
                    previousValues = currentValues;
                    
                }
                ReturnSeidel(previousValues);
                ReturnSeidel2(matrix);
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

}
