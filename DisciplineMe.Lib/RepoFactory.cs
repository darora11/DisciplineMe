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
        private static RepoFactory _factory;
        public static RepoFactory Factory
        {
            get
            {
                if (_factory == null)
                    _factory = new RepoFactory();
                return _factory;
            }
        }

        public IHabitRepository GetHabitRepository()
        {
            var storageMode = ConfigurationManager.AppSettings["storage_mode"];
            if (String.Equals(storageMode, "cache"))
                return new CacheRepository();
            else if (String.Equals(storageMode, "db"))
                return new DbRepository();
            else
                throw new Exception("In app.config the parameter 'storage_mode' can take only two values:\n" +
                    "'cache' - for using ICollection for managing data in the app;\n" +
                    "'db' - for using MSSQL-Server for that purpose.");
        }
    }
}
