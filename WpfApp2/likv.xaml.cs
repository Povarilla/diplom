using Microsoft.Win32;
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
    /// Логика взаимодействия для likv.xaml
    /// </summary>
    public partial class likv : Window
    {
        komandorEntities context;
        public likv()
        {
            InitializeComponent();
            context = new komandorEntities();   
            fid3.ItemsSource = context.Ликвидация.ToList();
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            var Dob = new Ликвидация();
            context.Ликвидация.Add(Dob);
            var Dob1 = new red_likv(context, Dob);
            Dob1.ShowDialog();
            Update();
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            var dea = fid3.SelectedItem as Ликвидация;
            if (dea == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно ходите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Ликвидация.Remove(dea);
                context.SaveChanges();

            }
            Update();
        }

        private void Update()
        {
            fid3.ItemsSource = context.Ликвидация.ToList();
            fid3.Items.Refresh();
        }
    

        private void red_Click(object sender, RoutedEventArgs e)
        {
            Button red1 = sender as Button;
            var red2 = red1.DataContext as Ликвидация;
            var red3 = new red_likv(context, red2);
            red3.ShowDialog();
            Update();
        }
    }
}
