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
    /// Логика взаимодействия для redact1.xaml
    /// </summary>
    public partial class redact1 : Window
    {
        komandorEntities context;
        public redact1(komandorEntities context, Акционный_товар акционный_Товар)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = акционный_Товар;

            uslComboBox.ItemsSource = context.Акции.ToList();
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
