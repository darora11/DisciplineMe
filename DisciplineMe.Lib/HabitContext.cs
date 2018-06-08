using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DisciplineMe.Lib
{
    class HabitContext : DbContext
    {
        public HabitContext() : base("DbConnection")
        { }

        public DbSet<Habit> Habits { get; set; }
    }
}
