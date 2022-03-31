using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Smev3GosuslugiBot.State;
using Smev3GosuslugiBot.State.SearchByParameters;
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
                { typeof(SetupState), new SetupState(this) },
                { typeof(HelloState), new HelloState(this) },
                { typeof(TypeInformationLevelState), new TypeInformationLevelState(this) },
                { typeof(SearchByParametersState), new SearchByParametersState(this) },
                { typeof(WriteIdState), new WriteIdState(this) },
                { typeof(ChooseEnvironmentState), new ChooseEnvironmentState(this) },
                { typeof(ChooseSubjectState), new ChooseSubjectState(this) },
                { typeof(ContextOfUseState), new ContextOfUseState(this) },
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
                EnterStateOf<SetupState>(botClient, update, cancellationToken);
                userState = StateInstanceOf<SetupState>();
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
            if(_stateOfPersons.TryGetValue(update.GetUser().Id, out IState state))
                state.Exit(botClient, update, cancellationToken);
            
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