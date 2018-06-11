using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisciplineMe.Lib.models;

namespace DisciplineMe.Lib
{
    public class CacheRepository : IHabitRepository
    {
        private List<Habit> _habits = new List<Habit>();

        public void Create(string Title)
        {
            var QPhrase = $"It is time for your habit:\n'{Title}'\nAre you coping?";
            var MsgTime = new TimeSpan(20, 0, 0);
            var ActiveDuration = new TimeSpan(4, 0, 0);
            Create(Title, QPhrase, ActiveDuration, MsgTime);
        }

        public void Create(string Title, string QuestionPhrase, TimeSpan ActiveDuration, TimeSpan MsgTime)
        {
            var Now = DateTime.Now;
            var DateStart = new DateTime(Now.Year, Now.Month, Now.Day, MsgTime.Hours, MsgTime.Minutes, MsgTime.Seconds);

            var habit = new Habit
            {
                Title = Title,
                ActiveDuration = ActiveDuration,
                QuestionPhrase = QuestionPhrase,
                DateStart = DateStart
            };

            _habits.Add(habit);
        }

        public void Delete(int id)
        {
            Delete(Read(id));
        }

        public void Delete(Habit habit)
        {
            _habits.Remove(habit);
        }

        public Habit Read(int id)
        {
            return _habits.Find(h => h.Id == id);
        }

        public void Update(Habit updatedHabit)
        {
            var habit = Read(updatedHabit.Id);
            habit = (Habit)updatedHabit.Clone();
        }

        IEnumerable<Habit> IHabitRepository.Read()
        {
            return _habits;
        }
    }
}
