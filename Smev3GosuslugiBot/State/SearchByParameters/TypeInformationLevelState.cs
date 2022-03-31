using Smev3GosuslugiBot.Properties;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Smev3GosuslugiBot.State.SearchByParameters;

public class TypeInformationLevelState : IState
{
    private readonly IMessageReceiver _messageReceiver;

    public TypeInformationLevelState(IMessageReceiver messageReceiver)
    {
        _messageReceiver = messageReceiver;
    }
    
    public async Task Enter(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        ReplyKeyboardMarkup keyboard = new(new[]
        {
            new List<KeyboardButton> { new("Федеральный уровень") },
            new List<KeyboardButton> { new("Региональный уровень") },
        }) 
        {
            ResizeKeyboard = true,
            Selective = true
        };

        await botClient.SendTextMessageAsync(update.GetChat(), "Вид сведений", replyMarkup: keyboard,
            cancellationToken: cancellationToken);
    }

    public Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is null)
            return Task.CompletedTask;

        if (update.Message.Text is "Федеральный уровень")
        {
            _messageReceiver.EnterStateOf<ChooseEnvironmentState>(botClient, update, cancellationToken);
        }
        
        else if (update.Message.Text is "Региональный уровень")
        {
            _messageReceiver.EnterStateOf<ChooseSubjectState>(botClient, update, cancellationToken);
        }

        else
        {
            
        }
        
        return Task.CompletedTask;

    }

    public Task Exit(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}