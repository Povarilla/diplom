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
    /// Логика взаимодействия для SpisT.xaml
    /// </summary>
    public partial class SpisT : Window
    {
        komandorEntities context;
        public SpisT()
        {
            InitializeComponent();
            context = new komandorEntities();
            fid4.ItemsSource = context.Списания.ToList();
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            var dea = fid4.SelectedItem as Списания;
            if (dea == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно ходите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Списания.Remove(dea);
                context.SaveChanges();

            }
            Update();
        }

        private void Update()
        {
            fid4.ItemsSource = context.Списания.ToList();
            fid4.Items.Refresh();
        }


        private void dob_Click(object sender, RoutedEventArgs e)
        {
            var Dob = new Списания();
            context.Списания.Add(Dob);
            var Dob1 = new red_spis(context, Dob);
            Dob1.ShowDialog();
            Update();
        }
        private void red_Click(object sender, RoutedEventArgs e)
        {
            Button red1 = sender as Button;
            var red2 = red1.DataContext as Списания;
            var red3 = new red_spis(context, red2);
            red3.ShowDialog();
            Update();
        }
    }
}
