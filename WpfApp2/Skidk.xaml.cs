using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Skidk.xaml
    /// </summary>
    public partial class Skidk : Window
    {
        komandorEntities context;
        public Skidk()
        {
            InitializeComponent();
            context = new komandorEntities();
            fid2.ItemsSource = context.Скидки.ToList();
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            var Dob = new Скидки();
            context.Скидки.Add(Dob);
            var Dob1 = new red_skid(context, Dob);
            Dob1.ShowDialog();
            Update();
        }

        private void red_Click(object sender, RoutedEventArgs e)
        {
            Button red1 = sender as Button;
            var red2 = red1.DataContext as Скидки;
            var red3 = new red_skid(context, red2);
            red3.ShowDialog();
            Update();
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            var dea = fid2.SelectedItem as Скидки;
            if (dea == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно ходите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Скидки.Remove(dea);
                context.SaveChanges();

            }
            Update();
        }

        private void Update()
        {
            fid2.ItemsSource = context.Скидки.ToList();
            fid2.Items.Refresh();
        }
    
    }
}
