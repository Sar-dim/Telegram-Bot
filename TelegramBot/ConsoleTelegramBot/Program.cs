using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using Telegram.Bot;

namespace ConsoleTelegramBot
{
    class Program
    {
		static private IServiceProvider _serviceProvider;
		public static void Main(string[] args)
		{
			Startup();
			ITelegramBotClient client = _serviceProvider.GetService<ITelegramBotClient>();
			BotClient botClient = new BotClient(client);
		}

		private static void Startup()
        {
			IConfiguration _configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();

			string token = _configuration.GetValue<string>("Token");

			_serviceProvider = new ServiceCollection()
				.AddSingleton<ITelegramBotClient, TelegramBotClient>(x => new TelegramBotClient(token))
				.BuildServiceProvider();
		}
	}
}
