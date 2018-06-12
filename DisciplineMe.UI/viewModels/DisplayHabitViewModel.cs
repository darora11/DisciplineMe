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

        public string Title
        {
            get { return Habit.Title; }
        }

        public int TotalDays
        {
            get { return Habit.CountConsecutiveDays(); }
        }

        public string Progress {
            get
            {
                var milestone = 7;
                if (TotalDays >= 7 && TotalDays < 21)
                    milestone = 21;
                else if (TotalDays >= 21 && TotalDays < 90)
                    milestone = 90;
                return $"{TotalDays}/{milestone} days";
            }
        }

        public string NotificationInfo {
            get {
                return $"Each day at {Habit.DateStart.TimeOfDay}" +
                    $"(during {Habit.ActiveDuration.TotalMinutes} minutes)";
            }
        }

        public DisplayHabitViewModel(Habit habit)
        {
            Habit = habit;
        }
    }
}
