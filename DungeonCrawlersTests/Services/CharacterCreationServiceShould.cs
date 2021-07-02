using DungeonCrawlers.Contracts;
using DungeonCrawlers.States;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Services
{
    public class CharacterCreationServiceShould
    {
        [Fact]
        public void CreateACharacterParty()
        {
            //Given
            var characterController = new Mock<ICharacterController>();
            characterController.Setup(x => x.CreateCharacter());
            characterController.Setup(x => x.CreateCharacterParty(3));
            var characterCreationService = new CharacterCreationService();
            
            //When
            characterCreationService.CreateCharacterParty(characterController.Object, 3);

            //Then
            characterController.Verify(x => x.CreateCharacter());
            characterController.Verify(x => x.CreateCharacterParty(3));
        }
    }
}