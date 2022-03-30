using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Smev3GosuslugiBot.CoR
{
    public class NameSearchCoR
    {
        
    }

    public abstract class ElementInCoR
    {
        protected IMessageReceiver MessageReceiver { get; }
        
        private ElementInCoR? _next;

        public ElementInCoR(IMessageReceiver messageReceiver)
        {
            MessageReceiver = messageReceiver;
        }        
        
        public ElementInCoR SetNext(ElementInCoR next)
        {
            _next = next;
            return _next;
        }

        public async Task HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (await HandlingUpdate(botClient, update, cancellationToken))
                return;
        }
        
        protected abstract Task<bool> HandlingUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }
}