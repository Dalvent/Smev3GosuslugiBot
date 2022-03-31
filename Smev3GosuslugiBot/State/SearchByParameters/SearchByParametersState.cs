using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Smev3GosuslugiBot.State.SearchByParameters;

public class SearchByParametersState : IState
{
    private readonly IMessageReceiver _messageReceiver;

    public SearchByParametersState(IMessageReceiver messageReceiver)
    {
        _messageReceiver = messageReceiver;
    }
    
    public async Task Enter(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(update.GetChat(), "Поиск по параметрам",
            cancellationToken: cancellationToken);
        
        _messageReceiver.EnterStateOf<TypeInformationLevelState>(botClient, update, cancellationToken);
    }

    public Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Exit(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private static ReplyKeyboardMarkup CreateReplyMarkupKeyboard(params string[] buttonsTexts)
    {
        return null;
    }
}