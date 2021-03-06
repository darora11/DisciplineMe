﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisciplineMe.Lib.models;

namespace DisciplineMe.Lib
{
    public class CacheRepository : IHabitRepository
    {
        private List<Habit> _habits = new List<Habit>();
        private List<Confirmation> _confirmations = new List<Confirmation>();

        public event Action<Habit> OnAddItem;
        public event Action<Habit> OnUpdateItem;
        public event Action<Habit> OnDeleteItem;

        public void Create(string Title)
        {
            var QPhrase = $"It is time for your habit:\n'{Title}'\nAre you coping?";
            var MsgTime = new TimeSpan(20, 0, 0);
            var ActiveDuration = new TimeSpan(4, 0, 0);
            Create(Title, QPhrase, ActiveDuration, MsgTime);
        }

        public void Create(string Title, string QuestionPhrase, TimeSpan ActiveDuration, TimeSpan MsgTime)
        {
            var Now = DateTime.Now;

            var habit = new Habit
            {
                Title = Title,
                ActiveDuration = ActiveDuration,
                QuestionPhrase = QuestionPhrase,
                MessageTime = MsgTime,
                Confirmations = new List<Confirmation>()
            };

            _habits.Add(habit);
            OnAddItem?.Invoke(habit);
        }

        public void CreateConfirmation(Confirmation confirmation)
        {
            var habit = _habits.Where(h => h.Id == confirmation.Habit.Id).FirstOrDefault();
            if (habit != null)
                habit.Confirmations.Add(confirmation);
            _confirmations.Add(confirmation);
        }

        public void Delete(int id)
        {
            Delete(Read(id));
        }

        public void Delete(Habit habit)
        {
            _habits.Remove(habit);
            OnDeleteItem?.Invoke(habit);
        }

        public Habit Read(int id)
        {
            return _habits.Find(h => h.Id == id);
        }

        public Dictionary<int, string> ReadMessages(TimeSpan startTime, TimeSpan intervalLength)
        {
            return _habits.Where(h => h.MessageTime >= startTime && h.MessageTime < startTime + intervalLength)
                .Select(h => new
                {
                    Id = h.Id,
                    Message = h.QuestionPhrase
                })
                .ToDictionary(h => h.Id, h => h.Message);
        }

        public void Update(Habit updatedHabit)
        {
            var habit = Read(updatedHabit.Id);
            habit.Title = updatedHabit.Title;
            habit.QuestionPhrase = updatedHabit.QuestionPhrase;
            habit.MessageTime = updatedHabit.MessageTime;
            habit.ActiveDuration = updatedHabit.ActiveDuration;
            OnUpdateItem?.Invoke(habit);
        }

        IEnumerable<Habit> IHabitRepository.Read()
        {
            return _habits;
        }
    }
}
