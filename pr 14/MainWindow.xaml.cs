using ArrayManager;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace pr_14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            dologin login = new dologin();
            login.ShowDialog();
            if (File.Exists("config.ini"))
            {
                using (StreamReader sr = new StreamReader("config.ini"))
                {
                    array = new MyArray(int.Parse(sr.ReadLine()), int.Parse(sr.ReadLine()));
                }
            }
            InitializeComponent();
            if (File.Exists("config.ini"))
            {
                datagrid1.ItemsSource = array.ToDataTable().DefaultView;
            }
        }

        MyArray array;

        private void exit(object sender, RoutedEventArgs e)
        {
            exit exit1 = new exit();
            exit1.ShowDialog();
            exit1.Owner = this;
        }

        private void info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ИСП - 34, Горшков Илья, Вариант 2. Дана целочисленная матрица размера M * N. Найти номер первого из ее столбцов, содержащих максимальное количество одинаковых элементов");
        }

        private void complete(object sender, RoutedEventArgs e)
        {
            if (tbm.Text != "" && tbn.Text != "")
            {
                array = new MyArray(int.Parse(tbm.Text), int.Parse(tbn.Text));
                array.Fill();
                datagrid1.ItemsSource = array.ToDataTable().DefaultView;
                tbsize.Text = "Размер матрицы: " + array.RowLength + "X" + array.ColumnLength;
            }
            else MessageBox.Show("Введите значения!");
        }

        private void clearmatrix(object sender, RoutedEventArgs e)
        {
            array.Fill(0, 0);
            tbn.Clear();
            tbm.Clear();
            datagrid1.ItemsSource = array.ToDataTable().DefaultView;
            tbsize.Text = "Размер матрицы: 0X0";
            tbcoordination.Text = "Координаты выбранной ячейки: 0X0";
        }

        private void savematrix(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = "Сохранение матрицы";

            if (saveFileDialog.ShowDialog() == true)
            {
                array.Export(saveFileDialog.FileName);
            }
            datagrid1.ItemsSource = null;
            tbn.Clear();
            tbm.Clear();
        }

        private void openmatrix(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Открытие матрицы";

            if (openFileDialog.ShowDialog() == true)
            {
                array.Import(openFileDialog.FileName);
                datagrid1.ItemsSource = array.ToDataTable().DefaultView;
            }

        }

        private void find(object sender, RoutedEventArgs e)
        {
            int maxEqual = array.RowLength;
            int resultColumn = 1;
            for (int i = 0; i < array.ColumnLength; i++)
            {
                int[] equalnumber = new int[array.RowLength];
                for (int j = 0; j < array.RowLength; j++)
                {
                    equalnumber[j] = array[j, i];
                }
                if (maxEqual > equalnumber.Distinct().Count())
                {
                    maxEqual = equalnumber.Distinct().Count();
                    resultColumn = i + 1;
                }
            }
            MessageBox.Show(resultColumn.ToString());
        }

        private void Tbm_TextChanged(object sender, TextChangedEventArgs e)
        {
            datagrid1.ItemsSource = null;
        }

        private void Tbn_TextChanged(object sender, TextChangedEventArgs e)
        {
            datagrid1.ItemsSource = null;
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectionChangedEventArgs e)
        {
            tbcoordination.Text = "Координаты выбранной ячейки: " + datagrid1.Items.IndexOf(datagrid1.CurrentItem) + "X" +
               datagrid1.CurrentColumn.DisplayIndex;
        }

        private void setsettings(object sender, RoutedEventArgs e)
        {
            setting settings1 = new setting();
            settings1.Owner = this;
            settings1.ShowDialog();
        }
    }
}
