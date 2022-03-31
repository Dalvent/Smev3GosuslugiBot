using System.Threading;
using System.Threading.Tasks;
using Smev3GosuslugiBot.CoR;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Smev3GosuslugiBot.State
{
    public class SetupState : ISetupState
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
            _messageReceiver.EnterStateOf<IHelloState>(botClient, update, cancellationToken);
            return Task.CompletedTask;
        }
    }
}