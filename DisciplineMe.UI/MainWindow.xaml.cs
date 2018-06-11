using System;
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
using DisciplineMe.UI.viewModels;

namespace DisciplineMe.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<DateTime> _dates = new List<DateTime>
        {
            new DateTime(2018,6,25),
            new DateTime(2018,6,23),
            new DateTime(2018,6,14)
        };

        private IHabitRepository _repo = RepoFactory.HabitRepository;

        public MainWindow()
        {
            InitializeComponent();
            var habits = _repo.Read();
            listBox.ItemsSource = habits;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // Next part were taken from http://mom.hlmjr.com/2016/11/07/highlighting-dates-on-a-wpf-calendar-control/
        // for dates highlighting in the Calendar.

        private void calendarButton_Loaded(object sender, EventArgs e)
        {
            CalendarDayButton button = (CalendarDayButton)sender;
            DateTime date = (DateTime)button.DataContext;
            HighlightDay(button, date);
            button.DataContextChanged += new DependencyPropertyChangedEventHandler(calendarButton_DataContextChanged);
        }

        private void HighlightDay(CalendarDayButton button, DateTime date)
        {
            if (_dates.Contains(date))
                button.Background = Brushes.LightBlue;
            else
                button.Background = Brushes.White;
        }

        private void calendarButton_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CalendarDayButton button = (CalendarDayButton)sender;
            DateTime date = (DateTime)button.DataContext;
            HighlightDay(button, date);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddHabitWindow().Show();
        }
    }
}
