using BotLogic.Abstractions;
using BotLogic.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotLogic.Services
{
    public class CommandService : ICommandService
    {
        private readonly ITelegramBotClient _client;
        private readonly List<ITelegramCommand> _commands;

        public CommandService(ITelegramBotClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _commands = new List<ITelegramCommand>
            {
                new StartCommand(_client),
                new ConverRatesCommand(_client)
            };
        }

        public ITelegramCommand Get(Message message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            return this._commands.FirstOrDefault(x => x.Contains(message));
        }
    }
}
