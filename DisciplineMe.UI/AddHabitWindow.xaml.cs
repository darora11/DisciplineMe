﻿using DisciplineMe.UI.viewModels;
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

namespace DisciplineMe.UI
{
    /// <summary>
    /// Логика взаимодействия для AddHabitWindow.xaml
    /// </summary>
    public partial class AddHabitWindow : Window
    {
        private AddHabitViewModel Habit { get; set; } = new AddHabitViewModel();

        public AddHabitWindow()
        {
            InitializeComponent();

            DataContext = Habit;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = 5;
        }
    }
}
