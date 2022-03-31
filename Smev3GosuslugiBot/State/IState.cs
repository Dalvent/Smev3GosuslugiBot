using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Smev3GosuslugiBot.State
{
    public interface IState
    {
        Task Enter(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
        Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
        Task Exit(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }
}