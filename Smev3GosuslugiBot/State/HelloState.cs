using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Smev3GosuslugiBot.Properties;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Smev3GosuslugiBot.State
{
    public class HelloState : IState
    {
        private readonly IMessageReceiver _messageReceiver;

        public HelloState(IMessageReceiver messageReceiver)
        {
            _messageReceiver = messageReceiver;
        }

        public async Task Enter(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendTextMessageAsync(update.GetChat(), "Поиск по параметрам");
            ReplyKeyboardMarkup keyboard = new(new[]
            {
                new List<KeyboardButton>()
                {
                    new(Resources.SearchByName),
                },
                
                new List<KeyboardButton>()
                {
                    new(Resources.SearchByParameters),
                },
            })
            {
                ResizeKeyboard = true,
                Selective = true
            };

            await botClient.SendTextMessageAsync(update.GetChat(), "выфвфыв", replyMarkup: keyboard, cancellationToken: cancellationToken);
        }

        public async Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(update.Message == null)
                return;
            
            if (update.Message.Text != nameof(Resources.SearchByName))
            {
                await botClient.SendTextMessageAsync(update.GetChat(), Resources.SearchByName);
            }
            else if (update.Message.Text != nameof(Resources.SearchByParameters))
            {
                await botClient.SendTextMessageAsync(update.GetChat(), Resources.SearchByParameters);
            }
            else
            {
                await botClient.SendTextMessageAsync(update.GetChat(), "Не понял тебя, попробуй еще раз!");
            }
        }

        public async Task Exit(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var remove = new ReplyKeyboardRemove();
            await botClient.SendTextMessageAsync(update.GetChat(), "", replyMarkup: remove, cancellationToken: cancellationToken);
        }
    }
}