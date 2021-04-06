using BotLogic.Abstractions;
using BotLogic.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;


namespace ConsoleTelegramBot
{
    class BotClient
    {
		private static ITelegramBotClient _client;
		public static ICommandService _commandService;

        public BotClient(ITelegramBotClient client)
        {
			_client = client ?? throw new ArgumentNullException(nameof(client));
			_commandService = new CommandService(_client);

			client.OnMessage += BotOnMessageReceived;
			client.OnMessageEdited += BotOnMessageReceived;
			client.StartReceiving();
			Console.ReadLine();
			client.StopReceiving();
		}
		private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
		{
			var message = messageEventArgs.Message;
			if (message?.Type == MessageType.Text)
			{
				var command = _commandService.Get(message);
				if (command == null)
				{
					await _client.SendTextMessageAsync(message.Chat.Id, "Command not found");
				}
				else
				{
					await command.Execute(message);
				}
			}
		}
	}
}
