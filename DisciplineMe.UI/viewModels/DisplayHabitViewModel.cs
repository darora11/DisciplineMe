using DisciplineMe.Lib.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisciplineMe.UI.viewModels
{
    class DisplayHabitViewModel
    {
        public Habit Habit { get; set; }

        public string Title { get; set; }
        public string Progress { get; set; }
        public string NotificationInfo { get; set; }
        public int MyProperty { get; set; }
        public Milestone Milestone { get; set; }

        public DisplayHabitViewModel(Habit habit)
        {
            Habit = habit;
            Title = habit.Title;

            habit.Confiramtions.ToList().ForEach(c =>
            {
               
            });

            Progress = $"";
        }
    }

    public enum Milestone
    {
        Zero = 0,
        First = 7,
        Second = 21,
        Third = 90
    }
}
