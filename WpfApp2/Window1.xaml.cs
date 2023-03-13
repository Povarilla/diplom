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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        komandorEntities context;
        string currentLetter = "";
        public Window1()
        {
            InitializeComponent();
            context = new komandorEntities();
            fid.ItemsSource = context.Товар.ToList();  

        }

        private void fil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fil.SelectedIndex == 0)
            {
                ShowTable();
            }
            if (fil.SelectedIndex == 1)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Соки")).ToList();
            }
            if (fil.SelectedIndex == 2)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Заморозка")).ToList();

            }
            if (fil.SelectedIndex == 3)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Быт. Химия")).ToList();

            }
            if (fil.SelectedIndex == 4)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Предкассовые")).ToList();

            }
            if (fil.SelectedIndex == 5)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Газ. Вода")).ToList();

            }
            if (fil.SelectedIndex == 6)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Водка")).ToList();

            }
            if (fil.SelectedIndex == 7)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Шампанское")).ToList();

            }
            if (fil.SelectedIndex == 8)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Вермут")).ToList();

            }
            if (fil.SelectedIndex == 9)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Детское питание")).ToList();

            }
            if (fil.SelectedIndex == 10)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Овощи")).ToList();

            }
            if (fil.SelectedIndex == 11)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Фрукты")).ToList();

            }
            if (fil.SelectedIndex == 12)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Выпечка")).ToList();

            }
            if (fil.SelectedIndex == 13)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Молочная продукция")).ToList();

            }
            if (fil.SelectedIndex == 14)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Здоровое питание")).ToList();

            }
            if (fil.SelectedIndex == 15)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Вода")).ToList();

            }
            if (fil.SelectedIndex == 16)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Печенье")).ToList();

            }
            if (fil.SelectedIndex == 17)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Мясные изделия")).ToList();

            }
            if (fil.SelectedIndex == 18)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Чай, кофе")).ToList();

            }
            if (fil.SelectedIndex == 19)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Коньяк")).ToList();

            }
            if (fil.SelectedIndex == 20)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Корм")).ToList();

            }
            if (fil.SelectedIndex == 21)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Сладости")).ToList();

            }
            if (fil.SelectedIndex == 22)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Мороженное")).ToList();

            }
            if (fil.SelectedIndex == 23)
            {
                fid.ItemsSource = context.Товар.Where(x => x.Тип_товара1.Наименование.Contains("Крупы")).ToList();

            }

        }

        private void ShowTable()
        {
            context = new komandorEntities();
            fid.ItemsSource = context.Товар.ToList();
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            var dea = fid.SelectedItem as Товар;
            if (dea == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно ходите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Товар.Remove(dea);
                context.SaveChanges();

            }
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Dob = new Товар();
            context.Товар.Add(Dob);
            OpenFileDialog das = new OpenFileDialog();
            das.Title = "Выберите фото к товару";
            das.Filter = "All supported graphics|*.jpeg;*.jpg;*.png|" + " JPEG(*.jpeg;*.jpg)|*.jpeg;*.jpg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (das.ShowDialog() == true)
            {
                Dob.Фото_товара = new Фото_товара { Фото = das.FileName };
            }
            var Dob1 = new redact(context, Dob);
            Dob1.ShowDialog();
            Update();
        }

        private void Update()
        {
            fid.ItemsSource = context.Товар.ToList();
            fid.Items.Refresh();
        }
        private void red_Click(object sender, RoutedEventArgs e)
        {
            Button red1 = sender as Button;
            var red2 = red1.DataContext as Товар;
            OpenFileDialog das = new OpenFileDialog();
            das.Title = "Выберите фото к товару";
            das.Filter = "All supported graphics|*.jpeg;*.jpg;*.png|" + " JPEG(*.jpeg;*.jpg)|*.jpeg;*.jpg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (das.ShowDialog() == true)
            {
                red2.Фото_товара = new Фото_товара { Фото = das.FileName };
            }
            var red3 = new redact(context, red2);
            red3.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable1();

        }

        private void ShowTable1()
        {
            if (p.Text == null)
                return;
            List<Товар> azx = context.Товар.ToList();
            azx = azx.Where(x => x.Поставщики.Наименование.ToLower().Contains(p.Text.ToLower())).ToList();
            if (currentLetter.Count() == 1)
            {
                azx = azx.Where(x => x.Наименование.Contains(currentLetter)).ToList();
            }
            fid.ItemsSource = azx.OrderBy(x => x.Наименование).ToList();
        }

        private void akct_Click(object sender, RoutedEventArgs e)
        {
            AkcT akcT = new AkcT();
            akcT.Show();
            
        }
        private void skid_Click(object sender, RoutedEventArgs e)
        {
            Skidk skidk = new Skidk();
            skidk.Show();

        }
        private void lik_Click(object sender, RoutedEventArgs e)
        {
            likv likv = new likv();
            likv.Show();

        }

        private void spis_Click(object sender, RoutedEventArgs e)
        {
            SpisT spist = new SpisT();
            spist.Show();

        }
        private void a_Click(object sender, RoutedEventArgs e)
        {
            akcc akcc = new akcc();
            akcc.Show();

        }
        private void sotr_Click(object sender, RoutedEventArgs e)
        {
            sotrud sotrud= new sotrud();
            sotrud.Show();

        }
        private void pos_Click(object sender, RoutedEventArgs e)
        {
           post post = new post();
            post.Show();

        }
        private void pla_Click(object sender, RoutedEventArgs e)
        {
            plan plan = new plan();
            plan.Show();    

        }

    }
}
