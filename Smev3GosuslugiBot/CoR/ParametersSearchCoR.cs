using System.Threading;
using System.Threading.Tasks;
using Smev3GosuslugiBot.Properties;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Smev3GosuslugiBot.CoR
{
    public class ParametersSearchCoR : ElementInCoR
    {
        public ParametersSearchCoR(IMessageReceiver messageReceiver) : base(messageReceiver)
        {
        }

        protected override async Task<bool> HandlingUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.CallbackQuery?.Data != nameof(Resources.SearchByParameters)) 
                return false;
            
            await botClient.SendTextMessageAsync(update.GetChat(), "Поиск по параметрам");
            return true;
        }
    }
}