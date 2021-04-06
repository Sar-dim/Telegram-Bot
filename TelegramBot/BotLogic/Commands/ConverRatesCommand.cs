using BotLogic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WebLogic;

namespace BotLogic.Commands
{
    public class ConverRatesCommand : ITelegramCommand
    {
        private readonly ITelegramBotClient _client;

        public ConverRatesCommand(ITelegramBotClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public string Name => @"/convert";

        public bool Contains(Message message)
        {
            if (message == null || message.Type != MessageType.Text)
            {
                return false;
            }

            return message.Text.StartsWith(Name);
        }

        public async Task Execute(Message message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            DateTime dateTime;
            CurrencyClient currencyClient = new CurrencyClient();
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            var match = new Regex(@"\d{2}.\d{2}.\d{4}").Matches(message.Text).FirstOrDefault();
            if (match != null && DateTime.TryParse(match.Value, out dateTime))
            {
                var xml = currencyClient.GetXML(dateTime.Date.ToString());
                var valuteName = new Regex(@"\b[a-zA-Z]{3}\b").Matches(message.Text).FirstOrDefault();
                if (valuteName == null)
                {
                    valuteName = new Regex(@"\b[a-zA-Z]{1}\d{5}\b").Matches(message.Text).FirstOrDefault();
                    if (valuteName == null)
                    {
                        await _client.SendTextMessageAsync(chatId, "Can't parse valute name", replyToMessageId: messageId);
                        return;
                    }
                }   
                currencyClient.ValCurs = currencyClient.ParseValute(xml);
                var rate = "";
                foreach (var item in currencyClient.ValCurs.Valutes)
                {
                    if (item.ID == valuteName.Value.ToUpper() || item.CharCode == valuteName.Value.ToUpper())
                    {
                        rate = item.Value.ToString();
                        break;
                    }
                }
                if (rate == "")
                {
                    await _client.SendTextMessageAsync(chatId, "Valute name or code isn't correct", replyToMessageId: messageId);
                }
                else
                {
                    await _client.SendTextMessageAsync(chatId, rate, replyToMessageId: messageId);
                } 
            }
            else
            {
                await _client.SendTextMessageAsync(chatId, "Can't parse date", replyToMessageId: messageId);
            }
        }
    }
}
