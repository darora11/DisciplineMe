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
        private IHabitRepository _repo = RepoFactory.HabitRepository;
        private Dictionary<CalendarDayButton, DateTime> _dayButtonsDict = new Dictionary<CalendarDayButton, DateTime>();

        public MainWindow()
        {
            InitializeComponent();
            var habits = new List<DisplayHabitViewModel>();
            foreach (var habit in _repo.Read())
                habits.Add(new DisplayHabitViewModel(habit));
            listBox.ItemsSource = habits;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
    }
}
