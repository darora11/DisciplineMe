using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisciplineMe.Lib.models;

namespace DisciplineMe.Lib
{
    class CacheRepository : IHabitRepository
    {
        public void Create(string Title)
        {
            throw new NotImplementedException();
        }

        public void Create(string Title, string QuestionPhrase, TimeSpan ActiveDuration, TimeSpan MsgTime)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public Habit Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
