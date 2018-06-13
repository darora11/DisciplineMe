using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;

namespace DisciplineMe.Bot
{
    class Bot : IDisposable
    {
        public TelegramBotClient Client { get; set; }
        public long? ChatId { get; set; } = null;

        public event Action<int> OnYesInlineReply;
        public event Action<int> OnNoInlineReply;

        public Bot(string token)
        {
            Client = new TelegramBotClient(token);
            var me = Client.GetMeAsync().Result;
            Console.Title = me.Username;

            Client.OnMessage += BotOnMessageReceived;
            Client.OnCallbackQuery += BotOnCallbackQueryReceived;
            Client.OnReceiveError += BotOnReceiveError;

            Client.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($"Start listening for @{me.Username}");

            if (ChatId == null)
                Console.WriteLine("The bot doesn't know your chat id. Please write something to him.");
        }

        public async void SendInline(int habitId, string question)
        {
            if (ChatId == null)
                return;

            var inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Yes", $"yes-{habitId}"),
                                InlineKeyboardButton.WithCallbackData("No", $"no-{habitId}"),
                            }
                        });

            await Client.SendTextMessageAsync(
                ChatId,
                question,
                replyMarkup: inlineKeyboard
            );
        }

        private async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            if (ChatId == null)
            {
                ChatId = message.Chat?.Id;

                await Client.SendTextMessageAsync(
                    message.Chat.Id,
                    "Nice to meet you!",
                    replyMarkup: new ReplyKeyboardRemove());

                Console.WriteLine("Meet a user with ChatId: ", ChatId);
            }
            else
            {
                await Client.SendTextMessageAsync(
                    message.Chat.Id,
                    "Ok, wait messages from me.",
                    replyMarkup: new ReplyKeyboardRemove());
            }

        }

        private async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;
            var data = callbackQuery.Data;
            var split = data.Split(new char[] { '-' });
            bool yesReply = split[0] == "yes";
            var habitId = int.Parse(split[1]);
            var message = "Good job!";

            if (yesReply)
                OnYesInlineReply?.Invoke(habitId);
            else
            {
                message = "So sad, Amigo! But try again from tommorow.";
                OnNoInlineReply?.Invoke(habitId);
            }

            await Client.SendTextMessageAsync(
                callbackQuery.Message.Chat.Id,
                message);
        }

        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Console.WriteLine("Received error: {0} — {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message);
        }

        public void Dispose()
        {
            Client.StopReceiving();
        }
    }
}
