using System;
using System.Collections.Generic;
using System.Text;

namespace DisciplineMe.Lib
{
    public interface IHabitRepository
    {
        /// <summary>
        /// Creates new row in Habit table of database.
        /// </summary>
        /// <param name="Title">Title of a habit.</param>
        void Create(string Title);
        /// <summary>
        /// Expansion of Create method. Takes additional parameters.
        /// </summary>
        /// <param name="Title">Title of a habit.</param>
        /// <param name="QuestionPhrase">Question which bot will ask.</param>
        /// <param name="ActiveDuration">Out of the time started from MsgTime the discipline line is fired.</param>
        /// <param name="MsgTime">Time when confirmation message should be sent.</param>
        void Create(string Title, string QuestionPhrase, TimeSpan ActiveDuration, TimeSpan MsgTime);
        Habit Read();
        void Update();
        void Delete();
    }
}
