using System.Threading;
using System.Threading.Tasks;
using Smev3GosuslugiBot.Properties;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Smev3GosuslugiBot.CoR
{
    public class NameSearchCoR : ElementInCoR
    {
        public NameSearchCoR(IMessageReceiver messageReceiver) : base(messageReceiver)
        {
        }

        protected override async Task<bool> HandlingUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.CallbackQuery?.Data != nameof(Resources.SearchByName)) 
                return false;
            
            await botClient.SendTextMessageAsync(update.GetChat(), "Поиск по имени");
            return true;
        }
    }
}