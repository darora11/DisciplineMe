using DisciplineMe.Lib;
using DisciplineMe.Lib.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;

namespace DisciplineMe.Bot
{
    // for this program code snippets from the following repo were used:
    // https://github.com/TelegramBots/Telegram.Bot.Examples/blob/master/Telegram.Bot.Examples.Echo/Program.cs
    class Program
    {
        private static IHabitRepository _repo = RepoFactory.HabitRepository;
        private static Bot _bot;
        private static readonly TimeSpan _interval = new TimeSpan(0, 15, 0);

        public static void Main(string[] args)
        {
            Console.WriteLine("Type token:");
            var token = Console.ReadLine();
            _bot = new Bot(token);
            _bot.OnNoInlineReply += YesHandler;
            _bot.OnYesInlineReply += NoHandler;

            var timer = new Timer();
            timer.Interval = _interval.TotalMilliseconds;
            timer.Elapsed += Tick;
            timer.Enabled = true;

            Console.ReadLine();
            _bot.Dispose();
        }

        private static void Tick(object sender, EventArgs e)
        {
            var dict = _repo.ReadMessages(DateTime.Now.TimeOfDay, _interval);
            foreach (var item in dict)
            {
                _bot.SendInline(item.Key, item.Value);
            }
        }

        private static void YesHandler(int habitId)
        {
            CreateConfirmation(habitId, true);
        }

        private static void CreateConfirmation(int habitId, bool isConfirmed)
        {
            _repo.CreateConfirmation(new Confirmation
            {
                Date = DateTime.Now,
                IsConfirmed = isConfirmed,
                Habit = _repo.Read(habitId)
            });
        }

        private static void NoHandler(int habitId)
        {
            CreateConfirmation(habitId, false);
        }
    }
}
