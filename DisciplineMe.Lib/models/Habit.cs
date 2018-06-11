using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    }
}
