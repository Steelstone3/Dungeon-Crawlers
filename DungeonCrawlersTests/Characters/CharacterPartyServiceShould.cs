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
            var characterBuilder = new Mock<ICharacterBuilder>();
            var characterPartyController = new Mock<ICharacterPartyController>();
            characterPartyController.Setup(x => x.CreateCharacter(characterBuilder.Object));
            characterPartyController.Setup(x => x.CreateCharacterParty(3, characterBuilder.Object));

            var characterPartyService = new CharacterPartyService(characterPartyController.Object);

            characterPartyService.CreateCharacterParty(characterBuilder.Object);

            characterPartyController.Verify(x => x.CreateCharacter(characterBuilder.Object));
            characterPartyController.Verify(x => x.CreateCharacterParty(3, characterBuilder.Object));
        }
    }
}