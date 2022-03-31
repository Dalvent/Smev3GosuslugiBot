using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Smev3GosuslugiBot.State.SearchByParameters;

public class WriteIdState : IState
{
    private readonly IMessageReceiver _messageReceiver;

    public WriteIdState(IMessageReceiver messageReceiver)
    {
        _messageReceiver = messageReceiver;
    }
    
    public async Task Enter(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        ReplyKeyboardMarkup keyboard = new(new[]
        {
            new List<KeyboardButton> { new("Пропустить") },
        }) 
        {
            ResizeKeyboard = true,
            Selective = true
        };

        await botClient.SendTextMessageAsync(update.GetChat(), "Введите идентификатор", replyMarkup: keyboard,
            cancellationToken: cancellationToken);
    }

    public Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is null)
            return Task.CompletedTask;
        
        if (update.Message.Text is "Пропустить") {}
        else { }
        
        _messageReceiver.EnterStateOf<ContextOfUseState>(botClient, update, cancellationToken);
        return Task.CompletedTask;
    }

    public Task Exit(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}