using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DisciplineMe.Lib
{
    public class Context : DbContext
    {
        public Context() : base("DbConnection")
        { }

        public DbSet<Habit> Habits { get; set; }
    }
}
