using DisciplineMe.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisciplineMe.Bot
{
    class RepoConnector
    {
        private IHabitRepository _repo = RepoFactory.HabitRepository;
    }
}
