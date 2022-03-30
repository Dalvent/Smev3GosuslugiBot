using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace Smev3GosuslugiBot
{
    public class MessageReceiver : IUpdateHandler, IMessageReceiver
    {
        public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void ChangeStateOf(ITelegramBotClient botClient)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMessageReceiver
    {
        public void ChangeStateOf(ITelegramBotClient botClient);
    }
}