using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Smev3GosuslugiBot.State
{
    public interface IState
    {
        void Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }
}