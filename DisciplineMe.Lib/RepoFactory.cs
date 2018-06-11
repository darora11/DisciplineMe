using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DisciplineMe.Lib
{
    public class RepoFactory
    {
        private static IHabitRepository _habitRepository;
        public static IHabitRepository HabitRepository
        {
            get
            {
                if (_habitRepository == null)
                {
                    var storageMode = ConfigurationManager.AppSettings["storage_mode"];
                    if (String.Equals(storageMode, "cache"))
                        _habitRepository = new CacheRepository();
                    else if (String.Equals(storageMode, "db"))
                        _habitRepository = new DbRepository();
                    else
                        throw new Exception("In app.config the parameter 'storage_mode' can take only two values:\n" +
                            "'cache' - for using ICollection for managing data in the app;\n" +
                            "'db' - for using MSSQL-Server for that purpose.");
                }
                return _habitRepository;
            }
        }
    }
}
