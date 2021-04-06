using System.Collections.Generic;
using Telegram.Bot.Types;

namespace BotLogic.Abstractions
{
    public interface ICommandService
    {
        ITelegramCommand Get(Message message);
    }
}
