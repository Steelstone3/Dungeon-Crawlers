using System.Linq;
using DungeonCrawlers.Controllers.Characters;
using Xunit;

namespace DungeonCrawlersTests
{
    public class CharacterPartyControllerShould
    {
        [Fact]
        public void ContainACharacterParty()
        {
            var characterPartyController = new CharacterPartyController();

            Assert.Null(characterPartyController.CharacterParty);
        }

        [Theory]
        [InlineData(1)]
        public void AddACharacterPartyMember(int numberOfCharacters)
        {
            var characterPartyController = new CharacterPartyController();

            characterPartyController.CreateACharacterParty(numberOfCharacters);

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
            var characterPartyController = new CharacterPartyController();

            characterPartyController.CreateACharacterParty(numberOfCharacters);

            Assert.NotNull(characterPartyController.CharacterParty);
            Assert.NotEmpty(characterPartyController.CharacterParty);
            Assert.NotInRange(characterPartyController.CharacterParty.ToList().Count, 5, int.MaxValue);
        }

        [Fact(Skip ="Not sure what to do about testing this")]
        public void DisplayCharacterParty()
        {
            var characterPartyController = new CharacterPartyController();

            characterPartyController.DisplayCharacterPartyMembers();

            //Assert.NotNull(characterPartyController.CharacterParty);
            //Assert.NotEmpty(characterPartyController.CharacterParty);
        }
    }
}