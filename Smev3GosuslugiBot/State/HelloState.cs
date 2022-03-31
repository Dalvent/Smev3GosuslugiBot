using System.Threading;
using System.Threading.Tasks;
using Smev3GosuslugiBot.CoR;
using Smev3GosuslugiBot.Properties;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Smev3GosuslugiBot.State
{
    public class HelloState : IHelloState
    {
        private readonly ElementInCoR _elementsOfCoR;

        public HelloState(IMessageReceiver messageReceiver)
        {
            _elementsOfCoR = CoRFactory.CreateWithUnknownAtEnd(messageReceiver, new ElementInCoR[]
            {
                new NameSearchCoR(messageReceiver),
                new ParametersSearchCoR(messageReceiver)
            });
        }

        public async Task Enter(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
            {
                InlineKeyboardButton.WithCallbackData(Resources.SearchByName, nameof(Resources.SearchByName)),
                InlineKeyboardButton.WithCallbackData(Resources.SearchByParameters, nameof(Resources.SearchByParameters))
            });
            await botClient.SendTextMessageAsync(update.GetChat(), "выфвфыв", replyMarkup: inlineKeyboardMarkup, cancellationToken: cancellationToken);
        }

        public async Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await _elementsOfCoR.HandleUpdate(botClient, update, CancellationToken.None);
        }
    }
}