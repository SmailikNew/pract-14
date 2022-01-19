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
    /// Логика взаимодействия для dologin.xaml
    /// </summary>
    public partial class dologin : Window
    {
        public dologin()
        {
            InitializeComponent();
        }

        private void loginbtn(object sender, RoutedEventArgs e)
        {
            if (passbox.Password == "123")
            {
                this.Close();
            }
            else MessageBox.Show("Неверный пароль! Попробуйте еще!", "Неверный пароль");
        }

        private void cancelbtn(object sender, RoutedEventArgs e)
        {
            this.Close();
            Owner.Close();
        }
    }
}
