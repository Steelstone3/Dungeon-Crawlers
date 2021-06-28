using System.Collections.Generic;
using DungeonCrawlers.Helpers;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Helpers
{
    public class GenericDisplayHelperShould
    {
        [Fact]
        public void DisplayMenu()
        {
            var menu = new List<string>()
            {
                "1. Bob",
                "2. Terry",
                "3. Jeff",
            };

            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.WriteMenu(menu));

            var genericDisplayHelper = new GenericDisplayHelper(displayer.Object);

            genericDisplayHelper.DisplayMenu(menu);

            displayer.Verify(x => x.WriteMenu(menu));
        }

        [Fact]
        public void DisplayText()
        {
            var text = "Some random text";

            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write(text));

            var genericDisplayHelper = new GenericDisplayHelper(displayer.Object);

            genericDisplayHelper.DisplayText(text);

            displayer.Verify(x => x.Write(text));
        }

        [Fact]
        public void ReadUserText()
        {
            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Read());

            var genericDisplayHelper = new GenericDisplayHelper(displayer.Object);

            genericDisplayHelper.ReadUserText();

            displayer.Verify(x => x.Read());
        }

        [Fact]
        public void DisplayMessageAndReadUserText()
        {
            var text = "Some random text";

            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Read(text));

            var genericDisplayHelper = new GenericDisplayHelper(displayer.Object);

            genericDisplayHelper.ReadUserText(text);

            displayer.Verify(x => x.Read(text));
        }

        [Fact]
        public void EnterAValidIntergerRange()
        {
            var message = "Some random text";

            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Read(message)).Returns("5");

            var genericDisplayHelper = new GenericDisplayHelper(displayer.Object);

            var actual = genericDisplayHelper.ReadUserNumericInput(message, 1, 6);

            displayer.Verify(x => x.Read(message));
            Assert.Equal(5, actual);
        }

        [Fact]
        public void EnterAValidDoubleRange()
        {
            var message = "Some random text";

            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Read(message)).Returns("5");

            var genericDisplayHelper = new GenericDisplayHelper(displayer.Object);

            var actual = genericDisplayHelper.ReadUserNumericInput(message, 1.0D, 6.0D);

            displayer.Verify(x => x.Read(message));
            Assert.Equal(5, actual);
        }
    }
}