using DungeonCrawlers.Components.Character;
using DungeonCrawlers.Components.Character.Race;
using DungeonCrawlers.Display;
using DungeonCrawlers.Systems;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
    public class CharacterCreationSystemShould
    {
        private const string PREFIX = "Sir";
        private const string FIRST_NAME = "Alex";
        private const string SURNAME = "Burgen";
        private const string SUFFIX = "The Brave";
        private const string FULL_NAME = $"{PREFIX} {FIRST_NAME} {SURNAME} {SUFFIX}";
        private readonly Mock<IDisplayer> displayer;
        private readonly ICharacterCreationSystem characterCreationSystem;

        public CharacterCreationSystemShould()
        {
            characterCreationSystem = new CharacterCreationSystem();

            displayer = new Mock<IDisplayer>();
            displayer.Setup(x => x.Write("Character creation: "));
            displayer.Setup(x => x.ReadString("Enter prefix: ")).Returns(PREFIX);
            displayer.Setup(x => x.ReadString("Enter first name: ")).Returns(FIRST_NAME);
            displayer.Setup(x => x.ReadString("Enter surname: ")).Returns(value: SURNAME);
            displayer.Setup(x => x.ReadString("Enter suffix: ")).Returns(SUFFIX);
        }

        [Fact]
        public void CreateCharacter()
        {
            //Act
            var character = characterCreationSystem.Create(displayer.Object);

            //Assert
            displayer.VerifyAll();
            Assert.Equal(FULL_NAME, character.MetaData.Name.GetCharacterName());
            Assert.Equal("Elf", character.MetaData.Race.getCharacterRace());
        }
    }
}