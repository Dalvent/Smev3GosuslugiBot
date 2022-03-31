using System;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Smev3GosuslugiBot
{
    public static class UpdateExtensions
    {
        public static User? GetUser(this Update update)
        {
            return update.Type switch
            {
                UpdateType.Message => update.Message.From,
                UpdateType.CallbackQuery => update.CallbackQuery.From,
                _ => null
            };
        }
        public static Chat? GetChat(this Update update)
        {
            return update.Type switch
            {
                UpdateType.Message => update.Message.Chat,
                UpdateType.CallbackQuery => update.CallbackQuery.Message.Chat,
                _ => null
            };
        }
    }
}