using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotLogic.Abstractions
{
    public interface ITelegramCommand
    {
        public string Name { get; }

        public Task Execute(Message message);

        public bool Contains(Message message);
    }
}
