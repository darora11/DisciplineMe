using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisciplineMe.Lib.models
{
    public class Confirmation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsConfirmed { get; set; }

        public virtual Habit Habit { get; set; }
    }
}
