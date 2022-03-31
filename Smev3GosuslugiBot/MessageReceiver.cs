using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Smev3GosuslugiBot.State;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Smev3GosuslugiBot
{
    public class MessageReceiver : IUpdateHandler, IMessageReceiver
    {
        private Dictionary<long, IState> _stateOfPersons = new();

        private Dictionary<Type, IState> _statePool;

        public MessageReceiver()
        {
            _statePool = new Dictionary<Type, IState>
            {
                { typeof(ISetupState), new SetupState(this) },
                { typeof(IHelloState), new HelloState(this) }
            };
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(update.Type is not (UpdateType.Message or UpdateType.CallbackQuery))
                return;
            
            IState userState;
            Chat messageChat = update.GetChat();
            if (!_stateOfPersons.TryGetValue(messageChat.Id, out userState))
            {
                EnterStateOf<ISetupState>(botClient, update, cancellationToken);
                userState = StateInstanceOf<ISetupState>();
            }

            await userState.Update(botClient, update, cancellationToken);
        }

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.StackTrace);
            return Task.CompletedTask;
        }

        public void EnterStateOf<TState>(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken) where TState : IState
        {
            TState stateInstanceOf = StateInstanceOf<TState>();
            _stateOfPersons[update.GetUser().Id] = stateInstanceOf;
            stateInstanceOf.Enter(botClient, update, cancellationToken);
        }

        private TState StateInstanceOf<TState>() where TState : IState
        {
            return (TState) _statePool[typeof(TState)];
        }
    }
}