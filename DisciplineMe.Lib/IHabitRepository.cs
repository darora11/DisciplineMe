using DisciplineMe.Lib.models;
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
        /// <summary>
        /// Fetches list of habits.
        /// </summary>
        /// <returns>Collection of habits.</returns>
        IEnumerable<Habit> Read();
        /// <summary>
        /// Get habit by id.
        /// </summary>
        /// <param name="id">Id of a habit.</param>
        /// <returns>Habit.</returns>
        Habit Read(int id);
        /// <summary>
        /// Updates habit object.
        /// </summary>
        /// <param name="id">Id of habit to update.</param>
        /// <param name="updatedHabit">New habit object.</param>
        void Update(Habit updatedHabit);
        /// <summary>
        /// Removes habit from a storage.
        /// </summary>
        /// <param name="id">Id of a habit to remove.</param>
        void Delete(int id);
        /// <summary>
        /// Removes habit from a storage.
        /// </summary>
        /// <param name="habit">Habit to remove. Should contain the same id as
        /// initial one and it should not be equal 0.</param></param>
        void Delete(Habit habit);
    }
}
