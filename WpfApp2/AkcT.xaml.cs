using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using WpfApp2.Properties;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для AkcT.xaml
    /// </summary>
    public partial class AkcT : Window
    {
        komandorEntities context;
        public AkcT()
        {
            InitializeComponent();
            context = new komandorEntities();
            fid1.ItemsSource = context.Акционный_товар.ToList();
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            var dea = fid1.SelectedItem as Акционный_товар;
            if (dea == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно ходите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Акционный_товар.Remove(dea);
                context.SaveChanges();

            }
            Update();
        }

        private void Update()
        {
            fid1.ItemsSource = context.Акционный_товар.ToList();
            fid1.Items.Refresh();
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            var Dob = new Акционный_товар();
            context.Акционный_товар.Add(Dob);
            var Dob1 = new redact1(context, Dob);
            Dob1.ShowDialog();
            Update();
        }
        private void red1_Click(object sender, RoutedEventArgs e)
        {
            Button red1 = sender as Button;
            var red2 = red1.DataContext as Акционный_товар;
            var red3 = new redact1(context, red2);
            red3.ShowDialog();
            Update();
        }
    }
}
