using DisciplineMe.Lib;
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
        private static IHabitRepository repo = RepoFactory.HabitRepository;
        private static Bot _bot;

        public static void Main(string[] args)
        {
            Console.WriteLine("Type token:");
            var token = Console.ReadLine();
            _bot = new Bot(token);

            var timer = new Timer();
            timer.Interval = 5000;
            timer.Elapsed += Tick;
            timer.Enabled = true;

            Console.ReadLine();
            _bot.Dispose();
        }

        private static void Tick(object sender, EventArgs e)
        {
            _bot.SendInline(1, "true true true");
        }

    }
}
