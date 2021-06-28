using DungeonCrawlers.Contracts.Helper;
using DungeonCrawlers.Controllers.Characters;
using DungeonCrawlersTests.Helpers;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Characters
{
    public class CharacterBuilderShould
    {
        [Fact]
        public void GetUserCharacterName()
        {
            var text = "Enter character's name:";

            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Read(text));

            var characterBuilder = new CharacterBuilder(displayer.Object);

            characterBuilder.BuildCharacter();

            displayer.Verify(x => x.Read(text));
        }

        [Fact]
        public void GetUserCharacterCombatClass()
        {
            var text = "Select combat class:";

            var displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Read(text)).Returns("0");

            var characterBuilder = new CharacterBuilder(displayer.Object);

            characterBuilder.BuildCharacter();

            displayer.Verify(x => x.Read(text));
        }

        [Fact]
        public void BuildsACharacter()
        {

            //var characterBuilder = new CharacterBuilder();
        }
    }
}