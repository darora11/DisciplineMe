using System;
using System.Collections.Generic;
using System.Text;

namespace DisciplineMe.Lib
{
    class Repository : HabitInterface
    {
        public List<Habit> Habits { get; set; } = new List<Habit>();

        public Repository()
        {

        }

        public void Create()
        {
            using (var db = new Context())
            {
                var Now = new DateTime();

                var Habit = new Habit
                {
                    Title = "Wake up before 7am",
                    ActiveDuration = new TimeSpan(0, 30, 0),
                    DayPassed = 0,
                    QuestionPhrase = "Good morning! Is it?",
                    DateStart = new DateTime(Now.Year, Now.Month, Now.Day, 6, 30, 00)
                };

                db.Habits.Add(Habit);
                db.SaveChanges();
            }
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
