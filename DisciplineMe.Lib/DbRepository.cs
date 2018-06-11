using DisciplineMe.Lib.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisciplineMe.Lib
{
    public class DbRepository : IHabitRepository
    {
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
                var Now = DateTime.Now;
                var DateStart = new DateTime(Now.Year, Now.Month, Now.Day, MsgTime.Hours, MsgTime.Minutes, MsgTime.Seconds);

                var Habit = new Habit
                {
                    Title = Title,
                    ActiveDuration = ActiveDuration,
                    QuestionPhrase = QuestionPhrase,
                    DateStart = DateStart
                };

                db.Habits.Add(Habit);
                db.SaveChanges();
            }
        }

        IEnumerable<Habit> IHabitRepository.Read()
        {
            using (var db = new Context())
            {
                return db.Habits;
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
                db.SaveChanges();
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
                db.Habits.Remove(habit);
                db.SaveChanges();
            }
        }
    }
}
