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
using Microsoft.Win32;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для redact.xaml
    /// </summary>
    public partial class redact : Window
    {
        komandorEntities context;
       
        public redact( komandorEntities context, Товар товар)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = товар;
            
            SkladComboBox.ItemsSource = context.Склад.ToList();
            post.ItemsSource = context.Поставщики.ToList();
            tip.ItemsSource = context.Тип_товара.ToList();
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
