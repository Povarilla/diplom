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
    /// Логика взаимодействия для akcc.xaml
    /// </summary>
    public partial class akcc : Window
    {
        komandorEntities context;
        public akcc()
        {
            InitializeComponent();
            context = new komandorEntities();
            fidakc.ItemsSource = context.Акции.ToList();
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            var Dob = new Акции();
            context.Акции.Add(Dob);
            var Dob1 = new red_akcc(context, Dob);
            Dob1.ShowDialog();
            Update();
        }

        private void Update()
        {
            fidakc.ItemsSource = context.Акции.ToList();
            fidakc.Items.Refresh();
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            var dea = fidakc.SelectedItem as Акции;
            if (dea == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно ходите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Акции.Remove(dea);
                context.SaveChanges();

            }
            Update();
        }
        private void red_Click(object sender, RoutedEventArgs e)
        {
            Button red1 = sender as Button;
            var red2 = red1.DataContext as Акции;
            var red3 = new red_akcc(context, red2);
            red3.ShowDialog();
            Update();
        }
    }
}
