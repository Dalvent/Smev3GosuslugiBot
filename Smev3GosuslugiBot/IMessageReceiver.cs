using System.Threading;
using System.Threading.Tasks;
using Smev3GosuslugiBot.State;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Smev3GosuslugiBot
{
    public interface IMessageReceiver
    {
        void EnterStateOf<TState>(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken) where TState : IState;
    }
}