using DisciplineMe.Lib.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace DisciplineMe.Lib
{
    public class DbRepository : IHabitRepository
    {
        public event Action<Habit> OnAddItem;
        public event Action<Habit> OnUpdateItem;
        public event Action<Habit> OnDeleteItem;

        public void Create(string Title)
        {
            var QPhrase = $"It is time for your habit:\n'{Title}'\nAre you coping?";
            var MsgTime = new TimeSpan(20, 0, 0);
            var ActiveDuration = new TimeSpan(4, 0, 0);
            Create(Title, QPhrase, ActiveDuration, MsgTime);
        }

        public void Create(string Title, string QuestionPhrase, TimeSpan ActiveDuration, TimeSpan MsgTime)
        {
            using (var db = new Context())
            {
                var DateStart = DateTime.Now.Date + MsgTime;

                var habit = new Habit
                {
                    Title = Title,
                    ActiveDuration = ActiveDuration,
                    QuestionPhrase = QuestionPhrase,
                    DateStart = DateStart
                };

                db.Habits.Add(habit);
                db.SaveChanges();

                OnAddItem?.Invoke(habit);
            }
        }

        IEnumerable<Habit> IHabitRepository.Read()
        {
            using (var db = new Context())
            {
                return db.Habits.Include(h => h.Confirmations).ToList();
            }
        }

        public Habit Read(int id)
        {
            using (var db = new Context())
            {
                return db.Habits.Where(h => h.Id == id).First();
            }
        }

        public void Update(Habit updatedHabit)
        {
            using (var db = new Context())
            {
                var habit = db.Habits.SingleOrDefault(h => h.Id == updatedHabit.Id);
                habit.Title = updatedHabit.Title;
                habit.QuestionPhrase = updatedHabit.QuestionPhrase;
                habit.DateStart = habit.DateStart.Date + updatedHabit.DateStart.TimeOfDay;
                habit.ActiveDuration = updatedHabit.ActiveDuration;
                db.SaveChanges();
                OnUpdateItem?.Invoke(updatedHabit);
            }
        }

        public void Delete(int id)
        {
            var habit = Read(id);
            Delete(habit);
        }

        public void Delete(Habit habit)
        {
            using (var db = new Context())
            {
                db.Habits.Remove(
                    db.Habits.SingleOrDefault(h => h.Id == habit.Id));
                db.SaveChanges();
                OnDeleteItem?.Invoke(habit);
            }
        }

        public Dictionary<int, string> ReadMessages(TimeSpan startTime, TimeSpan intervalLength)
        {
            using (var db = new Context())
            {
                var dict = (from h in db.Habits
                             where h.DateStart.TimeOfDay >= startTime && h.DateStart.TimeOfDay < startTime + intervalLength
                             select new
                             {
                                 Message = h.QuestionPhrase,
                                 Id = h.Id
                             }).ToDictionary(x => x.Id, x => x.Message);
                return dict;
            }
        }

        public void CreateConfirmation(Confirmation confirmation)
        {
            using (var db = new Context())
            {
                db.Confirmations.Add(confirmation);
                db.SaveChanges();
            }
        }
    }
}
