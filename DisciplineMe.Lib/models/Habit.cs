using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DisciplineMe.Lib.models
{
    public class Habit : ICloneable
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan ActiveDuration { get; set; }
        [MaxLength(200)]
        public string QuestionPhrase { get; set; }

        public virtual ICollection<Confirmation> Confiramtions { get; set; }

        public object Clone()
        {
            return new Habit
            {
                Id = this.Id,
                Title = this.Title,
                DateStart = this.DateStart,
                ActiveDuration = this.ActiveDuration,
                QuestionPhrase = this.QuestionPhrase,
                Confiramtions = this.Confiramtions
            };
        }

        public int CountConsecutiveDays()
        {
            if (Confiramtions.Count == 0)
                return 0;

            var negatives = Confiramtions.OrderByDescending(c => c.Date)
                .Where(c => !c.IsConfirmed).ToList();

            if (negatives.Count == 0)
                return Confiramtions.Count;

            var max = 0;
            for (int i = 0; i < negatives.Count - 1; i++)
            {
                var length = (int)negatives[i].Date.Subtract(negatives[i - 1].Date).TotalDays - 1;
                if (length > max)
                    max = length;
            }

            int milestone = 0;
            if (max >= 7 && max < 21)
                milestone = 7;
            if (max >= 21 && max < 90)
                milestone = 21;
            if (max >= 90)
                milestone = 90;

            return (int)DateTime.Now.Subtract(negatives[0].Date).TotalDays - 1 + milestone;
        }
    }
}
