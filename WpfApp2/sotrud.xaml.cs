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
    /// Логика взаимодействия для sotrud.xaml
    /// </summary>
    public partial class sotrud : Window
    {
        komandorEntities context;
        public sotrud()
        {
            InitializeComponent();
            context = new komandorEntities();
            fidsotr.ItemsSource = context.Сотрудники.ToList();
            
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            var Dob = new Сотрудники();
            context.Сотрудники.Add(Dob);
            var Dob1 = new red_sotr(context, Dob);
            Dob1.ShowDialog();
            Update();
        }

        private void Update()
        {
            fidsotr.ItemsSource = context.Скидки.ToList();
            fidsotr.Items.Refresh();
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            var dea = fidsotr.SelectedItem as Сотрудники;
            if (dea == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно ходите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Сотрудники.Remove(dea);
                context.SaveChanges();

            }
            Update();
        }
        private void red_Click(object sender, RoutedEventArgs e)
        {
            Button red1 = sender as Button;
            var red2 = red1.DataContext as Сотрудники;
            var red3 = new red_sotr(context, red2);
            red3.ShowDialog();
            Update();
        }
    }
}
