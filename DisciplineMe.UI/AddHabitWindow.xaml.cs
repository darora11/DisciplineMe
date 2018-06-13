using DisciplineMe.Lib;
using DisciplineMe.Lib.models;
using DisciplineMe.UI.viewModels;
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
    public enum OperationMode
    {
        create,
        update
    }

    /// <summary>
    /// Логика взаимодействия для AddHabitWindow.xaml
    /// </summary>
    public partial class AddHabitWindow : Window
    {
        private AddHabitViewModel _habit;
        IHabitRepository repo = RepoFactory.HabitRepository;
        private OperationMode _operationMode;

        public AddHabitWindow() : this(new AddHabitViewModel(), OperationMode.create)
        {
        }

        public AddHabitWindow(Habit habit) : this(new AddHabitViewModel(habit), OperationMode.update)
        {
        }

        public AddHabitWindow(AddHabitViewModel habit, OperationMode mode)
        {
            _habit = habit;
            _operationMode = mode;
            DataContext = _habit;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(_habit.Title))
            {
                MessageBox.Show("Please, describe your new habit. The field should not be empty.");
                return;
            }

            //try
            //{
            if (_operationMode == OperationMode.create)
                repo.Create(
                    Title: _habit.Title,
                    QuestionPhrase: _habit.Message,
                    ActiveDuration: new TimeSpan(0, _habit.Interval, 0),
                    MsgTime: _habit.NotificationTimespan
                );
            else
                repo.Update(new Habit
                {
                    Id = _habit.Id,
                    Title = _habit.Title,
                    ActiveDuration = new TimeSpan(0, _habit.Interval, 0),
                    QuestionPhrase = _habit.Message,
                    MessageTime = _habit.NotificationTimespan,
                    Confirmations = _habit.Confirmations
                });
            Close();
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show("Something went wrong: " + err.Message);
            //}
        }
    }
}
