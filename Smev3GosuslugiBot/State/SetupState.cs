using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Smev3GosuslugiBot.State
{
    public class SetupState : IState
    {
        private readonly IMessageReceiver _messageReceiver;

        public SetupState(IMessageReceiver messageReceiver)
        {
            _messageReceiver = messageReceiver;
        }
        
        public Task Enter(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        { 
            _messageReceiver.EnterStateOf<HelloState>(botClient, update, cancellationToken);
            return Task.CompletedTask;
        }

        public Task Exit(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}