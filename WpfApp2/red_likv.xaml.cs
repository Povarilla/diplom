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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для red_likv.xaml
    /// </summary>
    public partial class red_likv : Window
    {
        komandorEntities context;
        public red_likv(komandorEntities context, Ликвидация ликвидация)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = ликвидация;
            naim.ItemsSource = context.Товар.ToList();
            fot.ItemsSource = context.Товар.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            Close();
        }
    }
}
