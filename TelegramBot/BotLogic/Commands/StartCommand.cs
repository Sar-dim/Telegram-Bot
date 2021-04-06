using BotLogic.Abstractions;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotLogic.Commands
{
    public class StartCommand : ITelegramCommand
    {
        private readonly ITelegramBotClient _client;

        public StartCommand(ITelegramBotClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public string Name => @"/start";

        public bool Contains(Message message)
        {
            if (message == null)
            {
                return false;
            }
            if (message.Type != MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }

        public async Task Execute(Message message)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            await _client.SendTextMessageAsync(chatId, "Input command like \"/convert dd/mm/yyyy usd\"", replyToMessageId: messageId);
        }
    }
}
