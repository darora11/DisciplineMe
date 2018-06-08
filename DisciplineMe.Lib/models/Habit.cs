﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DisciplineMe.Lib
{
    public class Habit
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan ActiveDuration { get; set; }

        [MaxLength(100)]
        public string QuestionPhrase { get; set; }
        public int DayPassed { get; set; }
    }
}
