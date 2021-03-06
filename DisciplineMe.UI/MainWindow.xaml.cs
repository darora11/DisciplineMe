﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DisciplineMe.Lib;
using DisciplineMe.Lib.models;
using DisciplineMe.UI.viewModels;

namespace DisciplineMe.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHabitRepository _repo = RepoFactory.HabitRepository;
        private Dictionary<CalendarDayButton, DateTime> _dayButtonsDict = new Dictionary<CalendarDayButton, DateTime>();

        public MainWindow()
        {
            InitializeComponent();

            _repo.OnAddItem += RefreshList;
            _repo.OnDeleteItem += RefreshList;
            _repo.OnUpdateItem += RefreshList;
            _repo.OnUpdateItem += h =>
            {
                listBox.SelectedItem = 0;
            };

            RefreshList(null);
        }

        private void RefreshList(Habit habit)
        {
            var habits = new List<DisplayHabitViewModel>();
            foreach (var h in _repo.Read())
                habits.Add(new DisplayHabitViewModel(h));
            listBox.ItemsSource = habits;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedValue == null)
                return;

            var dates = ((DisplayHabitViewModel)listBox.SelectedValue)
                .Habit.Confirmations
                .Where(c => c.IsConfirmed)
                .Select(c => c.Date)
                .ToList();

            foreach (var item in _dayButtonsDict)
            {
                HighlightDay(item.Key, item.Value, dates);
            }
        }

        // Next part were taken from http://mom.hlmjr.com/2016/11/07/highlighting-dates-on-a-wpf-calendar-control/
        // for dates highlighting in the Calendar.
        // But was modified for our purposes.

        private void calendarButton_Loaded(object sender, EventArgs e)
        {
            CalendarDayButton button = (CalendarDayButton)sender;
            DateTime date = (DateTime)button.DataContext;
            _dayButtonsDict[button] = date;
            button.DataContextChanged += new DependencyPropertyChangedEventHandler(calendarButton_DataContextChanged);
        }

        private void HighlightDay(CalendarDayButton button, DateTime date, List<DateTime> highlightDates)
        {
            if (highlightDates.Contains(date))
                button.Background = Brushes.LightBlue;
            else
                button.Background = Brushes.White;
        }

        private void calendarButton_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CalendarDayButton button = (CalendarDayButton)sender;
            DateTime date = (DateTime)button.DataContext;
            _dayButtonsDict[button] = date;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddHabitWindow().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedValue == null)
            {
                MessageBox.Show("Please select an item to update.");
                return;
            }

            var habit = ((DisplayHabitViewModel)listBox.SelectedValue).Habit;
            new AddHabitWindow(habit).Show();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var habit = ((DisplayHabitViewModel)listBox.SelectedValue).Habit;
            if (habit == null)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }
            _repo.Delete(habit);
        }
    }
}
