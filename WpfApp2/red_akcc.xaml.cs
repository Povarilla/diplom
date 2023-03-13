﻿using System;
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
    /// Логика взаимодействия для red_akcc.xaml
    /// </summary>
    public partial class red_akcc : Window
    {
        komandorEntities context;
        public red_akcc(komandorEntities context, Акции акции)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = акции;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
