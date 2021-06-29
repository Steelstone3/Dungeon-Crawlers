using System.Linq;
using DungeonCrawlers.Contracts.Character;
using DungeonCrawlers.Controllers.Characters;
using DungeonCrawlers.Game.Characters;
using Moq;
using Xunit;

namespace DungeonCrawlersTests
{
    public class CharacterPartyControllerShould
    {
        [Fact]
        public void ContainACharacterParty()
        {
            var characterPartyController = new CharacterPartyController();

            Assert.NotNull(characterPartyController.CharacterParty);
        }

        [Theory]
        [InlineData(1)]
        public void AddACharacterPartyMember(int numberOfCharacters)
        {
            var characterBuilder = new Mock<ICharacterBuilder>();
            var characterPartyController = new CharacterPartyController();

            characterPartyController.CreateCharacterParty(numberOfCharacters, characterBuilder.Object);

            Assert.NotNull(characterPartyController.CharacterParty);
            Assert.NotEmpty(characterPartyController.CharacterParty);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(11)]
        [InlineData(-1)]
        public void HaveAMaxCharacterPartyOfFour(int numberOfCharacters)
        {
            var characterBuilder = new Mock<ICharacterBuilder>();
            var characterPartyController = new CharacterPartyController();

            characterPartyController.CreateCharacterParty(numberOfCharacters, characterBuilder.Object);

            Assert.NotNull(characterPartyController.CharacterParty);
            Assert.NotEmpty(characterPartyController.CharacterParty);
            Assert.NotInRange(characterPartyController.CharacterParty.ToList().Count, 5, int.MaxValue);
        }

        [Fact]
        public void GeneratesASeededParty()
        {
            var characterBuilder = new Mock<ICharacterBuilder>();
            characterBuilder.Setup(x => x.BuildRandomCharacter(1, 1, 1)).Returns(new Character());
            var characterPartyController = new CharacterPartyController();

            characterPartyController.CreateCharacterParty(3, characterBuilder.Object);

            characterBuilder.Verify(x => x.BuildRandomCharacter(1, 1, 1));
        }

        [Fact]
        public void CreateACharacter()
        {
            var character = new Mock<ICharacter>();
            var characterBuilder = new Mock<ICharacterBuilder>();
            characterBuilder.Setup(x => x.BuildCharacter()).Returns(character.Object);

            var characterPartyController = new CharacterPartyController();

            characterPartyController.CreateCharacter(characterBuilder.Object);

            characterBuilder.Verify(x => x.BuildCharacter());
        }

        /*[Fact(Skip ="Not sure what to do about testing this")]
        public void DisplayCharacterParty()
        {
            var characterPartyController = new CharacterPartyController();

            characterPartyController.DisplayCharacterPartyMembers();

            //Assert.NotNull(characterPartyController.CharacterParty);
            //Assert.NotEmpty(characterPartyController.CharacterParty);
        }*/
    }
}