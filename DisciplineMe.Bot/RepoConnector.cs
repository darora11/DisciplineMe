using DisciplineMe.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DisciplineMe.Bot
{
    class RepoConnector
    {
        private IHabitRepository _repo = RepoFactory.HabitRepository;
        private const int INTERVAL_MINUTES = 15; // minutes
        public TimeSpan Interval
        {
            get { return new TimeSpan(0, INTERVAL_MINUTES, 0); }
        }

        public RepoConnector()
        {
            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += Tick;
            dispatcherTimer.Interval = Interval;
            dispatcherTimer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, string> Tick()
        {
            var dict = _repo.ReadMessages(DateTime.Now.TimeOfDay, Interval);
            return dict;
        }
    }
}
