using DungeonCrawlers.Contracts.Character;
using DungeonCrawlers.Services.Character;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Characters
{
    public class CharacterPartyServiceShould
    {
        [Fact]
        public void CreateCharacterParty()
        {
            var characterPartyController = new Mock<ICharacterPartyController>();
            characterPartyController.Setup(x => x.CreateAMainCharacter());
            characterPartyController.Setup(x => x.CreateACharacterParty(3));

            var characterPartyService = new CharacterPartyService(characterPartyController.Object);

            characterPartyService.CreateCharacterParty();

            characterPartyController.Verify(x => x.CreateAMainCharacter());
            characterPartyController.Verify(x => x.CreateACharacterParty(3));
        }
    }
}