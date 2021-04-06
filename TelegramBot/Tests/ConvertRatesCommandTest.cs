using System;
using Xunit;
using BotLogic.Commands;
using BotLogic.Abstractions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Moq;
using Telegram.Bot.Types.Enums;
using System.Threading;
using System.Net.Http;

namespace Tests
{
    public class ConvertRatesCommandTest
    {
        private Mock<ITelegramBotClient> Mock { get; set; }
        private ConverRatesCommand CommandService { get; set; }
        private Message Message { get; set; }
        public ConvertRatesCommandTest()
        {
            Mock = new Mock<ITelegramBotClient>();
            CommandService = new ConverRatesCommand(Mock.Object);
            Message = new Message { Text = @"/convert 31.03.2021", Chat = new Chat { Id = 471491775 } };
        }
        [Fact]
        public void ContainsTest()
        {
            //Arrange  
            bool expactation = true;
            //Act
            bool result = CommandService.Contains(Message);
            //Assert
            Assert.Equal(expactation, result);
        }
        [Fact]
        public async void ExecuteTest()
        {
            //Arrange

            //Act
            await CommandService.Execute(Message);
            //Assert
            Mock.Verify(expression: x => x.SendTextMessageAsync(It.IsAny<ChatId>(), It.IsAny<string>(), 
                ParseMode.Default, false, false, 0, null, default(CancellationToken)), Times.Once());
        }
    }
}
