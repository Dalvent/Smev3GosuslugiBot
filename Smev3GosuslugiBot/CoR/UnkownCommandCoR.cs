using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Smev3GosuslugiBot.CoR
{
    public class UnkownCommandCoR : ElementInCoR
    {
        public UnkownCommandCoR(IMessageReceiver messageReceiver) : base(messageReceiver)
        {
        }

        protected override async Task<bool> HandlingUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {   
            await botClient.SendTextMessageAsync(update.GetChat(), "Не понял тебя, попробуй еще раз!");
            return true;
        }
    }
}