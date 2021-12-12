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
using System.Windows.Threading;

namespace Interface_12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            Data.Text = now.ToString("D");

            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void GetArea_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(valueA.Text) || String.IsNullOrEmpty(valueB.Text) || String.IsNullOrEmpty(valueC.Text))
            {
                MessageBox.Show("Введите корректное значеение");
            }
            else
            {
                int p = (int.Parse(valueA.Text) + int.Parse(valueB.Text) + int.Parse(valueC.Text)) / 2;
                int a = int.Parse(valueA.Text);
                int b = int.Parse(valueB.Text);
                int c = int.Parse(valueC.Text);

                area.Text = Math.Round(Math.Sqrt(p * (p * a) * (p * b) * (p * c)), 2).ToString();
                valueA.Focus();
            }
        }

        private void txtAddNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (!Char.IsLetter(c))
                e.Handled = false;
            else
                e.Handled = true;
            base.OnPreviewTextInput(e);
        } 

        private void GetMultiplicationSum_Click(object sender, RoutedEventArgs e)
        {
            if (threeDigitNumber.Text.Length == 3)
            {
                int x = int.Parse(threeDigitNumber.Text);
                int sum = 0, multiply = 1;
                while (x != 0)
                {
                    sum += x % 10;
                    multiply *= x % 10;
                    x /= 10;
                }
                summary.Text = sum.ToString();
                multiplication.Text = multiply.ToString();
                threeDigitNumber.Focus();
            }
            else
            {
                MessageBox.Show("Введите трехзначное число");
            }
        }

        private void GetPerimeter_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(x1.Text) || String.IsNullOrEmpty(x2.Text) || String.IsNullOrEmpty(x3.Text) || String.IsNullOrEmpty(y1.Text) || String.IsNullOrEmpty(y2.Text) || String.IsNullOrEmpty(y3.Text))
            {
                MessageBox.Show("Введите корректное значеение");
            }
            else
            {
                perimeter.Text = Math.Round(Math.Sqrt(Math.Pow(int.Parse(x2.Text) - int.Parse(x1.Text), 2) +
                Math.Pow(int.Parse(y2.Text) - int.Parse(y1.Text), 2) +
                Math.Pow(int.Parse(x3.Text) - int.Parse(x2.Text), 2)
                + Math.Pow(int.Parse(y3.Text) - int.Parse(y2.Text), 2)), 2).ToString();
                x1.Focus();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Золотарев М. А.\n Группа: ИСП-34\n Вариант №13", "Разработчик", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AllTextBoxes_TextChanged(object sender, TextChangedEventArgs e)
        {
            multiplication.Clear();
            perimeter.Clear();
            summary.Clear();
            area.Clear();
        }
    }
}
