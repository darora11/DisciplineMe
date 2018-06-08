using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DisciplineMe.Lib
{
    public class Context : DbContext
    {
        public DbSet<Habit> Habits { get; set; }

        public Context() : base("DbConnection")
        { }
    }
}
