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
        public void Create(string Title)
        {
            throw new NotImplementedException();
        }

        public void Create(string Title, string QuestionPhrase, TimeSpan ActiveDuration, TimeSpan MsgTime)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Habit habit)
        {
            throw new NotImplementedException();
        }

        public Habit Read()
        {
            throw new NotImplementedException();
        }

        public Habit Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Update(Habit updatedHabit)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Habit> IHabitRepository.Read()
        {
            return new List<Habit>
            {
                new Habit(),
                new Habit()
            };
        }
    }
}
