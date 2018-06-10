using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DisciplineMe.UI.viewModels
{
    class AddHabitViewModel : INotifyPropertyChanged
    {
        private TimeSpan _notificationTimespan;
        public TimeSpan NotificationTimespan
        {
            get { return _notificationTimespan; }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set {
                _title = value;
                OnPropertyChanged("Title");
                OnPropertyChanged("Message");
            }
        }

        private string _message;
        public string Message
        {
            get {
                if (String.IsNullOrEmpty(_message))
                    return $"It is time for your habit: '{Title}'\nAre you coping?";
                return _message;
            }
            set {
                _message = value;
                OnPropertyChanged("Message");
            }
        }


        private int _timeTicks;
        public int TimeTicks
        {
            get { return _timeTicks; }
            set {
                _timeTicks = value;
                _notificationTimespan = new TimeSpan(0, value * 15, 0);
               
                OnPropertyChanged("TimeTicks");
                OnPropertyChanged("NotificationTimeLabel");
            }
        }
        public string NotificationTimeLabel
        {
            get
            {
                int hours = _timeTicks / 4;
                int minutes = _timeTicks % 4 * 15;

                string liter = (hours > 12 || hours == 12 && minutes > 0) ? "PM" : "AM";
                if (liter == "PM")
                    hours -= 12;

                string minutesMark = (minutes == 0) ? "00" : minutes.ToString();

                return $"{hours}:{minutesMark} {liter}";
            }
        }

        private int _interval;
        public int Interval
        {
            get { return _interval; }
            set {
                _interval = value;
                OnPropertyChanged("Interval");
            }
        }

        public AddHabitViewModel()
        {
            Title = "Wake up before 7 AM";
            TimeTicks = 26;
            Interval = 30;
        }

        // Source: https://metanit.com/sharp/wpf/22.2.php
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    // The idea from here https://stackoverflow.com/questions/37790017/wpf-mvvm-radiobutton-handle-binding-with-single-property
    class IntervalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int.Parse((string)parameter) == (int)value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? int.Parse((string)parameter) : Binding.DoNothing;
        }
    }
}
