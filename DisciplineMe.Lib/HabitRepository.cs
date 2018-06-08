using System;
using System.Collections.Generic;
using System.Text;

namespace DisciplineMe.Lib
{
    class HabitRepository : HabitInterface
    {
        public List<Habit> Habits { get; set; } = new List<Habit>();

        public HabitRepository()
        {

        }

        public void Create()
        {
            throw new NotImplementedException();
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
