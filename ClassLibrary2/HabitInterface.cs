using System;
using System.Collections.Generic;
using System.Text;

namespace DisciplineMe.Lib
{
    interface HabitInterface
    {
        void Create();
        Habit Read();
        void Update();
        void Delete();
    }
}
