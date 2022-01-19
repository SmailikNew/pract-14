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
using System.Windows.Shapes;

namespace pr_14
{
    /// <summary>
    /// Логика взаимодействия для setting.xaml
    /// </summary>
    public partial class setting : Window
    {
        public setting()
        {
            InitializeComponent();
        }

        private void setmatrix(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("config.ini"))
            {
                sw.WriteLine(tbm.Text);
                sw.WriteLine(tbn.Text);
                this.Close();
            }
        }

        private void exitbtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
