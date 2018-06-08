using System;

namespace DisciplineMe.Lib
{
    public class Habbit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan NotificationTimespan { get; set; }
        public TimeSpan ActiveDuration { get; set; }
        public string QuestionPhrase { get; set; }
        public int DayPassed { get; set; }

        public Habbit(string Title, TimeSpan NotificationTimespan, TimeSpan ActiveDuration, string QuestionPhrase)
        {
            this.Title = Title;
            this.NotificationTimespan = NotificationTimespan;
            this.ActiveDuration = ActiveDuration;
            this.QuestionPhrase = QuestionPhrase;
        }
    }
}
