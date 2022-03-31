using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Smev3GosuslugiBot.State;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using File = System.IO.File;

namespace Smev3GosuslugiBot
{
    internal class Program
    {
        private static ITelegramBotClient _bot;

        public static void Main(string[] args)
        {
            var token = GetToken();
            _bot = new TelegramBotClient(token);

            var receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = { }
            };

            _bot.StartReceiving(
                new MessageReceiver(),
                receiverOptions,
                CancellationToken.None
            );
            Console.ReadKey();
        }

        public static string GetToken()
        {
            return File.ReadAllText("token.txt");
        }
    }
}