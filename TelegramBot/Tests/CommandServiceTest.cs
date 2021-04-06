using BotLogic.Abstractions;
using BotLogic.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Xunit;

namespace Tests
{
    public class CommandServiceTest
    {
        [Fact]
        public void GetTest()
        {
            //Arrange
            CommandService commandService = new CommandService(new TelegramBotClient("1763504448:AAHcj41HAFpVCI8zzy49gc8Zql6mj8WDS6k"));
            //Act
            Action act = () => commandService.Get(null);
            //Assert
            Exception exception = Assert.Throws<ArgumentNullException>(act);
            Assert.Equal("Value cannot be null. (Parameter 'message')", exception.Message);
        }
        
    }
}
