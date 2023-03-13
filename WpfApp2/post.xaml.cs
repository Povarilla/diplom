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
    /// Логика взаимодействия для post.xaml
    /// </summary>
    public partial class post : Window
    {
        komandorEntities context;
        public post()
        {
            InitializeComponent();
            context = new komandorEntities();
            fidpos.ItemsSource = context.Поставщики.ToList();
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            var Dob = new Поставщики();
            context.Поставщики.Add(Dob);
            var Dob1 = new red_post(context, Dob);
            Dob1.ShowDialog();
            Update();
        }
        private void red_Click(object sender, RoutedEventArgs e)
        {
            Button red1 = sender as Button;
            var red2 = red1.DataContext as Поставщики;
            var red3 = new red_post(context, red2);
            red3.ShowDialog();
            Update();
        }
        private void del_Click(object sender, RoutedEventArgs e)
        {
            var dea = fidpos.SelectedItem as Поставщики;
            if (dea == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно ходите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Поставщики.Remove(dea);
                context.SaveChanges();

            }
            Update();
        }
        private void Update()
        {
            fidpos.ItemsSource = context.Поставщики.ToList();
            fidpos.Items.Refresh();
        }
    }
}
