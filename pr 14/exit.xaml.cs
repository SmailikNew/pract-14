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
using System.Windows.Shapes;

namespace pr_14
{
    /// <summary>
    /// Логика взаимодействия для exit.xaml
    /// </summary>
    public partial class exit : Window
    {
        public exit()
        {
            InitializeComponent();
        }

        private void exitbtn(object sender, RoutedEventArgs e)
        {
            this.Close();
            Owner.Close();
        }

        private void cancelexitbtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
